using OilLake.Models.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using OilLake.Models;
using OilLake.Views;
using Reactive.Bindings;

namespace OilLake.ViewModels
{
    public class OilLakeMenubarViewModel : BindableBase
    {
        public DelegateCommand OpenNewFile { get; set; }
        public DelegateCommand OpenNewWindow { get; set; }
        public DelegateCommand SaveFile { get; set; }
        public DelegateCommand SaveNewFile { get; set; }
        public DelegateCommand CloseWindow { get; set; }
        public DelegateCommand<string> Export { get; set; }

        public DelegateCommand DisplayAbout { get; }
        public DelegateCommand DisplayLicenses { get; }

        private IFileService _fileService;
        private IFileExportService _fileExportService;

        public OilLakeMenubarViewModel(IFileService fileService, IFileExportService fileExportService)
        {
            _fileService = fileService;
            _fileExportService = fileExportService;
            DisplayLicenses = new DelegateCommand(async () =>
            {
                var dialog = new OilLakeUI.UI.LicenseDialog();
                dialog.XamlRoot = MainWindow.Root;
                var result = await dialog.ShowAsync();
            });
            DisplayAbout = new DelegateCommand(async () =>
            {
                var dialog = new OilLakeUI.UI.AboutDialog();
                dialog.XamlRoot = MainWindow.Root;
                var result = await dialog.ShowAsync();
            });
        }
    }
}
