using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control that displays an icon.
    /// </summary>
    public class ControlIcon : Control
    {
        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon
        {
            get => (PropertyIcon)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Return or specifies the vertical orientation.
        /// </summary>
        public TypeVerticalAlignment VerticalAlignment
        {
            get => (TypeVerticalAlignment)GetProperty(TypeVerticalAlignment.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the size.
        /// </summary>
        public PropertySizeText Size
        {
            get => (PropertySizeText)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlIcon(string id = null)
            : base(id)
        {
            Icon = new PropertyIcon(TypeIcon.None);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            if (Icon.IsUserIcon)
            {
                return new HtmlElementMultimediaImg()
                {
                    Id = Id,
                    Src = Icon.UserIcon?.ToString(),
                    Class = GetClasses(),
                    Style = GetStyles(),
                    Role = Role,
                    Title = Title
                };
            }

            var html = new HtmlElementTextSemanticsSpan()
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role
            };

            html.AddUserAttribute("title", Title);

            return html;
        }
    }
}
