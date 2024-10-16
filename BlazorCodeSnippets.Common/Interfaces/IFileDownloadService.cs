namespace BlazorCodeSnippets.Common.Interfaces
{
    public interface IFileDownloadService
    {
        Task Download(string fileContent);
    }
}
