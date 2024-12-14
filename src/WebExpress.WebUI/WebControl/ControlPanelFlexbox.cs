//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlPanelFlexbox : ControlPanel
//    {
//        /// <summary>
//        /// Returns or sets whether the items should be displayed inline.
//        /// </summary>
//        public virtual TypeLayoutFlexbox Layout
//        {
//            get => (TypeLayoutFlexbox)GetProperty(TypeLayoutFlexbox.Default);
//            set => SetProperty(value, () => value.ToClass());
//        }

//        /// <summary>
//        /// Returns or sets the horizontal alignment of the items.
//        /// </summary>
//        public virtual TypeJustifiedFlexbox Justify
//        {
//            get => (TypeJustifiedFlexbox)GetProperty(TypeJustifiedFlexbox.Start);
//            set => SetProperty(value, () => value.ToClass());
//        }

//        /// <summary>
//        /// Bestimmt, ob Specifies or sets the vertical orientation of the items.
//        /// </summary>
//        public virtual TypeAlignFlexbox Align
//        {
//            get => (TypeAlignFlexbox)GetProperty(TypeAlignFlexbox.Start);
//            set => SetProperty(value, () => value.ToClass());
//        }

//        /// <summary>
//        /// Returns or sets the overflow behavior of the items.
//        /// </summary>
//        public virtual TypeWrap Wrap
//        {
//            get => (TypeWrap)GetProperty(TypeWrap.Nowrap);
//            set => SetProperty(value, () => value.ToClass());
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlPanelFlexbox(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="content">The flexbox items.</param>
//        public ControlPanelFlexbox(string id, params IControl[] content)
//            : base(id, content)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="content">The flexbox items.</param>
//        public ControlPanelFlexbox(params IControl[] content)
//            : base(null, content)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="items">The flexbox items.</param>
//        public ControlPanelFlexbox(string id, IEnumerable<IControl> content)
//            : base(id, content)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="items">The flexbox items.</param>
//        public ControlPanelFlexbox(IEnumerable<IControl> content)
//            : base(null, content)
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
//                Class = Css.Concatenate("", GetClasses()),
//                Style = GetStyles(),
//                Role = Role
//            };

//            html.Elements.AddRange(Content.Select(x => x.Render(context)));

//            return html;
//        }
//    }
//}
