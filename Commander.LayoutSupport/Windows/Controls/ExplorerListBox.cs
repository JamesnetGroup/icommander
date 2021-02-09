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

        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register("DoubleClickCommand", typeof(ICommand), typeof(ExplorerListBox));
        public static readonly DependencyProperty PreviewKeyDownCommandProperty = DependencyProperty.Register("PreviewKeyDownCommand", typeof(ICommand), typeof(ExplorerListBox));
        #endregion

        #region DoubleClickCommand

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)this.GetValue(DoubleClickCommandProperty); }
            set { this.SetValue(DoubleClickCommandProperty, value); }
        }
        #endregion

        #region PreviewKeyDownCommand

        public ICommand PreviewKeyDownCommand
        {
            get { return (ICommand)this.GetValue(PreviewKeyDownCommandProperty); }
            set { this.SetValue(PreviewKeyDownCommandProperty, value); }
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

        #region OnMouseDoubleClick

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.OriginalSource is FrameworkElement fe && fe.DataContext is FileData data)
            {
                DoubleClickCommand?.Execute(data);

            }
        }
        #endregion

        #region OnPreviewKeyDown

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            PreviewKeyDownCommand?.Execute(e);
        }
        #endregion
    }
}
