using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Common.Models;
using BlazorCodeSnippets.Common.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace BlazorCodeSnippets.Common.Services
{
    public class SnippetService : ISnippetService
    {
        private List<SnippetFolder> _folders = new List<SnippetFolder>();
        private IServiceProvider _serviceProvider;

        public SnippetService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public event Action? SnippetsChanged;
        public event Action? FoldersChanged;

        public IEnumerable<SnippetFolder> GetAllFolder()
        {
            return _folders.OrderBy(x => x.Name);
        }

        public SnippetFolder AddFolder(string folderName, List<CodeSnippet>? snippets = null)
        {
            var folder = new SnippetFolder(Guid.NewGuid(), folderName, snippets ?? new List<CodeSnippet>());
            _folders.Add(folder);

            FoldersChanged?.Invoke();

            return folder;
        }

        public void Update(SnippetFolder snippetFolder)
        {
            _folders.RemoveAll(x => x.Id == snippetFolder.Id);
            _folders.Add(snippetFolder);

            FoldersChanged?.Invoke();
        }

        public void Delete(SnippetFolder snippetFolder)
        {
            _folders.RemoveAll(x => x.Id == snippetFolder.Id);

            FoldersChanged?.Invoke();
            SnippetsChanged?.Invoke();
        }

        public SnippetFolder GetFolder(Guid folderId)
        {
            var folder = _folders.FirstOrDefault(x => x.Id == folderId);
            if (folder == null)
            {
                throw new NotFoundException();
            }

            return folder;
        }

        public CodeSnippet GetSnippet(Guid id)
        {
            var snippet = _folders.SelectMany(x => x.Snippets).FirstOrDefault(x => x.Id == id);
            if (snippet == null)
            {
                throw new NotFoundException();
            }

            return snippet;
        }

        public IEnumerable<CodeSnippet> Query(Guid folderId)
        {
            var folder = _folders.FirstOrDefault(x => x.Id == folderId);
            if (folder == null)
            {
                throw new NotFoundException();
            }

            return folder.Snippets.OrderBy(x => x.Name);
        }

        public async Task<CodeSnippet> AddSnippet(Guid folderId, string name, string value, string? fileName = null)
        {
            var jsRuntime = _serviceProvider.GetRequiredService<IJSRuntime>();
            var formatted = await jsRuntime.GetHighlightedText(value);
            var snippet = new CodeSnippet(Guid.NewGuid(), name, value, formatted, fileName);

            var folder = _folders.FirstOrDefault(x => x.Id == folderId);
            if (folder == null)
            {
                throw new NotFoundException();
            }

            folder.Snippets.Add(snippet);
            SnippetsChanged?.Invoke();

            return snippet;
        }

        public void Update(CodeSnippet snippet)
        {
            var folder = _folders.FirstOrDefault(x => x.Snippets.Any(x => x.Id == snippet.Id));
            if (folder == null)
            {
                throw new NotFoundException();
            }

            folder.Snippets.RemoveAll(x => x.Id == snippet.Id);
            folder.Snippets.Add(snippet);

            SnippetsChanged?.Invoke();
        }

        public void Delete(CodeSnippet snippet)
        {
            var folder = _folders.FirstOrDefault(x => x.Snippets.Any(x => x.Id == snippet.Id));
            if (folder == null)
            {
                throw new NotFoundException();
            }

            folder.Snippets.RemoveAll(x => x.Id == snippet.Id);

            SnippetsChanged?.Invoke();
        }

        public void ImportFromJson(string serializedData)
        {
            var deserialized = System.Text.Json.JsonSerializer.Deserialize<List<SnippetFolder>>(serializedData);
            if (deserialized == null)
            {
                throw new ApplicationException("Serialization failed!");
            }

            _folders = deserialized;
            FoldersChanged?.Invoke();
        }

        public string ExportToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(_folders);
        }
    }
}
