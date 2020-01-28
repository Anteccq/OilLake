using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OilLake.Models;
using OilLake.Models.Interfaces;
using OilLake.Views;
using Prism.Mvvm;
using Unity;

namespace OilLake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer Container { get; } = new UnityContainer();
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(x => this.Container.Resolve(x));
            this.Container.RegisterType<IFileService, FileManager>();
            this.Container.RegisterType<IFileExportService, FileExportManager>();
            this.Container.Resolve<MainWindow>().Show();
        }
    }
}
