using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a form item that displays help text.
    /// </summary>
    public class ControlFormItemHelpText : ControlFormItem
    {
        /// <summary>
        /// Returns or sets the size of the text.
        /// </summary>
        public PropertySizeText Size
        {
            get => (PropertySizeText)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the help text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemHelpText(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            TextColor = new PropertyColorText(TypeColorText.Muted);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            return new HtmlElementTextSemanticsSmall()
            {
                Id = Id,
                Text = I18N.Translate(renderContext.Request?.Culture, Text),
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
