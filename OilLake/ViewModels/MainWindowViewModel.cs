using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Win32;
using OilLake.Models;
using OilLake.Models.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Markdig;
using System.Windows.Media;

namespace OilLake.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public TextTabViewModel TabViewModel { get; } = new TextTabViewModel();

        public OilLakeMenubarViewModel OilLakeMenubarViewModel { get; }

        public Control Control { get; set; }

        private IFileService _fileService;
        private IFileExportService _fileExportService;

        public MainWindowViewModel(IFileService fileService, IFileExportService fileExportService)
        {
            _fileService = fileService;
            _fileExportService = fileExportService;
            OilLakeMenubarViewModel = new OilLakeMenubarViewModel(fileService, fileExportService)
            {
                SaveFile = new DelegateCommand(async () => await SaveAsync(TabViewModel.SelectFileData)),
                SaveNewFile = new DelegateCommand(async () => await SaveNewAsync(TabViewModel.SelectFileData)),
                OpenNewFile = new DelegateCommand(() => TabViewModel.ItemCollection.Add(new MarkdownViewModel(FileData.DefaultData))),
                Export = new DelegateCommand<string>(async (str) =>
                {
                    if (Enum.TryParse(str, out FileType fileType) && Enum.IsDefined(typeof(FileType), fileType))
                        await ExportAsync(TabViewModel.SelectFileData, fileType);
                }),
                CloseWindow = new DelegateCommand(() => App.Current.Shutdown())
            };
        }

        private async Task SaveAsync(FileData fileData)
        {
            if(fileData == null) return;
            if (fileData.Path == null)
            {
                await SaveNewAsync(fileData);
            }
            else
            {
                await _fileService.SaveDataAsync(fileData);
            }
        }

        private async Task SaveNewAsync(FileData fileData)
        {
            if (fileData == null) return;
            var saveFileDialog = new SaveFileDialog { Filter = "Markdown(.md)|*.md" };
            var result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                fileData.Path = saveFileDialog.FileName;
                await _fileService.SaveDataAsync(fileData);
            }
        }

        private async Task ExportAsync(FileData fileData, FileType fileType)
        {
            if(fileData == null) return;
            object exportData;
            exportData = fileType switch
            {
                FileType.PowerPoint => new PptxFileData(fileData, "Presentation Title", "Made by OilLake"),
                FileType.Html => Markdown.ToHtml(fileData.Content),
                _ => new object()
                //FileType.Pdf => 
            };
            var saveFileDialog = new SaveFileDialog { Filter = FilterString(fileType) };
            var result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                var path = saveFileDialog.FileName;
                await _fileExportService.ExportAsync(path, exportData, fileType);
            }
        }

        private string FilterString(FileType fileType)
        {
            return fileType switch
            {
                FileType.Html => "HTML File(.html)|*.html",
                FileType.PowerPoint => "PowerPoint File(.pptx)|*.pptx",
                FileType.Pdf => "PDF File(.pdf)|*.pdf",
                _ => "Markdown(.md)|*.md"
            };
        }
    }
}