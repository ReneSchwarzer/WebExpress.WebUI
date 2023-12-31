﻿using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlCanvas : Control
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public List<Control> Content { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlCanvas(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">The content of the html element.</param>
        public ControlCanvas(params Control[] content)
            : this()
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlCanvas(string id, params Control[] content)
            : this(id)
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlCanvas(string id, IEnumerable<Control> content)
            : this(id)
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlCanvas(string id, List<Control> content)
            : base(id)
        {
            Content = content;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Content = new List<Control>();
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return new HtmlElementScriptingCanvas()
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
