﻿using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the main control panel that can contain multiple child controls and manage 
    /// their layout and rendering.
    /// </summary>
    public class ControlPanelMain : ControlPanel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlPanelMain(string id = null, params IControl[] content)
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
            var html = new HtmlElementSectionMain(Content.Select(x => x.Render(renderContext, visualTree)).ToArray())
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role
            };

            return html;
        }
    }
}
