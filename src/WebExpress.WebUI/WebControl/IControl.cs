using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public interface IControl
    {
        /// <summary>
        /// Returns or sets the id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        IHtmlNode Render(RenderContext context);
    }
}
