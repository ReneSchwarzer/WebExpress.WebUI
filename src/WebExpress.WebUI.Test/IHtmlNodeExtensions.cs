using System.Text.RegularExpressions;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.Test
{
    internal static class IHtmlNodeExtensions
    {
        /// <summary>
        /// Removes extra spaces and line breaks from the input node.
        /// </summary>
        /// <param name="node">The node to clean.</param>
        /// <returns>A string with all consecutive spaces and line breaks reduced to single ones.</returns>
        public static string Trim(this IHtmlNode node)
        {
            string withoutExtraSpaces = Regex.Replace(node.ToString().Trim(), @"\s+", " ");
            string withoutExtraLineBreaks = Regex.Replace(withoutExtraSpaces, @"[\r\n]+", "\n");
            string withoutSpacesBetweenBrackets = Regex.Replace(withoutExtraLineBreaks, @">\s+<", "><");

            return withoutSpacesBetweenBrackets;
        }
    }
}
