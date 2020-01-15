using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Reactive.Bindings;

// ユーザー コントロールの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234236 を参照してください

namespace OilLakeUI.UI
{
    public sealed partial class PresentationDialog : ContentDialog
    {
        public string TitleText { get; private set; }
        public string SubTitleText { get; private set; }
        public PresentationDialog()
        {
            this.InitializeComponent();
            this.PrimaryButtonClick += (a, e) =>
            {
                TitleText = this.pptxTitleText.Text;
                SubTitleText = this.pptxSubTitleText.Text;
            };
        }
    }
}
