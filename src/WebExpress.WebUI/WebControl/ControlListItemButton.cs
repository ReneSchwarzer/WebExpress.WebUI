//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlListItemButton : ControlListItem
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlListItemButton(string id = null)
//            : base(id)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlListItemButton(string id, params Control[] content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="content">The content of the html element.</param>
//        public ControlListItemButton(params Control[] content)
//            : base(content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The content of the html element.</param>
//        public ControlListItemButton(string id, List<Control> content)
//            : base(id, content)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="content">The content of the html element.</param>
//        public ControlListItemButton(List<Control> content)
//            : base(content)
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
//            return new HtmlElementFieldButton(from x in Content select x.Render(context))
//            {
//                Id = Id,
//                Class = Css.Concatenate("list-group-item-action", GetClasses()),
//                Style = GetStyles(),
//                Role = Role
//            };
//        }
//    }
//}
