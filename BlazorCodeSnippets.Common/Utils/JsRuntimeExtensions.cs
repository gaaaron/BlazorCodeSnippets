using Microsoft.JSInterop;
using System.IO;

namespace BlazorCodeSnippets.Common.Utils
{
    public static class JsRuntimeExtensions
    {
        public static async Task<string> GetHighlightedText(this IJSRuntime jSRuntime, string text)
        {
            return await jSRuntime.InvokeAsync<string>("window.getHighlightedText", text);
        }

        public static async Task DownloadFileFromStream(this IJSRuntime jSRuntime, Stream stream)
        {
            using var streamRef = new DotNetStreamReference(stream);
            await jSRuntime.InvokeVoidAsync("downloadFileFromStream", streamRef);
        }
    }
}
