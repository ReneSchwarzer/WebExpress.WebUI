//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlPanelMain : ControlPanel
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlPanelMain(string id = null)
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
//            var html = new HtmlElementSectionMain()
//            {
//                Id = Id,
//                Class = GetClasses(),
//                Style = GetStyles(),
//                Role = Role
//            };

//            html.Elements.AddRange(from x in Content select x?.Render(context));

//            return html;
//        }
//    }
//}
