using System;
using System.Windows;
using Microsoft.Toolkit.Wpf.UI.XamlHost;

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
            if (host.Child is OilLakeUI.UI.TextTabView control) control.DataContext = DataContext;
        }
    }
}
