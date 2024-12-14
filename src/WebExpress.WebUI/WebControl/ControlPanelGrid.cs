//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    /// <summary>
//    /// Grid of 12 cells per row.
//    /// </summary>
//    public class ControlPanelGrid : ControlPanel
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlPanelGrid(string id = null)
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
//                Class = GetClasses(),
//                Style = GetStyles(),
//                Role = Role
//            };

//            html.Elements.Add(new HtmlElementTextContentDiv(Content.Select(x => x.Render(context))) { Class = "row" });

//            return html;
//        }
//    }
//}
