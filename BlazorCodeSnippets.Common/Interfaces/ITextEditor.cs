namespace BlazorCodeSnippets.Common.Interfaces
{
    public interface ITextEditor
    {
        Task<string> EditText(string popupTitle, string? originalText = null, string? validationRegex = null);
    }
}
