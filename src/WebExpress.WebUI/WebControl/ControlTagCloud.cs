﻿using System;
using WebExpress.Core.WebHtml;
using WebExpress.Core.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlTagCloud : Control
    {
        /// <summary>
        /// Returns or sets the target uri.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTagCloud(string id = null)
            : base(id)
        {
            Init();
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
            return new HtmlElementTextContentDiv()
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
