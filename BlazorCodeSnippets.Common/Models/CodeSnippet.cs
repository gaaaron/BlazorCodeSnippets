namespace BlazorCodeSnippets.Common.Models
{
    public record CodeSnippet(Guid Id, string Name, string RawValue, string FormattedValue, string? FileName = null);
}
