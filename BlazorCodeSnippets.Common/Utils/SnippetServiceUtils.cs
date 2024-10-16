using BlazorCodeSnippets.Common.Interfaces;
using BlazorCodeSnippets.Common.Models;
using System.Text.RegularExpressions;

namespace BlazorCodeSnippets.Common.Utils
{
    public static class SnippetServiceUtils
    {
        private static Regex _numberRegex = new Regex(@"^(([A-Z]|[0-9])(\.[0-9])*)");

        public static bool ShowFolder(this ISnippetService snippetService, SnippetFolder folder, Guid? activeFolderId)
        {
            return folder.IsTopLevel() || (activeFolderId != null && 
                folder.IsChildrendOrSiblingOf(activeFolderId.Value, snippetService));
        }

        public static bool IsTopLevel(this SnippetFolder folder)
        {
            var result = GetSequenceNumber(folder.Name) == GetTopSequenceNumber(folder.Name);
            return result;
        }

        private static bool IsChildrendOrSiblingOf(this SnippetFolder folder, Guid otherFolderId, ISnippetService snippetService)
        {
            var otherFolder = snippetService.GetFolder(otherFolderId);

            var result = GetTopSequenceNumber(otherFolder.Name) == GetTopSequenceNumber(folder.Name);
            return result;
        }

        private static string? GetTopSequenceNumber(string name)
        {
            var numberPart = GetSequenceNumber(name);
            // 1.1
            var firstNumber = numberPart?.Split('.')?.FirstOrDefault();
            // 1
            return firstNumber;
        }

        private static string? GetSequenceNumber(string name)
        {
            var match = _numberRegex.Match(name);
            if (match.Success)
            {
                var numberGroup = match.Groups[0].Value;
                return numberGroup;
            }

            return null;
        }
    }
}
