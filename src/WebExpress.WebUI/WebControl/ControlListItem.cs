using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a list item control that can contain other controls as its content.
    /// </summary>
    public class ControlListItem : Control
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public IEnumerable<Control> Content { get; private set; }

        /// <summary>
        /// Returns or sets the ativity state of the list item.
        /// </summary>
        public TypeActive Active
        {
            get => (TypeActive)GetProperty(TypeActive.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlListItem(string id = null, params Control[] content)
            : base(id)
        {
            Content = content ?? [];
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlListItem(string id = null, IEnumerable<Control> content = null)
            : base(id)
        {
            Content = content ?? [];
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="items">The list entries.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext context)
        {
            return new HtmlElementTextContentLi(Content.Where(x => x.Enable).Select(x => x.Render(context)))
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
