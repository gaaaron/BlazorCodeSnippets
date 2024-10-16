using BlazorCodeSnippets.Common;
using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Maui.Platforms.Windows.Services;

namespace BlazorCodeSnippets.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddCommonServices();
            builder.Services.AddFileDownloadService();
            builder.Services.AddSingleton<ICopyFileService, CopyFileService>();

            return builder.Build();
        }
    }
}