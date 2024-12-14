//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlFormItemHelpText : ControlFormItem
//    {
//        /// <summary>
//        /// Returns or sets the size of the text.
//        /// </summary>
//        public PropertySizeText Size
//        {
//            get => (PropertySizeText)GetPropertyObject();
//            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
//        }

//        /// <summary>
//        /// Returns or sets the help text.
//        /// </summary>
//        public string Text { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlFormItemHelpText(string id)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="text">The text.</param>
//        public ControlFormItemHelpText(string id, string text)
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
//            TextColor = new PropertyColorText(TypeColorText.Muted);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContextForm context)
//        {
//            return new HtmlElementTextSemanticsSmall()
//            {
//                Text = I18N.Translate(context.Culture, Text),
//                Class = Css.Concatenate("", GetClasses()),
//                Style = GetStyles(),
//                Role = Role
//            };
//        }
//    }
//}
