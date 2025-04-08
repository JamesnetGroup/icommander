using Commander.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Commander.Part.Main.Views
{
	public partial class MainWindow : NcoreWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Thumb ResizeButton { get; private set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ResizeButton = this.Template.FindName("PART_Resize", this) as Thumb;
            ResizeButton.DragDelta += OnDragDelta;
        }

        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            var yadjust = this.Height + e.VerticalChange;
            var xadjust = this.Width + e.HorizontalChange;
            if ((xadjust >= 0) && (yadjust >= 0))
            {
                this.Width = xadjust;
                this.Height = yadjust;
            }
        }
    }
}
