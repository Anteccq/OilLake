using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using Reactive.Bindings;

namespace OilLake.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> MarkdownText { get; } = new ReactiveProperty<string>();
    }
}
