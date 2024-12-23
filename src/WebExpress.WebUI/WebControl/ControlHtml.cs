using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents an HTML control that can render raw HTML content.
    /// </summary>
    public class ControlHtml : Control
    {
        /// <summary>
        /// Retruns or sets the html source code.
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="value">The text.</param>
        public ControlHtml(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var html = new HtmlRaw
            {
                Html = Html
            };

            return html;
        }
    }
}
