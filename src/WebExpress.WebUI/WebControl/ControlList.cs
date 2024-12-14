using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control list that can contain multiple control list items.
    /// </summary>
    public class ControlList : Control
    {
        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypeLayoutList Layout
        {
            get => (TypeLayoutList)GetProperty(TypeLayoutList.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the list entries.
        /// </summary>
        public IEnumerable<ControlListItem> Items { get; private set; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The list entries.</param>
        public ControlList(string id = null, params ControlListItem[] items)
            : base(id)
        {
            Items = items ?? [];
        }

        /// <summary>
        /// Adds list entries.
        /// </summary>
        /// <param name="items">The list entries.</param>
        public void Add(IEnumerable<ControlListItem> items)
        {
            Items = Items.Concat(items);
        }

        /// <summary>
        /// Adds list entries.
        /// </summary>
        /// <param name="item">The list entry.</param>
        public void Add(ControlListItem item)
        {
            Items = Items.Concat([item]);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// 
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            return Render(renderContext, Items);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="items">The list entries.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public virtual IHtmlNode Render(IRenderControlContext renderContext, IEnumerable<ControlListItem> items)
        {
            var li = items.Where(x => x.Enable).Select(x => x.Render(renderContext)).ToList();
            switch (Layout)
            {
                case TypeLayoutList.Horizontal:
                case TypeLayoutList.Flush:
                case TypeLayoutList.Group:
                    li.ForEach(x => x.AddClass("list-group-item"));
                    break;
            }

            var html = new HtmlElementTextContentUl(li)
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            return html;
        }
    }
}
