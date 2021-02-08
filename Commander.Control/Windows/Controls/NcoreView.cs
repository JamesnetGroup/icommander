using System.Windows.Controls;
using Commander.Windows.Mvvm;

namespace Commander.Windows.Controls
{
    public class NcoreView : UserControl
    {
        public NcoreView()
        {
            Loaded += RiotView_Loaded;
        }

        private void RiotView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ForceViewLoaded(this);
            }
        }
    }
}
