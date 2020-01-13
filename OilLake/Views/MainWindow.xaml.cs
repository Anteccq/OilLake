using System;
using System.Windows;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using OilLake.ViewModels;

namespace OilLake.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowsXamlHostBase_OnChildChanged(object sender, EventArgs e)
        {
            var host = (WindowsXamlHost) sender;
            var control = host.Child as OilLakeUI.UI.TextTabView;
            if (control != null) control.DataContext = ((MainWindowViewModel)DataContext).TabViewModel;
        }
    }
}
