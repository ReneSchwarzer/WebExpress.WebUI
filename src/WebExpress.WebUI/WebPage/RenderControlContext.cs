using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebPage
{
    /// <summary>
    /// Provides the context for rendering controls within a web page.
    /// </summary>
    public class RenderControlContext : RenderContext, IRenderControlContext
    {
        /// <summary>
        /// Adds or replaces a java script if it exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="code">The java script code.</param>
        void IRenderControlContext.AddScript(string key, string code)
        {
        }

        /// <summary>
        /// Adds a java script.
        /// </summary>
        /// <param name="url">The link of the java script file.</param>
        void IRenderControlContext.AddScriptLink(string url)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="renderContext">The render context.</param>
        public RenderControlContext(IRenderContext renderContext)
            : base(renderContext?.PageContext, renderContext?.Request)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">>The page context.</param>
        /// <param name="request">The request associated with the rendering context.</param>
        public RenderControlContext(IPageContext pageContext, Request request)
            : base(pageContext, request)
        {
        }
    }
}
