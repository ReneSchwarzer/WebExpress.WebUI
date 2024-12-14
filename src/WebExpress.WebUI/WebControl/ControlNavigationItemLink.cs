//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlNavigationItemLink : ControlLink, IControlNavigationItem
//    {
//        /// <summary>
//        /// Verhindert den Zeilenumbruch
//        /// </summary>
//        public bool NoWrap { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlNavigationItemLink(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            var html = base.Render(context);

//            if (NoWrap)
//            {
//                html.AddClass("text-nowrap");
//            }

//            return html;
//        }
//    }
//}
