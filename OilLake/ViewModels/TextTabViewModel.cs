using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using OilLake.Models;
using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;

namespace OilLake.ViewModels
{
    public class TextTabViewModel : BindableBase
    {
        public ObservableCollection<MarkdownViewModel> ItemCollection { get; set; }

        public static ObservableCollection<MarkdownViewModel> ItemCollections { get; set; }

        public ReactiveProperty<int> SelectIndex { get; } = new ReactiveProperty<int>();

        public FileData SelectFileData => ItemCollection[SelectIndex.Value]?.FileData;

        public TextTabViewModel(params FileData[] defaultDatas)
        {
            var dataArray = defaultDatas.Length != 0 ? defaultDatas : new[]{FileData.DefaultData, FileData.DefaultData};
            var dropFileCommand = new DelegateCommand<MarkdownViewModel>((model) => ItemCollection.Remove(model));
            ItemCollection = new ObservableCollection<MarkdownViewModel>(dataArray.Select(data => new MarkdownViewModel(data)).ToArray());
            ItemCollections = ItemCollection;
        }
    }
}
