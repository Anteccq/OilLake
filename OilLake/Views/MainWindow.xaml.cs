using System;
using System.Collections.Generic;
using System.Windows;
using Windows.Storage.Pickers;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using OilLake.ViewModels;
using Windows.UI.Core;

namespace OilLake.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Windows.UI.Xaml.Media.FontFamily segoeFont;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowsXamlHostBase_OnChildChanged(object sender, EventArgs e)
        {
            var host = (WindowsXamlHost) sender;
            if (host.Child is OilLakeUI.UI.TextTabView control)
            {
                control.DataContext = ((MainWindowViewModel)DataContext).TabViewModel;
                control.AllowFocusOnInteraction = true;
            }
        }


        private void Menubar_ChildChanged(object sender, EventArgs e)
        {
            var host = (WindowsXamlHost)sender;
            if (host.Child is OilLakeUI.UI.OilLakeMenubar control) control.DataContext = ((MainWindowViewModel)DataContext).OilLakeMenubarViewModel;
        }

        private void MinimizeButton_ChildChanged(object sender, EventArgs e)
        {
            var child = SenderControl<Windows.UI.Xaml.Controls.Button>(sender);
            if (child == null) return;
            child.FontFamily = segoeFont ??= new Windows.UI.Xaml.Media.FontFamily("Segoe MDL2 Assets");
            child.Content = Char.ConvertFromUtf32(0xE921);
            child.Click += (a, e) => this.WindowState = WindowState.Minimized;
            child.Background = backgroundBrush ??= new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
        }

        private static Windows.UI.Xaml.Media.SolidColorBrush backgroundBrush;

        private void MaxmizeButton_ChildChanged(object sender, EventArgs e)
        {
            var child = SenderControl<Windows.UI.Xaml.Controls.Button>(sender);
            if (child == null) return;
            child.FontFamily = segoeFont ??= new Windows.UI.Xaml.Media.FontFamily("Segoe MDL2 Assets");
            child.Content = Char.ConvertFromUtf32(0xE922);
            child.Click += (a, e) => this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            child.Background = backgroundBrush ??= new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void CloseButton_ChildChanged(object sender, EventArgs e)
        {
            var child = SenderControl<Windows.UI.Xaml.Controls.Button>(sender);
            if (child == null) return;
            child.FontFamily = segoeFont ??= new Windows.UI.Xaml.Media.FontFamily("Segoe MDL2 Assets");
            child.Content = Char.ConvertFromUtf32(0xE8BB);
            child.Click += (a,e) => Application.Current.Shutdown();
            child.Background = backgroundBrush ??= new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
        }

        private T SenderControl<T>(object sender)
            where T : Windows.UI.Xaml.UIElement => ((WindowsXamlHost)sender).Child as T;
    }
}
