using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
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
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="name">The name.</param>
        public ControlFormItemInputHidden(string id, string name)
            : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public override void Initialize(RenderContextForm context)
        {
            Value = context?.Request.GetParameter(Name)?.Value;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContextForm context)
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
