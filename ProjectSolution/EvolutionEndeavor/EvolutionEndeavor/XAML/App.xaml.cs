using EvolutionEndeavorSystem.Framework;
using EvolutionEndeavorSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EvolutionEndeavorSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// the method that overrides the start up functionality.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Create main window
            MainWindow window = new MainWindow();

            window.DataContext = new LoginViewModel();

            //Show main window
            window.Show();
        }
    }
}
