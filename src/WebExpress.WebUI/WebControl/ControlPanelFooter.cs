//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlPanelFooter : ControlPanel
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlPanelFooter(string id = null)
//            : base(id)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlPanelFooter(string id, params Control[] content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlPanelFooter(string id, List<Control> content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        private void Init()
//        {
//            Content.Add(new ControlPanel(new ControlLine()));
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            return new HtmlElementSectionFooter(from x in Content select x.Render(context))
//            {
//                Id = Id,
//                Class = GetClasses(),
//                Style = GetStyles(),
//                Role = Role
//            };
//        }
//    }
//}
