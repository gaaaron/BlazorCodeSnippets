using BlazorCodeSnippets.Common.Interfaces;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace BlazorCodeSnippets.Wpf.Services
{
    internal class CopyFileService : ICopyFileService
    {
        public bool IsSupported => true;

        public void CopyFileToClipboard(string fileName, string fileContent)
        {
            var tempPath = Path.GetTempPath();
            var filePath = Path.Combine(tempPath, fileName);
            File.WriteAllText(filePath, fileContent);

            var paths = new StringCollection() { filePath };
            Clipboard.SetFileDropList(paths);
        }
    }
}
