using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a button control within a list item.
    /// </summary>
    /// <remarks>
    /// This control is used to create a button element within a list item, 
    /// allowing for interactive list items.
    /// </remarks>
    public class ControlListItemButton : ControlListItem
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlListItemButton(string id = null, params IControl[] content)
            : base(id, content)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return new HtmlElementFieldButton(Content.Select(x => x.Render(renderContext, visualTree)).ToArray())
            {
                Id = Id,
                Class = Css.Concatenate("list-group-item-action", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
