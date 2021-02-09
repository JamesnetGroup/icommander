using System;
using System.Windows.Input;
using Commander.Data.File;
using Commander.Part.Explorer.ViewModels;
using Commander.Windows.Controls;

namespace Commander.Part.Explorer.Views
{
    public partial class ExplorerView : NcoreView
    {
        readonly ExplorerViewModel vm;
        public Action<object> NewTabItemClick = (s) => { };
        public Action<object> TabItemClosed = (s) => { };
        public Action<object, FileData> FileClick = (s, e) => { };

        public FileData CurrentFile
        {
            get { return vm.FileData; }
        }

        public ExplorerView()
        {
            InitializeComponent();

            vm = new ExplorerViewModel(this);
            DataContext = vm;
        }

        private void Lv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.F2)
            //{
            //    var item = lv.SelectedItem as FileData;
            //    if (item == null) return;
            //    foreach (var i in vm.FileDatas)
            //    {
            //        i.IsEditMode = false;
            //    }
            //    item.IsEditMode = true;
            //    lv.Items.Refresh();
            //}
            //else if (e.Key == Key.F5)
            //{
            //    (sender as ListView).Items.Refresh();
            //}
            //else if (e.Key == Key.Enter)
            //{
            //    vm.Enter();
            //}
            //else if (e.Key == Key.Back)
            //{
            //    vm.EEscapesc();
            //}
        }
    }
}
