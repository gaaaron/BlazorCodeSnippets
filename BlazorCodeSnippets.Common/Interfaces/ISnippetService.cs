using BlazorCodeSnippets.Common.Models;

namespace BlazorCodeSnippets.Common.Interfaces
{
    public interface ISnippetService
    {
        event Action? FoldersChanged;
        event Action? SnippetsChanged;

        SnippetFolder AddFolder(string folderName, List<CodeSnippet>? snippets = null);
        void Update(SnippetFolder snippetFolder);
        void Delete(SnippetFolder snippetFolder);
        SnippetFolder GetFolder(Guid folderId);
        IEnumerable<SnippetFolder> GetAllFolder();

        Task<CodeSnippet> AddSnippet(Guid folderId, string name, string value, string? fileName = null);
        void Update(CodeSnippet snippet);
        void Delete(CodeSnippet snippet);
        CodeSnippet GetSnippet(Guid id);
        IEnumerable<CodeSnippet> Query(Guid folderId);

        void ImportFromJson(string serializedData);
        string ExportToJson();
    }
}