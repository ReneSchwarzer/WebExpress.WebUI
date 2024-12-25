using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a static text form item control.
    /// </summary>
    public class ControlFormItemStaticText : ControlFormItem, IControlFormLabel
    {
        /// <summary>
        /// Returns or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemStaticText(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            var c = new List<string>
            {
                "form-control-static"
            };

            var html = new HtmlElementTextContentP()
            {
                Id = Id,
                Text = I18N.Translate(renderContext.Request?.Culture, Text),
                Class = Css.Concatenate(GetClasses()),
                Style = Style.Concatenate(GetStyles()),
                Role = Role
            };

            return html;
        }
    }
}
