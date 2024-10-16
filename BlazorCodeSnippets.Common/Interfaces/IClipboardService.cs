namespace BlazorCodeSnippets.Common.Interfaces
{
    public interface IClipboardService
    {
        Task Initialize();
        Task CopyTextToClipboard(string text);

        event Action<(string FileName, string Content)>? FilePasted;
        event Action<string>? TextPasted;
    }
}