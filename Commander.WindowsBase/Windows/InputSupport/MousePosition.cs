using dr = System.Drawing;
using System.Windows;
using System.Windows.Input;

namespace Commander.WindowsBase.Windows.InputSupport
{
    public class MousePosition
    {
        public static dr.Point GetMousePosition(UIElement ui)
        {
            Point p = Mouse.GetPosition(Window.GetWindow(ui));
            var ppp = Window.GetWindow(ui).PointToScreen(p);
            dr.Point pp = new dr.Point((int)ppp.X, (int)ppp.Y);

            return pp;
        }
    }
}
