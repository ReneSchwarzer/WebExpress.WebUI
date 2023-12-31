﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Stellt eine Timline (analog Facebook) bereit
    /// </summary>
    public class ControlTimeline : Control
    {
        /// <summary>
        /// Liefert oder setzt die Timeline-Einträge
        /// </summary>
        public List<ControlTimelineItem> Items { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTimeline(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTimeline(params ControlTimelineItem[] items)
            : base(null)
        {
            Init();

            Items.AddRange(items);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Items = new List<ControlTimelineItem>();
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Classes.Add("timeline");

            var ul = new HtmlElementTextContentUl(Items.Select(x => new HtmlElementTextContentLi(x.Render(context)) { Class = "item" }))
            {
                Id = Id,
                Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            return ul;
        }
    }
}
