using Commander.OperationSystem.Screen;
using Commander.Part.Explorer.ViewModels.Temps;
using Commander.Part.Explorer.Views;
using Commander.Windows.Mvvm;
using Commander.WindowsReference.OperationSystem.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Commander.Part.Explorer.ViewModels
{
    public partial class ExplorerViewModel : ObservableObject
    {
        internal ExplorerView view;

        Stack<FileData> UndoList { get; set; }
        Stack<FileData> RedoList { get; set; }

        bool _IsMoveUpEnabled;
        public bool IsMoveUpEnabled
        {
            get { return _IsMoveUpEnabled; }
            set { _IsMoveUpEnabled = value; base.OnPropertyChanged("IsMoveUpEnabled"); }
        }

        bool _IsUndoEnabled;
        public bool IsUndoEnabled
        {
            get { return _IsUndoEnabled; }
            set { _IsUndoEnabled = value; base.OnPropertyChanged("IsUndoEnabled"); }
        }

        bool _IsRedoEnabled;
        public bool IsRedoEnabled
        {
            get { return _IsRedoEnabled; }
            set { _IsRedoEnabled = value; base.OnPropertyChanged("IsRedoEnabled"); }
        }

        bool _IsHiddenVisibility;
        public bool IsHiddenVisibility
        {
            get { return _IsHiddenVisibility; }
            set { _IsHiddenVisibility = value; base.OnPropertyChanged("IsHiddenVisibility"); }
        }

        public ExplorerViewModel(ExplorerView _view)
        {
            this.view = _view;
        }

        List<FileData> _FileDatas;
        public List<FileData> FileDatas
        {
            get { return _FileDatas; }
            set { _FileDatas = value; base.OnPropertyChanged("FileDatas"); }
        }

        internal void Enter()
        {
            Lv_MouseDoubleClick(null, null);
        }

        internal void EEscapesc()
        {
            if (view.btnUndo.IsEnabled == true)
                BtnUndo_Click(null, null);
            else if (view.btnRedo.IsEnabled == true)
                BtnRedo_Click(null, null);
        }

        System.Drawing.Point _MousePosition;
        public System.Drawing.Point MousePosition
        {
            get { return _MousePosition; }
            set { _MousePosition = value; base.OnPropertyChanged("MousePosition"); }
        }


        FileData _CurrentFile;
        public FileData CurrentFile
        {
            get { return _CurrentFile; }
            set
            {
                _CurrentFile = value; base.OnPropertyChanged("CurrentFile");
                view.FileClick.Invoke(this.view, CurrentFile);
            }
        }

        ExplorerWatcher FileWatcher;
        ExplorerRefreshWorker RefreshWorker;

        internal bool IsExplorerUpdated;

        public void InitFileAsync()
        {
            App.Current.MainWindow.Closed += (s, e) => { RefreshWorker.RequestStop(); FileWatcher.RequestStop(); };

            RefreshWorker = new ExplorerRefreshWorker(this);
            Thread thread = new Thread(RefreshWorker.DoWork);
            thread.Start();

            FileWatcher = new ExplorerWatcher(this);
            FileWatcher.Run();
        }

        internal void InitViewModel(string path = @":\")
        {
            UndoList = new Stack<FileData>();
            RedoList = new Stack<FileData>();

            //get folder refresh.
            RefreshFolder(path, true);

            view.lv.MouseDoubleClick += Lv_MouseDoubleClick;
            view.lv.PreviewMouseMove += Lv_MouseMove;
            view.lv.MouseRightButtonUp += Lv_MouseRightButtonUp;
            view.lv.MouseRightButtonDown += Lv_MouseRightButtonDown;
            view.btnUndo.Click += BtnUndo_Click;
            view.btnRedo.Click += BtnRedo_Click;
            view.btnMoveUp.Click += BtnMoveUp_Click;
            view.btnCMD.Click += BtnCMD_Click;
            view.btnCopyTab.Click += BtnCopyTab_Click;
            view.btnCloseTab.Click += BtnCloseTab_Click;
            view.btnNewFolder.Click += BtnNewFolder_Click;

            CurrentFile = new FileData { FullName = path };
            UndoList.Push(CurrentFile);
            RedoList.Clear();
            ExplorerChanged(this, CurrentFile);
            SetUndoRedoStatus();
        }

        private void BtnNewFolder_Click(object sender, RoutedEventArgs e)
        {
            //var newFolder = new NewDirectory();
            //newFolder.ShowDialog(this);
        }

        internal void RefreshFolder()
        {
            RefreshFolder(CurrentFile.FullName, true);
        }

        internal void RefreshFolder(string path, bool v)
        {
            view.Dispatcher.Invoke(() => { FileDatas = FileDirectory.GetCurrentData(path, true); });
        }

        private void Lv_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var lv = sender as ListView;
            var sitem = ItemsControl.ContainerFromElement(sender as ListView, e.OriginalSource as DependencyObject) as ListViewItem;

            if (sitem == null)
                return;

            System.Drawing.Point pp = MousePoint.GetMousePosition(view);

            ShellContextMenu ctxMnu = new ShellContextMenu();
            FileInfo[] arrFI = new FileInfo[this.view.lv.SelectedItems.Count];

            int i = 0;
            foreach (FileData file in this.view.lv.SelectedItems)
            {
                arrFI[i] = new FileInfo(file.FullName);
                i++;
            }
            if (arrFI.Length == 0)
                arrFI[0] = new FileInfo(CurrentFile.FullName);

            ctxMnu.ShowContextMenu(arrFI, pp);
        }

        private void Lv_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Lv_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(App.Current.MainWindow);
            MousePosition = new System.Drawing.Point((int)p.X, (int)p.Y);
        }



        private void Lv_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {



            //System.Windows.Point p = e.GetPosition(lv);
            //double pixelWidth = lv.Width;
            //double pixelHeight = lv.Height;
            //double x = pixelWidth * p.X / lv.ActualWidth;
            //double y = pixelHeight * p.Y / lv.ActualHeight;
            //MessageBox.Show(x + ", " + y);
        }

        private void BtnCloseTab_Click(object sender, RoutedEventArgs e)
        {
            view.TabItemClosed.Invoke(view, e);
            //if (MessageBox.Show("Really?", "Notice", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            //{
            //    view.TabItemClosed.Invoke(view, e);
            //}

        }

        private void ExplorerChanged(ExplorerViewModel myExplorerViewModel, FileData currentFile)
        {
            //
        }

        private void BtnCopyTab_Click(object sender, RoutedEventArgs e)
        {
            view.NewTabItemClick.Invoke(this.view, e);
        }

        private void BtnCMD_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo("cmd");
            info.WorkingDirectory = CurrentFile.FullName;
            Process proc = new Process();
            proc.StartInfo = info;
            proc.Start();
        }

        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            var popUndo = UndoList.Pop();
            RedoList.Push(popUndo);
            CurrentFile = UndoList.Pop();
            UndoList.Push(CurrentFile);

            FileDatas = FileDirectory.GetCurrentData(CurrentFile.FullName, true);
            SetUndoRedoStatus();
        }

        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            CurrentFile = RedoList.Pop();
            UndoList.Push(CurrentFile);
            FileDatas = FileDirectory.GetCurrentData(CurrentFile.FullName, true);
            ExplorerChanged(this, CurrentFile);
            SetUndoRedoStatus();
        }

        private void BtnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            var parent = Directory.GetParent(CurrentFile.FullName);
            CurrentFile = new FileData { FullName = parent.FullName };


            RedoList.Clear();
            UndoList.Push(CurrentFile);

            FileDatas = FileDirectory.GetCurrentData(CurrentFile.FullName, true);
            SetUndoRedoStatus();
        }

        void SetUndoRedoStatus()
        {
            IsUndoEnabled = UndoList.Count == 1 ? false : true;
            IsRedoEnabled = RedoList.Count == 0 ? false : true;

            var parent = Directory.GetParent(CurrentFile.FullName);

            if (parent == null)
            {
                IsMoveUpEnabled = false;
            }
            else
            {
                IsMoveUpEnabled = true;
            }

            if (FileWatcher != null)
                FileWatcher.ChangeWatchPath(CurrentFile.FullName);
        }

        private void Lv_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = view.lv.SelectedItem as FileData;
            if (item != null)
            {
                CurrentFile = item;
                if (CurrentFile.FileType == FileTypes.Directory || CurrentFile.FileType == FileTypes.Parent
                    || CurrentFile.FileType == FileTypes.HiddenDirectory)
                {
                    var newData = FileDirectory.GetCurrentData(CurrentFile.FullName, true);
                    if (newData.Count == 0 && FileDirectory.IsError == true)
                    {
                        MessageBox.Show(FileDirectory.ErrorMessage);
                        return;
                    }
                    FileDatas = newData;
                    UndoList.Push(CurrentFile);
                    RedoList.Clear();
                    ExplorerChanged(this, CurrentFile);
                    SetUndoRedoStatus();
                }
                else if (CurrentFile.FileType == FileTypes.File)
                {
                    Process.Start(CurrentFile.FullName);
                }
            }
        }
    }
}
