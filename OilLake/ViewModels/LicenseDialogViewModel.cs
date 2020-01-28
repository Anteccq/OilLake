using System;
using System.Collections.Generic;
using System.Text;
using OilLake.Models.Interfaces;
using Prism.Mvvm;
using Reactive.Bindings;

namespace OilLake.ViewModels
{
    public class LicenseDialogViewModel : BindableBase
    {
        private string _licenseText = "";
        public string LicenseText { get; set;}

        private IFileService _fileService;

        public LicenseDialogViewModel(IFileService fileService)
        {
            _fileService = fileService;
        }
    }
} 
