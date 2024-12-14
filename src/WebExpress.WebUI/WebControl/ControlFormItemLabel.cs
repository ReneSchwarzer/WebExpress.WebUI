//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlFormItemLabel : ControlFormItem
//    {
//        /// <summary>
//        /// Returns or sets the text of the label.
//        /// </summary>
//        public string Text { get; set; }

//        /// <summary>
//        /// Returns or sets the associated form field.
//        /// </summary>
//        public ControlFormItem FormItem { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlFormItemLabel(string id)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="text">The text.</param>
//        public ControlFormItemLabel(string id, string text)
//            : this(id)
//        {
//            Text = text;
//        }

//        /// <summary>
//        /// Initializes the form element.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public override void Initialize(RenderContextForm context)
//        {
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContextForm context)
//        {
//            return new HtmlElementFieldLabel()
//            {
//                Text = I18N.Translate(context.Culture, Text),
//                Class = GetClasses(),
//                Style = GetStyles(),
//                Role = Role,
//                For = FormItem != null ?
//                    string.IsNullOrWhiteSpace(FormItem.Id) ?
//                    FormItem.Name :
//                    FormItem.Id :
//                    null
//            };
//        }
//    }
//}
