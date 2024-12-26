using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
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
        public string Uri { get; set; }

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
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var html = new HtmlElementTextContentOl()
            {
                Id = Id,
                Class = Css.Concatenate("breadcrumb bg-light ps-2", GetClasses()),
                Style = GetStyles(),
            };

            if (!string.IsNullOrWhiteSpace(Prefix))
            {
                html.Elements.Add
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

            foreach (var part in renderContext.Request?.Uri.PathSegments)
            {
                if (part.Display != null)
                {
                    var display = part.GetDisplay(renderContext.Request?.Culture);
                    var href = part.ToString();

                    html.Elements.Add
                    (
                        new HtmlElementTextContentLi
                        (
                            //new ControlIcon(Page)
                            //{ 
                            //    Icon = path.Icon
                            //}.ToHtml(),
                            new HtmlElementTextSemanticsA(display)
                            {
                                Href = href
                            }
                        )
                        {
                            Class = "breadcrumb-item"
                        }
                    );
                }
            }

            //var takeLast = Math.Min(TakeLast, resourceUri.Path.Count);
            //var from = resourceUri.Path.Count - takeLast;

            //for (int i = from + 1; i < resourceUri.Path.Count + 1; i++)
            //{
            //    var path = resourceUri.Take(i);

            //    if (path.Display != null)
            //    {
            //        var display = I18N(context.Culture, path.Display);
            //        var href = path.ToString();

            //        html.Elements.Add
            //        (
            //            new HtmlElementTextContentLi
            //            (
            //                //new ControlIcon(Page)
            //                //{ 
            //                //    Icon = path.Icon
            //                //}.ToHtml(),
            //                new HtmlElementTextSemanticsA(display)
            //                {
            //                    Href = href,
            //                    Class = "link"
            //                }
            //            )
            //            {
            //                Class = "breadcrumb-item"
            //            }
            //        );
            //    }
            //}
            //}

            return html;
        }
    }
}
