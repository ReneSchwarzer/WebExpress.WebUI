//using System.Collections.Generic;
//using WebExpress.WebCore.WebMessage;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class RenderContextForm : RenderContext
//    {
//        /// <summary>
//        /// The form in which the control is rendered.
//        /// </summary>
//        public IControlForm Form { get; private set; }

//        /// <summary>
//        /// Returns or sets the links to the java script files to be used.
//        /// </summary>
//        public IDictionary<string, string> Scripts { get; } = new Dictionary<string, string>();

//        /// <summary>
//        /// Returns the validation errors.
//        /// </summary>
//        public ICollection<ValidationResult> ValidationResults { get; } = new List<ValidationResult>();

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="page">The page where the control is rendered.</param>
//        /// <param name="request">The request.</param>
//        /// <param name="visualTree">The visual tree.</param>
//        /// <param name="form">The form in which the control is rendered.</param>
//        public RenderContextForm(IPage page, Request request, IVisualTree visualTree, IControlForm form)
//        //: base(page, request, visualTree)
//        {
//            Form = form;
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <param name="form">The form in which the control is rendered.</param>
//        public RenderContextForm(RenderContext context, IControlForm form)
//            : base(context)
//        {
//            Form = form;
//        }

//        /// <summary>
//        /// Copy-Constructor
//        /// </summary>
//        /// <param name="context">The render context to copy./param>
//        public RenderContextForm(RenderContextForm context)
//            : this(context, context?.Form)
//        {
//            Scripts = context.Scripts;
//        }

//        /// <summary>
//        /// Adds or replaces a java script if it exists.
//        /// </summary>
//        /// <param name="key">The key.</param>
//        /// <param name="code">The java script code.</param>
//        public void AddScript(string key, string code)
//        {
//            if (!Scripts.ContainsKey(key))
//            {
//                Scripts.Add(key, code);
//            }
//        }
//    }
//}
