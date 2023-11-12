using System.Collections.Generic;
using System.Linq;
using WebExpress.Core.WebHtml;
using WebExpress.Core.WebPage;

namespace WebExpress.WebUI.WebControl
{
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
        public ControlList(string id, List<ControlListItem> items)
            : base(id)
        {
            Items = items;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The list entries.</param>
        public ControlList(List<ControlListItem> items)
            : this(null, items)
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Items = new List<ControlListItem>();
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
            var items = Items.Where(x => x.Enable).Select(x => x.Render(context)).ToList();

            switch (Layout)
            {
                case TypeLayoutList.Horizontal:
                case TypeLayoutList.Flush:
                case TypeLayoutList.Group:
                    items.ForEach(x => x.AddClass("list-group-item"));
                    break;
            }

            var html = new HtmlElementTextContentUl(items)
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
