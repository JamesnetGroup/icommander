using Commander.Data.File;
using Commander.WindowsBase.Windows.InputSupport;
using Commander.WindowsReference.OperationSystem.Windows;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Commander.Windows.Controls.Primitives
{
    public class ExplorerListBox : ListBox
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
       "Command", typeof(ICommand), typeof(ExplorerListBox));
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext is FileData data)
            {
                FileData FileData = data;

                ShellContextMenu ctxMnu = new ShellContextMenu();
                FileInfo[] arrFI = new FileInfo[this.SelectedItems.Count];

                int i = 0;
                foreach (FileData file in this.SelectedItems)
                {
                    arrFI[i] = new FileInfo(file.FullName);
                    i++;
                }
                if (arrFI.Length == 0)
                {
                    arrFI[0] = new FileInfo(FileData.FullName);
                }
                ctxMnu.ShowContextMenu(arrFI, MousePosition.GetMousePosition(this));

                Command?.Execute(e);
            }
        }
    }
}
