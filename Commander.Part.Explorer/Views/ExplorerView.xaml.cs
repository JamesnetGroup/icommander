using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Commander.Part.Explorer.ViewModels;
using Commander.Part.Explorer.ViewModels.Temps;
using Commander.Windows.Controls;

namespace Commander.Part.Explorer.Views
{
    public partial class ExplorerView : NcoreView
    {
        ExplorerViewModel vm;
        public Action<object, RoutedEventArgs> NewTabItemClick = (s, e) => { };
        public Action<object, RoutedEventArgs> TabItemClosed = (s, e) => { };
        public Action<object, FileData> FileClick = (s, e) => { };

        public FileData CurrentFile
        {
            get { return vm.CurrentFile; }
        }

        public ExplorerView()
        {
            InitializeComponent();

            string path = @"C:\ncoresoft";
            vm = new ExplorerViewModel(this);
            vm.InitViewModel(path);
            vm.InitFileAsync();
            DataContext = vm;
        }

        private void lv_PreviewKeyDown(object sender, KeyEventArgs e)
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
