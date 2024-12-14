//using System.Collections.Generic;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlFormItemPrepend : ControlPanel
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlFormItemPrepend(string id)
//            : base(id)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlFormItemPrepend(string id, params Control[] content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlFormItemPrepend(string id, IEnumerable<Control> content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlFormItemPrepend(string id, List<Control> content)
//            : base(id, content)
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
//            Classes.Add("input-group-prepend");
//            var html = base.Render(context);
//            return html;
//        }
//    }
//}
