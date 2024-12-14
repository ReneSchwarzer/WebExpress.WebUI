using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Interface for a control.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Returns or sets the id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        IHtmlNode Render(IRenderControlContext context);
    }
}
