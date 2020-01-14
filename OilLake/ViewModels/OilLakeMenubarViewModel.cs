using OilLake.Models.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilLake.ViewModels
{
    public class OilLakeMenubarViewModel : BindableBase
    {
        public DelegateCommand OpenNewFile { get; }
        public DelegateCommand OpenNewWindow { get; }
        public DelegateCommand SaveFile { get; }
        public DelegateCommand CloseWindow { get; }
        public DelegateCommand Export { get; }

        public DelegateCommand DisplayAbout { get; }
        public DelegateCommand DisplayLicenses { get; }

        private IFileService _fileService;

        public OilLakeMenubarViewModel(IFileService fileService)
        {
            _fileService = fileService;
        }
    }
}
