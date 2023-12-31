﻿using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlPanelMedia : ControlPanel
    {
        /// <summary>
        /// Returns or sets the title.
        /// </summary>
        public Control Title { get; set; }

        /// <summary>
        /// Returns or sets the uri to the image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Returns or sets the width of the image in pixel.
        /// </summary>
        public int ImageWidth { get; set; } = -1;

        /// <summary>
        /// Returns or sets the height of the image in pixel.
        /// </summary>
        public int ImageHeight { get; set; } = -1;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelMedia(string id = null)
            : base(id)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="title">The headline.</param>
        public ControlPanelMedia(string id, string title)
            : this(id)
        {
            Title = new ControlText(string.IsNullOrWhiteSpace(id) ? null : id + "_header")
            {
                Text = title
            };
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var img = new HtmlElementMultimediaImg()
            {
                Src = Image?.ToString(),
                Class = "me-3 mt-3 " // rounded-circle
            };

            if (ImageWidth > -1)
            {
                img.Width = ImageWidth;
            }

            if (ImageHeight > -1)
            {
                img.Height = ImageHeight;
            }

            var heading = new HtmlElementSectionH4(Title?.Render(context))
            {
            };

            var body = new HtmlElementTextContentDiv(Title != null ? heading : null)
            {
                Class = "media-body"
            };

            body.Elements.AddRange(from x in Content select x.Render(context));

            var html = new HtmlElementTextContentDiv(img, body)
            {
                Id = Id,
                Class = Css.Concatenate("media", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            return html;
        }
    }
}
