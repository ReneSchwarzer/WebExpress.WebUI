using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a hidden input form item control.
    /// </summary>
    public class ControlFormItemInputHidden : ControlFormItemInput
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemInputHidden(string id = null)
            : base(id)
        {
            Name = Id;
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            Value = renderContext?.Request.GetParameter(Name)?.Value;
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            return new HtmlElementFieldInput()
            {
                Id = Id,
                Value = Value,
                Name = Name,
                Type = "hidden",
                Role = Role
            };
        }
    }
}
