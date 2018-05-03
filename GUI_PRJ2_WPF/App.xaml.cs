using GUI_PRJ2;
using GUI_PRJ2_Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_PRJ2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom Start up so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let the base application do what it needs
            base.OnStartup(e);

            //Setup IoC
            IoC.Setup();

            //Show Main Window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
