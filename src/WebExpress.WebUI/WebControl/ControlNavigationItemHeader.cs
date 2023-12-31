﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlNavigationItemHeader : Control, IControlNavigationItem
    {
        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlNavigationItemHeader(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="text">The text.</param>
        public ControlNavigationItemHeader(string id, string text)
            : base(id)
        {
            Text = text;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return new HtmlElementTextContentLi(new HtmlText(I18N(context.Culture, Text)))
            {
                Id = Id,
                Class = Css.Concatenate("dropdown-header", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
