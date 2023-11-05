﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebHtml;
using WebExpress.Internationalization;
using WebExpress.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Anzeige einer Liste mit Links
    /// </summary>
    public class ControlLinkList : Control
    {
        /// <summary>
        /// Liefert oder setzt die Textfarbe des Namens
        /// </summary>
        public PropertyColorText NameColor { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Liefert oder setzt die Links
        /// </summary>
        public List<IControlLink> Links { get; } = new List<IControlLink>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        public ControlLinkList(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var icon = new HtmlElementTextSemanticsSpan()
            {
                Class = Icon?.ToClass()
            };

            var name = new HtmlElementTextSemanticsSpan(new HtmlText(context.I18N(Name)))
            {
                Id = string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}_name",
                Class = NameColor?.ToClass()
            };

            var html = new HtmlElementTextContentDiv
            (
                Icon != null && Icon.HasIcon ? icon : null,
                Name != null ? name : null
            )
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            html.Elements.AddRange(Links?.Select(x => x.Render(context)));

            return html;
        }
    }
}
