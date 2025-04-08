using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Commander.Data.File;
using Commander.Part.Explorer.ViewModels.Temps;
using Commander.Windows.Mvvm;


namespace Commander.Part.Explorer.ViewModels
{
	public partial class ExplorerViewModel : ObservableObject
    {
        internal bool IsExplorerUpdated;
        private Stack<FileData> UndoList;
        private Stack<FileData> RedoList;
        private ExplorerWatcher FileWatcher;
        private ExplorerRefreshWorker RefreshWorker;

        public ICommand MoveCommand { get; set; }
        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public ICommand PromptCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand ChooseCommand { get; set; }
        public ICommand KeyDownCommand { get; set; }

        private bool _isMoveUpEnabled;
        public bool IsMoveUpEnabled
        {
            get { return _isMoveUpEnabled; }
            set { _isMoveUpEnabled = value; base.OnPropertyChanged(); }
        }

        private bool _isUndoEnabled;
        public bool IsUndoEnabled
        {
            get { return _isUndoEnabled; }
            set { _isUndoEnabled = value; base.OnPropertyChanged(); }
        }

        private bool _isRedoEnabled;
        public bool IsRedoEnabled
        {
            get { return _isRedoEnabled; }
            set { _isRedoEnabled = value; base.OnPropertyChanged(); }
        }

        private bool _isHiddenVisibility;
        public bool IsHiddenVisibility
        {
            get { return _isHiddenVisibility; }
            set { _isHiddenVisibility = value; base.OnPropertyChanged(); }
        }

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
            set { _fileData = value; base.OnPropertyChanged(); }
        }

        private FileData _current;
        public FileData Current
        {
            get { return _current; }
            set { _current = value; OnPropertyChanged(); }
        }

        public ExplorerViewModel()
        {
            PromptCommand = new RelayCommand<object>(PromptClick);
            MoveCommand = new RelayCommand<object>(MoveClick);
            UndoCommand = new RelayCommand<object>(UndoClick);
            RedoCommand = new RelayCommand<object>(RedoClick);
            NewCommand = new RelayCommand<object>(NewClick);
            CopyCommand = new RelayCommand<object>(CopyClick);
            CloseCommand = new RelayCommand<object>(CloseClick);
            ChooseCommand = new RelayCommand<FileData>(DoubleClick);
            KeyDownCommand = new RelayCommand<KeyEventArgs>(InputKeys);
        }

        protected override void OnViewLoaded()
        {
            string path = Environment.CurrentDirectory;
            UndoList = new Stack<FileData>();
            RedoList = new Stack<FileData>();
            Refresh(path);

            FileData = new FileData { FullName = path };
            Current = FileData;
            UndoList.Push(FileData);
            RedoList.Clear();
            SetButtons();

            InitFileAsync();
        }

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

        private void MoveClick(object obj)
        {
            Current =  FileDatas.FirstOrDefault();
            if (Current is FileData f)
            {
                DoubleClick(Current);
            }
        }

        private void UndoClick(object obj)
        {
            var popUndo = UndoList.Pop();
            RedoList.Push(popUndo);
            FileData = UndoList.Pop();
            UndoList.Push(FileData);

            FileDatas = FileDirectory.GetCurrentData(FileData.FullName, true);
            SetButtons();
        }

        private void RedoClick(object obj)
        {
            FileData = RedoList.Pop();
            UndoList.Push(FileData);
            FileDatas = FileDirectory.GetCurrentData(FileData.FullName, true);
            SetButtons();
        }

        private void NewClick(object obj)
        {
        }

        private void CopyClick(object obj)
        {
        }

        private void CloseClick(object obj)
        {
            Window.GetWindow(View).Close();
        }

        private void DoubleClick(FileData item)
        {
            Current = item;
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
                SetButtons();
            }
            else if (Current.FileType == FileTypes.File)
            {
                Process.Start(Current.FullName);
            }
        }

        private void InputKeys(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F2: break;
                case Key.F5: break;
                case Key.Enter: DoubleClick(FileData); break;
                case Key.Back: GoBack(); break;
            }
        }

        private void GoBack()
        {
            if (IsUndoEnabled)
            {
                UndoClick(null);
            }
            else if (IsRedoEnabled)
            {
                RedoClick(null);
            }
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

        internal void Refresh() => Refresh(Current.FullName);

        internal void Refresh(string path) => View.Dispatcher.Invoke(() => FileDatas = FileDirectory.GetCurrentData(path, true));

        private void SetButtons()
        {
            IsUndoEnabled = UndoList.Count != 1;
            IsRedoEnabled = RedoList.Count != 0;

            var parent = Directory.GetParent(Current.FullName);

            IsMoveUpEnabled = parent != null;

            if (FileWatcher != null)
            {
                FileWatcher.ChangeWatchPath(Current.FullName);
            }
        }
    }
}
