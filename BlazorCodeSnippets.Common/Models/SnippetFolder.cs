namespace BlazorCodeSnippets.Common.Models
{
    public record SnippetFolder(Guid Id, string Name, List<CodeSnippet> Snippets);
}
