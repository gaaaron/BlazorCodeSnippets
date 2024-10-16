using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCodeSnippets.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<ISnippetService, SnippetService>();
            services.AddScoped<IClipboardService, ClipboardService>();
        }

        public static void AddFileDownloadService(this IServiceCollection services)
        {
            services.AddScoped<IFileDownloadService, FileDownloadService>();
        }
    }
}
