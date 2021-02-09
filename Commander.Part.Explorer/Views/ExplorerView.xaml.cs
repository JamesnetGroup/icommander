using System;
using System.Windows.Input;
using Commander.Data.File;
using Commander.Part.Explorer.ViewModels;
using Commander.Windows.Controls;

namespace Commander.Part.Explorer.Views
{
    public partial class ExplorerView : NcoreView
    {
        public ExplorerView()
        {
            InitializeComponent();
            DataContext = new ExplorerViewModel();
        }
    }
}
