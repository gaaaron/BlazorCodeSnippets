namespace BlazorCodeSnippets.Common.Interfaces
{
    public interface ICopyFileService
    {
        bool IsSupported { get; }
        void CopyFileToClipboard(string fileName, string fileContent);
    }
}
