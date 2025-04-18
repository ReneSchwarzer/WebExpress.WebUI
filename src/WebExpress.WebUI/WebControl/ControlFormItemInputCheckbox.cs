using System;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a checkbox input form item control.
    /// </summary>
    public class ControlFormItemInputCheckbox : ControlFormItemInput
    {
        /// <summary>
        /// Returns or sets whether the checkbox should be displayed on a new line.
        /// </summary>
        public bool Inline { get; set; }

        /// <summary>
        /// Returns or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets a search pattern that checks the content.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id.</param>
        public ControlFormItemInputCheckbox(string id = null)
            : base(id)
        {
            Value = "false";
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            var value = renderContext.Request.GetParameter(Name)?.Value;

            Value = string.IsNullOrWhiteSpace(value) || !value.Equals("on", StringComparison.OrdinalIgnoreCase) ? "false" : "true";
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext, IVisualTreeControl visualTree)
        {
            var html = new HtmlElementTextContentDiv
            (
                new HtmlElementFieldLabel
                (
                    new HtmlElementFieldInput()
                    {
                        Name = Name,
                        Pattern = Pattern,
                        Type = "checkbox",
                        Disabled = Disabled,
                        //Role = Role,
                        Checked = Value.Equals("true")
                    },
                    new HtmlText
                    (
                        string.IsNullOrWhiteSpace(Description) ?
                        string.Empty :
                        "&nbsp;" + I18N.Translate(renderContext.Request?.Culture, Description)
                    )
                )
                {
                }
            )
            {
                Id = Id,
                Class = Css.Concatenate("checkbox", GetClasses()),
                Style = GetStyles(),
            };

            return html;
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public override void Validate(IRenderControlFormContext renderContext)
        {
            base.Validate(renderContext);
        }
    }
}
