using BlazorCodeSnippets.Common.Interfaces;

namespace BlazorCodeSnippets.Maui.Platforms.Windows.Services
{
    internal class CopyFileService : ICopyFileService
    {
        public bool IsSupported => false;

        public void CopyFileToClipboard(string fileName, string fileContent)
        {
            throw new NotSupportedException();
        }
    }
}
