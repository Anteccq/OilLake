using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using OilLake.Models;
using Prism.Mvvm;
using Reactive.Bindings;

namespace OilLake.ViewModels
{
    public class TextTabViewModel : BindableBase
    {
        public ICollection<MarkdownViewModel> ItemCollection { get; }

        public ReactiveProperty<int> SelectIndex { get; } = new ReactiveProperty<int>();

        public TextTabViewModel(params FileData[] defaultDatas)
        {
            var dataArray = defaultDatas.Length != 0 ? defaultDatas : new[]{FileData.DefaultData};
            ItemCollection = new ObservableCollection<MarkdownViewModel>(dataArray.Select(data => new MarkdownViewModel(data)).ToArray());
            MessageBox.Show(ItemCollection.Count.ToString());
        }
    }
}
