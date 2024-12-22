using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control panel tool that can contain multiple tools.
    /// </summary>
    public class ControlPanelTool : ControlPanel
    {
        /// <summary>
        /// Returns the tools.
        /// </summary>
        public ControlDropdown Tools { get; } = new ControlDropdown();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelTool(string id = null, params Control[] items)
            : base(id, items)
        {
            Border = new PropertyBorder(true);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var dropDown = Tools.Render(renderContext);
            var content = new HtmlElementTextContentDiv(Content.Select(x => x.Render(renderContext)).ToArray());

            var html = new HtmlElementTextContentDiv(dropDown, content)
            {
                Id = Id,
                Class = Css.Concatenate("toolpanel", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            return html;
        }
    }
}
