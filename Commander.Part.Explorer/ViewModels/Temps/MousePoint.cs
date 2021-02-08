using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Commander.OperationSystem.Screen
{
    public class MousePoint
    {
        public static System.Drawing.Point GetMousePosition(UIElement ui)
        {
            System.Windows.Point p = Mouse.GetPosition(Window.GetWindow(ui));
            var ppp = Window.GetWindow(ui).PointToScreen(p);
            System.Drawing.Point pp = new System.Drawing.Point((int)ppp.X, (int)ppp.Y);

            return pp;
        }
    }
}
