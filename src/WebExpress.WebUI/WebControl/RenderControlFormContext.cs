using System.Collections.Generic;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Provides the context for rendering a form control within a web page.
    /// </summary>
    public class RenderControlFormContext : RenderControlContext, IRenderControlFormContext
    {
        private readonly IList<ValidationResult> _validationResults = [];

        /// <summary>
        /// The form in which the control is rendered.
        /// </summary>
        public IControlForm Form { get; private set; }

        /// <summary>
        /// Returns the validation errors.
        /// </summary>
        public IEnumerable<ValidationResult> ValidationResults => _validationResults;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The page context where the control is rendered.</param>
        /// <param name="request">The request.</param>
        /// <param name="form">The form in which the control is rendered.</param>
        public RenderControlFormContext(IPageContext pageContext, Request request, IControlForm form)
            : base(pageContext, request)
        {
            Form = form;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="form">The form in which the control is rendered.</param>
        public RenderControlFormContext(IRenderContext renderContext, IControlForm form)
            : base(renderContext)
        {
            Form = form;
        }

        /// <summary>
        /// Copy-Constructor
        /// </summary>
        /// <param name="context">The render context to copy./param>
        public RenderControlFormContext(IRenderControlFormContext context)
            : this(context, context?.Form)
        {
            //AddScripts(context.Scripts);
        }
    }
}
