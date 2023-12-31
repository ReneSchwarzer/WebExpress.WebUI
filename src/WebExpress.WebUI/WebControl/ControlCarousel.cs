﻿using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Creates a slideshow.
    /// </summary>
    public class ControlCarousel : Control
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public List<ControlCarouselItem> Items { get; private set; } = new List<ControlCarouselItem>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlCarousel(string id = null)
            : base(string.IsNullOrWhiteSpace(id) ? "carousel" : id)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The contents of the slideshow.</param>
        public ControlCarousel(params ControlCarouselItem[] items)
            : this()
        {
            Items.AddRange(items);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            // indicators 
            var indicators = new HtmlElementTextContentUl() { Class = "carousel-indicators" };
            var index = 0;

            foreach (var v in Items)
            {
                var i = new HtmlElementTextContentLi() { Class = index == 0 ? "active" : string.Empty };
                i.AddUserAttribute("data-bs-target", "#" + Id);
                i.AddUserAttribute("data-bs-slide-to", index.ToString());

                indicators.Elements.Add(i);

                index++;
            }

            index = 0;

            // items
            var inner = new HtmlElementTextContentDiv() { Class = "carousel-inner" };
            foreach (var v in Items)
            {
                var i = new HtmlElementTextContentDiv(v?.Control.Render(context)) { Class = index == 0 ? "carousel-item active" : "carousel-item" };

                if (!string.IsNullOrWhiteSpace(v.Headline) || !string.IsNullOrWhiteSpace(v.Text))
                {
                    var caption = new HtmlElementTextContentDiv
                    (
                        new HtmlElementSectionH3() { Text = v.Headline },
                        new HtmlElementTextContentP() { Text = v.Text }
                    )
                    {
                        Class = "carousel-caption"
                    };

                    i.Elements.Add(caption);
                }

                inner.Elements.Add(i);

                index++;
            }

            // navigation
            var navLeft = new HtmlElementTextSemanticsA(new HtmlElementTextSemanticsSpan() { Class = "carousel-control-prev-icon" })
            {
                Class = "carousel-control-prev",
                Href = "#" + Id
            };
            navLeft.AddUserAttribute("data-bs-slide", "prev");

            var navRight = new HtmlElementTextSemanticsA(new HtmlElementTextSemanticsSpan() { Class = "carousel-control-next-icon" })
            {
                Class = "carousel-control-next",
                Href = "#" + Id
            };
            navRight.AddUserAttribute("data-bs-slide", "next");

            var html = new HtmlElementTextContentDiv
            (
                indicators, inner, navLeft, navRight
            )
            {
                Id = Id,
                Class = Css.Concatenate("carousel slide", GetClasses()),
                Style = GetStyles()
            };

            html.AddUserAttribute("data-bs-ride", "carousel");

            return html;
        }
    }
}
