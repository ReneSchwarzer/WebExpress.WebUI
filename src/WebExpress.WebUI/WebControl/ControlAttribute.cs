﻿using System;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control attribute with a name-value pair.
    /// </summary>
    public class ControlAttribute : Control
    {
        /// <summary>
        /// Returns or sets the text color of the name.
        /// </summary>
        public PropertyColorText NameColor { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public IIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns or sets a link.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlAttribute(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            if (!Enable)
            {
                return null;
            }

            var icon = Icon?.Render(renderContext, visualTree);

            var name = new HtmlElementTextSemanticsSpan(new HtmlText(I18N.Translate(renderContext.Request?.Culture, Name)))
            {
                Id = string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}_name",
                Class = NameColor?.ToClass()
            };

            var value = new HtmlElementTextSemanticsSpan(new HtmlText(I18N.Translate(renderContext.Request?.Culture, Value)))
            {
                Id = string.IsNullOrWhiteSpace(Id) ? string.Empty : $"{Id}_value",
                Class = NameColor?.ToClass()
            };

            var html = new HtmlElementTextContentDiv
            (
                Icon != null ? icon : null,
                name,
                Uri != null ? new HtmlElementTextSemanticsA(value) { Href = Uri.ToString() } : value
            )
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            return html;
        }
    }
}
