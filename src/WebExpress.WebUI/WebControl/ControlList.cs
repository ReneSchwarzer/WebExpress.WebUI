using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

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
        public List<ControlListItem> Items { get; private set; } = new List<ControlListItem>();

        /// <summary>
        /// Returns or sets whether it's sorted or unsorted.
        /// </summary>
        public bool Sorted { get; set; }

        /// <summary>
        /// Returns or sets whether to display a frame.
        /// </summary>
        public bool ShowBorder { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlList(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The list entries.</param>
        public ControlList(string id, params ControlListItem[] items)
            : base(id)
        {
            Items.AddRange(items);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The list entries.</param>
        public ControlList(params ControlListItem[] items)
            : this(null, items)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The list entries.</param>
        public ControlList(string id, IEnumerable<ControlListItem> items)
            : base(id)
        {
            Items.AddRange(items);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The list entries.</param>
        public ControlList(IEnumerable<ControlListItem> items)
            : this(null, items)
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            ShowBorder = true;
        }

        /// <summary>
        /// Adds list entries.
        /// </summary>
        /// <param name="items">The list entries.</param>
        public void Add(IEnumerable<ControlListItem> items)
        {
            Items.AddRange(items);
        }

        /// <summary>
        /// Adds list entries.
        /// </summary>
        /// <param name="item">The list entry.</param>
        public void Add(ControlListItem item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return Render(context, Items);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The list entries.</param>
        /// <returns>The control as html.</returns>
        public virtual IHtmlNode Render(RenderContext context, IEnumerable<ControlListItem> items)
        {
            var li = items.Where(x => x.Enable).Select(x => x.Render(context)).ToList();
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
