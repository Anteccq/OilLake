using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Text;
using OilLake.Models;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace OilLake.ViewModels
{
    public class MarkdownViewModel : BindableBase
    {
        public FileData FileData { get; set; }
        public ReadOnlyReactiveProperty<string> Title { get; }
        public ReadOnlyReactiveProperty<string> Content { get; }

        public MarkdownViewModel(FileData fileData)
        {
            FileData = fileData;
            Title = FileData.ObserveProperty(x => x.Path)
                .Select(x => Path.GetFileName(x) ?? "NoTitle" )
                .ToReadOnlyReactiveProperty();
            Content = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000))
                .Select(_ => FileData.Content)
                .Where(x => x != Content?.Value)
                .ToReadOnlyReactiveProperty();
        }
    }
}
