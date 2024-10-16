using BlazorCodeSnippets.Common;
using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorCodeSnippets
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Services
            builder.Services.AddCommonServices();
            builder.Services.AddFileDownloadService();
            builder.Services.AddSingleton<ICopyFileService, CopyFileService>();

            var host = builder.Build();

            await Seed(host.Services);
            await host.RunAsync();
        }

        private static async Task Seed(IServiceProvider serviceProvider)
        {
            var snippetService = serviceProvider.GetRequiredService<ISnippetService>();

            var defaultFolder = snippetService.AddFolder("1 Default");
            snippetService.AddFolder("2 .NET");
            snippetService.AddFolder("2.1 ASP.NET");
            snippetService.AddFolder("2.2 Blazor");
            snippetService.AddFolder("3 HTML");
            snippetService.AddFolder("4 C#");

            await snippetService.AddSnippet(defaultFolder.Id, "index.html", "<html></html>");
            await snippetService.AddSnippet(defaultFolder.Id, "app.css", "body { background-color: black; }");
        }
    }
}