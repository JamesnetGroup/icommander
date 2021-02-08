using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Commander.Windows.Mvvm
{
    public class ObservableObject : INotifyPropertyChanged
    {
        protected UIElement View;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ForceLoaded(UIElement view)
        {
            View = view;
            OnLoaded();
        }

        public void ForceViewLoaded(UIElement view)
        {
            View = view;
            OnViewLoaded();
        }

        protected virtual void OnLoaded()
        {

        }

        protected virtual void OnViewLoaded()
        {

        }
    }
}