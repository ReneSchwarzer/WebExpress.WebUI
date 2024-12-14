using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a header item in a dropdown control.
    /// </summary>
    public class ControlDropdownItemHeader : Control, IControlDropdownItem
    {
        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlDropdownItemHeader(string id = null)
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
            return new HtmlElementTextContentLi(new HtmlText(I18N.Translate(renderContext.Request.Culture, Text)))
            {
                Id = Id,
                Class = Css.Concatenate("dropdown-header", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
