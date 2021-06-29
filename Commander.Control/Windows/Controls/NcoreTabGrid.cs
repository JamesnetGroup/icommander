using System.Windows.Controls;

namespace Commander.Windows.Controls
{
	public class TabGrid : Grid
    {
        //List<ExplorerTabControl> TabChildren;
        //public ExplorerTabControl CurrentTab;

        //public TabGrid()
        //{
        //    TabChildren = new List<ExplorerTabControl>();
        //}


        //internal void ItemsAdd(ExplorerTabControl tab = null)
        //{
        //    this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        //    if (tab == null)
        //    {
        //        tab = new ExplorerTabControl();
        //        tab.TabAdded += Explorer_TabAdded;
        //        tab.ItemsAdd("NewTab", @"C:\");
        //        Grid.SetColumn(tab, TabChildren.Count);
        //        tab.Closed += TabClosed;
        //        TabChildren.Add(tab);
        //    }
        //    else
        //    {
        //        this.Children.Remove(tab);
        //        Grid.SetColumn(tab, int.Parse(tab.Tag.ToString()));
        //    }
        //    this.Children.Add(tab);
        //}

        //internal void CurrentTabAdd()
        //{
        //    foreach (var item in TabChildren)
        //    {
        //        foreach (TabItem titem in item.Items)
        //        {
        //            if (titem.IsSelected == true
        //                && titem.IsKeyboardFocusWithin == true)
        //            {
        //                item.ItemsAdd("New", @"C:\");
        //                return;
        //            }
        //        }
        //    }
        //}

        //private void Explorer_TabAdded(object obj)
        //{
        //    CurrentTab = obj as ExplorerTabControl;
        //}

        //private void TabClosed(object obj)
        //{
        //    TabChildren.Remove(obj as ExplorerTabControl);
        //    this.ColumnDefinitions.Clear();
        //    this.Children.Clear();

        //    for (int i = 0; i < TabChildren.Count; i++)
        //    {
        //        TabChildren[i].Tag = i;
        //        ItemsAdd(TabChildren[i]);
        //    }
        //}
    }
}