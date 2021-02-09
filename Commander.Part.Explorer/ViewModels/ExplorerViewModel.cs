using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Commander.Data.File;
using Commander.Part.Explorer.ViewModels.Temps;
using Commander.Part.Explorer.Views;
using Commander.Windows.Mvvm;


namespace Commander.Part.Explorer.ViewModels
{
    public partial class ExplorerViewModel : ObservableObject
    {
        #region Variables

        internal bool IsExplorerUpdated;
        private readonly ExplorerView view;
        private Stack<FileData> UndoList;
        private Stack<FileData> RedoList;
        private ExplorerWatcher FileWatcher;
        private ExplorerRefreshWorker RefreshWorker;
        #endregion

        #region ICommand

        public ICommand MoveCommand { get; set; }
        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public ICommand PromptCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand NewCommand { get; set; }
        #endregion

        #region IsMoveUpEnabled

        private bool _isMoveUpEnabled;
        public bool IsMoveUpEnabled
        {
            get { return _isMoveUpEnabled; }
            set { _isMoveUpEnabled = value; base.OnPropertyChanged(); }
        }
        #endregion

        #region IsUndoEnabled

        private bool _isUndoEnabled;
        public bool IsUndoEnabled
        {
            get { return _isUndoEnabled; }
            set { _isUndoEnabled = value; base.OnPropertyChanged(); }
        }
        #endregion

        #region IsRedoEnabled

        private bool _isRedoEnabled;
        public bool IsRedoEnabled
        {
            get { return _isRedoEnabled; }
            set { _isRedoEnabled = value; base.OnPropertyChanged(); }
        }
        #endregion

        #region IsHiddenVIsibility

        private bool _isHiddenVisibility;
        public bool IsHiddenVisibility
        {
            get { return _isHiddenVisibility; }
            set { _isHiddenVisibility = value; base.OnPropertyChanged(); }
        }
        #endregion

        #region FileDatas

        private List<FileData> _fileDatas;
        public List<FileData> FileDatas
        {
            get { return _fileDatas; }
            set { _fileDatas = value; base.OnPropertyChanged(); }
        }

        private FileData _fileData;
        public FileData FileData
        {
            get { return _fileData; }
            set
            {
                _fileData = value; base.OnPropertyChanged();
                view.FileClick.Invoke(this.view, FileData);
            }
        }
        #endregion

        #region Current

        private FileData _current;
        public FileData Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged(); }
        }
        #endregion

        #region MousePosition

        private System.Drawing.Point _mousePosition;
        public System.Drawing.Point MousePosition
        {
            get { return _mousePosition; }
            set { _mousePosition = value; base.OnPropertyChanged("MousePosition"); }
        }
        #endregion

        #region Constructor

        public ExplorerViewModel(ExplorerView _view)
        {
            this.view = _view;

            PromptCommand = new RelayCommand<object>(PromptClick);
            MoveCommand = new RelayCommand<object>(MoveClick);
            UndoCommand = new RelayCommand<object>(UndoClick);
            RedoCommand = new RelayCommand<object>(RedoClick);
            NewCommand = new RelayCommand<object>(NewClick);
            CopyCommand = new RelayCommand<object>(CopyClick);
            CloseCommand = new RelayCommand<object>(CloseClick);
        }
        #endregion

        #region OnViewLoaded

        protected override void OnViewLoaded()
        {
            string path = @"C:\ncoresoft";
            UndoList = new Stack<FileData>();
            RedoList = new Stack<FileData>();
            RefreshFolder(path);

            view.lv.MouseDoubleClick += Lv_MouseDoubleClick;
            view.lv.MouseRightButtonUp += Lv_MouseRightButtonUp;

            FileData = new FileData { FullName = path };
            Current = FileData;
            UndoList.Push(FileData);
            RedoList.Clear();
            SetUndoRedoStatus();

            InitFileAsync();
        }
        #endregion

        #region PromptClick

        private void PromptClick(object obj)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd")
            {
                WorkingDirectory = FileData.FullName
            };
            Process proc = new Process
            {
                StartInfo = info
            };
            proc.Start();
        }
        #endregion

        #region MoveClick

        private void MoveClick(object obj)
        {
            var parent = Directory.GetParent(FileData.FullName);
            if (parent != null)
            {
                FileData = new FileData { FullName = parent.FullName };
                RedoList.Clear();
                UndoList.Push(FileData);
                FileDatas = FileDirectory.GetCurrentData(FileData.FullName, true);
                SetUndoRedoStatus();
            }
        }
        #endregion

        #region UndoClick

        private void UndoClick(object obj)
        {
            var popUndo = UndoList.Pop();
            RedoList.Push(popUndo);
            FileData = UndoList.Pop();
            UndoList.Push(FileData);

            FileDatas = FileDirectory.GetCurrentData(FileData.FullName, true);
            SetUndoRedoStatus();
        }
        #endregion

        #region RedoClick

        private void RedoClick(object obj)
        {
            FileData = RedoList.Pop();
            UndoList.Push(FileData);
            FileDatas = FileDirectory.GetCurrentData(FileData.FullName, true);
            SetUndoRedoStatus();
        }
        #endregion

        #region NewClick

        private void NewClick(object obj)
        {
        }
        #endregion

        #region CopyClick

        private void CopyClick(object obj)
        {
            view.NewTabItemClick.Invoke(this.view);
        }
        #endregion

        #region CloseClick

        private void CloseClick(object obj)
        {
            view.TabItemClosed.Invoke(obj);
            Window.GetWindow(View).Close();
        }
        #endregion

        internal void Enter()
        {
            Lv_MouseDoubleClick(null, null);
        }

        internal void EEscapesc()
        {
            if (view.btnUndo.IsEnabled == true)
                UndoClick(null);
            else if (view.btnRedo.IsEnabled == true)
                RedoClick(null);
        }

        public void InitFileAsync()
        {
            App.Current.MainWindow.Closed += (s, e) => { RefreshWorker.RequestStop(); FileWatcher.RequestStop(); };

            RefreshWorker = new ExplorerRefreshWorker(this);
            Thread thread = new Thread(RefreshWorker.DoWork);
            thread.Start();

            FileWatcher = new ExplorerWatcher(this);
            FileWatcher.Run();
        }

        internal void RefreshFolder()
        {
            RefreshFolder(FileData.FullName);
        }

        internal void RefreshFolder(string path)
        {
            view.Dispatcher.Invoke(() => { FileDatas = FileDirectory.GetCurrentData(path, true); });
        }

        private void Lv_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Lv_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(App.Current.MainWindow);
            MousePosition = new System.Drawing.Point((int)p.X, (int)p.Y);
        }


        private void SetUndoRedoStatus()
        {
            IsUndoEnabled = UndoList.Count != 1;
            IsRedoEnabled = RedoList.Count != 0;

            var parent = Directory.GetParent(Current.FullName);

            if (parent == null)
            {
                IsMoveUpEnabled = false;
            }
            else
            {
                IsMoveUpEnabled = true;
            }

            if (FileWatcher != null)
                FileWatcher.ChangeWatchPath(Current.FullName);
        }

        private void Lv_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FileData != null)
            {
                Current = FileData;
                if (Current.FileType == FileTypes.Directory || Current.FileType == FileTypes.Parent
                    || Current.FileType == FileTypes.HiddenDirectory)
                {
                    var newData = FileDirectory.GetCurrentData(Current.FullName, true);
                    if (newData.Count == 0 && FileDirectory.IsError == true)
                    {
                        MessageBox.Show(FileDirectory.ErrorMessage);
                        return;
                    }
                    FileDatas = newData;
                    UndoList.Push(Current);
                    RedoList.Clear();
                    SetUndoRedoStatus();
                }
                else if (Current.FileType == FileTypes.File)
                {
                    Process.Start(Current.FullName);
                }
            }
        }
    }
}
