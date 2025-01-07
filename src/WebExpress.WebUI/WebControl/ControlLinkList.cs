using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control that displays a list of links with optional icons and names.
    /// </summary>
    public class ControlLinkList : Control
    {
        private readonly List<IControlLink> _links = [];

        /// <summary>
        /// Returns or sets the links.
        /// </summary>
        public IEnumerable<IControlLink> Links => _links;

        /// <summary>
        /// Returns or sets the color of the name text.
        /// </summary>
        public PropertyColorText NameColor { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="links">The links to add to the control.</param>
        public ControlLinkList(string id = null, params IControlLink[] links)
            : base(id)
        {
            _links.AddRange(links);
        }

        /// <summary> 
        /// Adds one or more links to the content of the link list control.
        /// </summary> 
        /// <param name="links">The links to add to the content.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple links to the <see cref="Links"/> collection of 
        /// the link list control. It is useful for dynamically constructing the user interface by appending 
        /// various links to the link list content. 
        /// Example usage: 
        /// <code> 
        /// var list = new ControlLinkList(); 
        /// var link1 = new ControlLink { Text = "A" };
        /// var link2 = new ControlLink { Text = "B" };
        /// list.Add(text1, text2);
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControlLink"/> interface.
        /// </remarks>
        public virtual void Add(params IControlLink[] links)
        {
            _links.AddRange(links);
        }

        /// <summary> 
        /// Adds one or more links to the content of the link list control.
        /// </summary> 
        /// <param name="links">The links to add to the content.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple links to the <see cref="Links"/> collection of 
        /// the link list control. It is useful for dynamically constructing the user interface by appending 
        /// various links to the link list content. 
        /// Example usage: 
        /// <code> 
        /// var list = new ControlLinkList(); 
        /// var link1 = new ControlLink { Text = "A" };
        /// var link2 = new ControlLink { Text = "B" };
        /// list.Add(text1, text2);
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControlLink"/> interface.
        /// </remarks>
        public virtual void Add(IEnumerable<IControlLink> links)
        {
            _links.AddRange(links);
        }

        /// <summary>
        /// Removes a link from the content of the link list control.
        /// </summary>
        /// <param name="link">The link to remove from the content.</param>
        /// <remarks>
        /// This method allows removing a specific link from the <see cref="Links"/> collection of 
        /// the link list control.
        /// </remarks>
        public virtual void Remove(IControlLink link)
        {
            _links.Remove(link);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var icon = new HtmlElementTextSemanticsSpan()
            {
                Class = Icon?.ToClass()
            };

            var name = new HtmlElementTextSemanticsSpan(new HtmlText(I18N.Translate(Name)))
            {
                Id = string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}_name",
                Class = NameColor?.ToClass()
            };

            var html = new HtmlElementTextContentDiv
            (
                Icon != null && Icon.HasIcon ? icon : null,
                Name != null ? name : null
            )
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            html.Add(Links?.Select(x => x.Render(renderContext, visualTree)));

            return html;
        }
    }
}
