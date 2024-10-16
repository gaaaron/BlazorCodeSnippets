using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Common.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Text;

namespace BlazorCodeSnippets.Common.Services
{
    internal class FileDownloadService : IFileDownloadService
    {
        private IServiceProvider _serviceProvider;

        public FileDownloadService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Download(string fileContent)
        {
            var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
            await jsRuntime.DownloadFileFromStream( stream);
        }
    }
}
