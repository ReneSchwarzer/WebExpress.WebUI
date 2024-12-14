﻿//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    /// <summary>
//    /// Abstract base class for form items.
//    /// </summary>
//    /// <remarks>
//    /// This class provides the base functionality for form items, including properties for the name of the input field,
//    /// initialization, and rendering to HTML.
//    /// </remarks>
//    public abstract class ControlFormItem : Control
//    {
//        /// <summary>
//        /// Returns or sets the name of the input field.
//        /// </summary>
//        public string Name { get; set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlFormItem(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes the form element.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public abstract void Initialize(RenderContextForm context);

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public abstract IHtmlNode Render(RenderContextForm context);

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            if (context is RenderContextForm formContext)
//            {
//                return Render(formContext);
//            }

//            return null;
//        }
//    }
//}
