﻿using System;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control list that can contain multiple control list items.
    /// </summary>
    public class ControlVirtualList : Control
    {
        /// <summary>
        /// Occurs when a virtual item needs to be retrieved.
        /// </summary>
        public event EventHandler<RetrieveVirtualItemEventArgs> RetrieveVirtualItem;

        /// <summary>
        /// Returns or sets the size of the virtual list.
        /// </summary>
        public uint VirtualListSize { get; set; }

        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypeLayoutList Layout
        {
            get => (TypeLayoutList)GetProperty(TypeLayoutList.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The list entries.</param>
        public ControlVirtualList(string id = null)
            : base(id)
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
            var eventArgs = new RetrieveVirtualItemEventArgs(renderContext);
            RetrieveVirtualItem?.Invoke(this, eventArgs);

            var li = eventArgs.Items?.Where(x => x.Enable).Select(x => x.Render(renderContext, visualTree)).ToList() ?? [];

            switch (Layout)
            {
                case TypeLayoutList.Horizontal:
                case TypeLayoutList.Flush:
                case TypeLayoutList.Group:
                    li.ForEach(x => x.AddClass("list-group-item"));
                    break;
            }

            var html = new HtmlElementTextContentUl(li.ToArray())
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
