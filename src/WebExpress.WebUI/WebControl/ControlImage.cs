using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents an image control that can be rendered as HTML.
    /// </summary>
    public class ControlImage : Control
    {
        /// <summary>
        /// Returns or sets the image source.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Returns or sets the width.
        /// </summary>
        public new int Width { get; set; }

        /// <summary>
        /// Returns or sets the height.
        /// </summary>
        public new int Height { get; set; }

        /// <summary>
        /// Returns or sets a tooltip text.
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="uri">The image source.</param>
        public ControlImage(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            Classes.Add(HorizontalAlignment.ToClass());

            var html = new HtmlElementMultimediaImg()
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role,
                Alt = Tooltip,
                Src = Uri?.ToString(),
            };

            if (!string.IsNullOrWhiteSpace(Tooltip))
            {
                html.AddUserAttribute("data-toggle", "tooltip");
                html.AddUserAttribute("title", Tooltip);
            }

            if (Width > 0)
            {
                html.AddUserAttribute("width", Width.ToString());
            }

            if (Height > 0)
            {
                html.AddUserAttribute("height", Height.ToString());
            }

            return html;
        }
    }
}
