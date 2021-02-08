using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Commander.Windows.Controls
{
    public class NcoreExploer : UserControl
    {
        //private MyExplorerViewModel vm;

        //public Action<object, RoutedEventArgs> NewTabItemClick = (s, e) => { };
        //public Action<object, RoutedEventArgs> TabItemClosed = (s, e) => { };
        //public Action<object, FileData> FileClick = (s, e) => { };

        //public FileData CurrentFile
        //{
        //    get { return vm.CurrentFile; }
        //}

        //public MyExplorer(string path)
        //{
        //    InitializeComponent();

        //    vm = new MyExplorerViewModel(this);
        //    vm.InitViewModel(path);
        //    vm.InitFileAsync();
        //    DataContext = vm;
        //}

        //private void lv_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.F2)
        //    {
        //        var item = lv.SelectedItem as FileData;
        //        if (item == null) return;
        //        foreach (var i in vm.FileDatas)
        //        {
        //            i.IsEditMode = false;
        //        }
        //        item.IsEditMode = true;
        //        lv.Items.Refresh();
        //    }
        //    else if (e.Key == Key.F5)
        //    {
        //        (sender as ListView).Items.Refresh();
        //    }
        //    else if (e.Key == Key.Enter)
        //    {
        //        vm.Enter();
        //    }
        //    else if (e.Key == Key.Back)
        //    {
        //        vm.EEscapesc();
        //    }
        //}
    }
}
