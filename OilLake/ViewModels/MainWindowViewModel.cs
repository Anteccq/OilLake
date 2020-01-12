using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using OilLake.Models;
using OilLake.Models.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Unity;

namespace OilLake.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public TextTabViewModel TabViewModel { get; } = new TextTabViewModel();

        private DelegateCommand SaveFileCommand { get; }
        private DelegateCommand LoadFileCommand { get; }

        private IFileService _fileService;

        public MainWindowViewModel(IFileService fileService)
        {
            _fileService = fileService;
            SaveFileCommand = new DelegateCommand(() => _fileService.SaveDataAsync(null));
        }
    }
}