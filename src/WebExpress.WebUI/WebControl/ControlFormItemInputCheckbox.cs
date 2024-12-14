﻿//using System;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.Internationalization;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlFormItemInputCheckbox : ControlFormItemInput
//    {
//        /// <summary>
//        /// Returns or sets whether the checkbox should be displayed on a new line.
//        /// </summary>
//        public bool Inline { get; set; }

//        /// <summary>
//        /// Returns or sets the description.
//        /// </summary>
//        public string Description { get; set; }

//        /// <summary>
//        /// Returns or sets a search pattern that checks the content.
//        /// </summary>
//        public string Pattern { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id.</param>
//        public ControlFormItemInputCheckbox(string id = null)
//            : base(id)
//        {
//            Value = "false";
//        }

//        /// <summary>
//        /// Initializes the form element.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public override void Initialize(RenderContextForm context)
//        {
//            var value = context.Request.GetParameter(Name)?.Value;

//            Value = string.IsNullOrWhiteSpace(value) || !value.Equals("on", StringComparison.OrdinalIgnoreCase) ? "false" : "true";
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContextForm context)
//        {
//            var html = new HtmlElementTextContentDiv
//            (
//                new HtmlElementFieldLabel
//                (
//                    new HtmlElementFieldInput()
//                    {
//                        Name = Name,
//                        Pattern = Pattern,
//                        Type = "checkbox",
//                        Disabled = Disabled,
//                        //Role = Role,
//                        Checked = Value.Equals("true")
//                    },
//                    new HtmlText(string.IsNullOrWhiteSpace(Description) ? string.Empty : "&nbsp;" + I18N.Translate(Description))
//                )
//                {
//                }
//            )
//            {
//                Class = Css.Concatenate("checkbox", GetClasses()),
//                Style = GetStyles(),
//            };

//            return html;
//        }

//        /// <summary>
//        /// Checks the input element for correctness of the data.
//        /// </summary>
//        /// <param name="context">The context in which the inputs are validated.</param>
//        public override void Validate(RenderContextForm context)
//        {
//            base.Validate(context);
//        }
//    }
//}
