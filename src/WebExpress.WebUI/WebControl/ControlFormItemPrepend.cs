using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a form item that is prepended to an input group.
    /// </summary>
    public class ControlFormItemPrepend : ControlFormItemPanel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlFormItemPrepend(string id = null, params Control[] content)
            : base(id, content)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            Classes.Add("input-group-prepend");
            var html = base.Render(renderContext);

            return html;
        }
    }
}
