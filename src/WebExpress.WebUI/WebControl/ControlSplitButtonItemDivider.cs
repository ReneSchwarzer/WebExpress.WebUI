//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlSplitButtonItemDivider : Control, IControlSplitButtonItem
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlSplitButtonItemDivider(string id = null)
//            : base(id)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        private void Init()
//        {
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            var html = new HtmlElementTextContentDiv()
//            {
//                Id = Id,
//                Class = Css.Concatenate("dropdown-divider", GetClasses()),
//                Style = GetStyles(),
//                Role = Role
//            };

//            return html;
//        }
//    }
//}
