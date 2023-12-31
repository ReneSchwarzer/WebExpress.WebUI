﻿using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlPanelCenter : ControlPanel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelCenter(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">The content of the html element.</param>
        public ControlPanelCenter(params Control[] content)
            : this()
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlPanelCenter(string id, params Control[] content)
            : this(id)
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var html = new HtmlElementTextContentDiv(from x in Content select x.Render(context))
            {
                Id = Id,
                Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            return html;
        }
    }
}
