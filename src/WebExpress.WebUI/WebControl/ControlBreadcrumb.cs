using System;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a breadcrumb control that displays a list of links indicating the current 
    /// page's location within a navigational hierarchy.
    /// </summary>
    public class ControlBreadcrumb : Control
    {
        /// <summary>
        /// Return or sets the uri.
        /// </summary>
        public UriResource Uri { get; set; }

        /// <summary>
        /// Returns or sets the name to display when the breadcrumb is empty.
        /// </summary>
        public string EmptyName { get; set; }

        /// <summary>
        /// Returns or sets the size.
        /// </summary>
        public TypeSizeButton Size
        {
            get => (TypeSizeButton)GetProperty(TypeSizeButton.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Return or sets a prefix, which is statically displayed in front of the links.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Return or sets how many links to display. It will be truncated at the beginning of the link chain.
        /// </summary>
        public ushort TakeLast { get; set; } = ushort.MaxValue;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlBreadcrumb(string id = null)
            : base(id)
        {
            Size = TypeSizeButton.Small;
            BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var html = new HtmlElementTextContentOl()
            {
                Id = Id,
                Class = Css.Concatenate("breadcrumb bg-light ps-2", GetClasses()),
                Style = GetStyles(),
            };

            if (!string.IsNullOrWhiteSpace(Prefix))
            {
                html.Add
                (
                    new HtmlElementTextContentLi
                    (
                        new HtmlElementTextContentDiv
                        (
                            new HtmlText(I18N.Translate(renderContext.Request?.Culture, Prefix))
                        )
                        {
                            Class = "me-2 text-muted"
                        }
                    )
                );
            }

            if (Uri == null)
            {
                return html;
            }

            var takeLast = Math.Min(TakeLast, Uri.PathSegments.Count);
            var from = Uri.PathSegments.Count - takeLast;

            for (int i = from + 1; i < Uri.PathSegments.Count + 1; i++)
            {
                var path = Uri.Take(i);

                if (path.Display != null)
                {
                    var display = I18N.Translate(renderContext.Request?.Culture, path.Display);
                    var href = path.ToString();

                    html.Add
                    (
                        new HtmlElementTextContentLi
                        (
                            new HtmlElementTextSemanticsA(display)
                            {
                                Href = href,
                                Class = "link"
                            }
                        )
                        {
                            Class = "breadcrumb-item"
                        }
                    );
                }
            }

            return html;
        }
    }
}
