using BlazorCodeSnippets.Common.Interfaces;

namespace BlazorCodeSnippets.Services
{
    public class CopyFileService : ICopyFileService
    {
        public bool IsSupported => false;

        public void CopyFileToClipboard(string fileName, string fileContent)
        {
            throw new NotSupportedException();
        }
    }
}
