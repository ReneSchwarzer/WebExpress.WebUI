﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a navigation item link control.
    /// </summary>
    public class ControlNavigationItemLink : ControlLink, IControlNavigationItem
    {
        /// <summary>
        /// Prevents line break.
        /// </summary>
        public bool NoWrap { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlNavigationItemLink(string id = null, params IControl[] content)
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
            var html = base.Render(renderContext, visualTree);

            if (NoWrap)
            {
                html.AddClass("text-nowrap");
            }

            return html;
        }
    }
}
