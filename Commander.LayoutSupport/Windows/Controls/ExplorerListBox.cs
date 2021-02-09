using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Commander.Data.File;
using Commander.WindowsBase.Windows.InputSupport;
using Commander.WindowsReference.OperationSystem.Windows;

namespace Commander.Windows.Controls.Primitives
{
    public class ExplorerListBox : ListBox
    {
        #region DependencyProperty

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(ExplorerListBox));
        #endregion

        #region Command

        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }
        #endregion

        #region OnMouseRightButtonUp

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonUp(e);

            List<FileInfo> files;
            ShellContextMenu ctx;

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext is FileData)
            {
                files = new List<FileInfo>();
                ctx = new ShellContextMenu();

                // TODD James: Linq AddRange
                files.AddRange(from FileData file in this.SelectedItems select new FileInfo(file.FullName));
                ctx.ShowContextMenu(files.ToArray(), MousePosition.GetMousePosition(this));
            }
        }
        #endregion
    }
}
