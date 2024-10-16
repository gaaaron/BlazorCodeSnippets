using BlazorCodeSnippets.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorCodeSnippets.Common.Services
{
    public class ClipboardService : IDisposable, IClipboardService
    {
        private bool _initialized;
        private IServiceProvider _serviceProvider;
        private DotNetObjectReference<ClipboardService>? _objectReference;

        public ClipboardService(IServiceProvider serviceProvider)
        {
            _initialized = false;
            _serviceProvider = serviceProvider;
        }

        public event Action<(string FileName, string Content)>? FilePasted;
        public event Action<string>? TextPasted;

        public async Task Initialize()
        {
            if (_initialized)
                return;

            _objectReference = DotNetObjectReference.Create(this);

            var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
            await jsRuntime.InvokeVoidAsync("ClipboardHandler.initialize", _objectReference);

            _initialized = true;
        }

        [JSInvokable]
        public void FilePastedCallback(string fileName, string content)
        {
            FilePasted?.Invoke(new(fileName, content));
        }

        [JSInvokable]
        public void TextPastedCallback(string content)
        {
            TextPasted?.Invoke(content);
        }

        public async Task CopyTextToClipboard(string text)
        {
            var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
            await jsRuntime.InvokeVoidAsync("ClipboardHandler.copyTextToClipboard", text);
        }

        public void Dispose()
        {
            _objectReference?.Dispose();
        }
    }
}
