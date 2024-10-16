using BlazorCodeSnippets.Common.Interfaces;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;

namespace BlazorCodeSnippets.Wpf.Services
{
    internal class FileDownloadService : IFileDownloadService
    {
        public Task Download(string fileContent)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, fileContent);
            }

            return Task.CompletedTask;
        }
    }
}
