using Commander.Part.Main.Views;
using System;
using System.Windows;

namespace Commander
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool dialogResult = true;
            MainWindow main;

            while (dialogResult)
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown;
                main = new MainWindow();
                main.ShowDialog();
                dialogResult = (bool)main.DialogResult;
            }

            Environment.Exit(0);
        }
    }
}
