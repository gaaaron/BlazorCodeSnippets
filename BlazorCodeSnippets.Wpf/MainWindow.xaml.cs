using BlazorCodeSnippets.Common;
using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Wpf.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BlazorCodeSnippets.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/wpf?view=aspnetcore-7.0
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddCommonServices();
            serviceCollection.AddSingleton<ICopyFileService, CopyFileService>();
            serviceCollection.AddSingleton<IFileDownloadService, FileDownloadService>();

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
