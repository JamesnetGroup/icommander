using System.Windows.Controls;

namespace Commander.Windows.Controls
{

	public class ExplorerTabControl : TabControl
    {
        //public Action<object> Closed;
        //public Action<object> TabAdded;

        //public ExplorerTabControl()
        //{
        //    //Style = App.Current.FindResource("TAB_EXPLORER") as Style;
        //}

        //public void ItemsAdd(object sender, RoutedEventArgs e)
        //{
        //    var exp = sender as NcoreExploer;
        //    ItemsAdd("New", exp.CurrentFile.FullName);
        //}

        //public void ItemsAdd(string header, string Location = "")
        //{
        //    var newTab = new TabItem();
        //    //newTab.Style = App.Current.FindResource("TABITEM_EXPLORER") as Style;
        //    newTab.Header = string.Format(GetLastDirectory(Location));

        //    var explorer = new NcoreExploer(Location);
        //    newTab.Content = explorer;
        //    explorer.FileClick += FileClick;
        //    explorer.NewTabItemClick += ItemsAdd;
        //    explorer.TabItemClosed += ItemsRemove;
        //    this.Items.Add(newTab);
        //    newTab.IsSelected = true;

        //    TabAdded.Invoke(this);
        //}

        //private void FileClick(object obj, FileData sitem)
        //{
        //    var tabItem = (obj as NcoreExploer).Parent as TabItem;
        //    tabItem.Header = GetLastDirectory(sitem.FullName);
        //}

        //private string GetLastDirectory(string location)
        //{
        //    return Path.GetFileName(location) == "" ? location : Path.GetFileName(location);
        //}

        //private void ItemsRemove(object sender, RoutedEventArgs e)
        //{
        //    this.Items.Remove((sender as NcoreExploer).Parent);

        //    if (this.Items.Count == 0)
        //    {
        //        Closed.Invoke(this);
        //    }
        //}
    }
}