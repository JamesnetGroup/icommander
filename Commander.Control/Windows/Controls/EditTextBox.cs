using System.Windows;
using System.Windows.Controls;

namespace Commander.Windows.Controls
{
    public class EditTextBox : TextBox
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string),
            typeof(EditTextBox), new PropertyMetadata(string.Empty, Changed));
        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as EditTextBox;
            // now, do something

            if (c.Title.ToUpper() == "TRUE")
            {
                c.Visibility = Visibility.Visible;
                c.Focus();
                c.SelectAll();
            }
            else
            {
                c.Visibility = Visibility.Collapsed;
            }
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            Visibility = Visibility.Collapsed;
        }
    }
}
