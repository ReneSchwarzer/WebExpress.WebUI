using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebComponent;

namespace WebExpress.WebUI.WebComponent
{
    /// <summary>
    /// Represents the UI component hub that inherits from <see cref="ComponentHub"/>.
    /// </summary>
    public class ComponentHubUI : ComponentHub, IComponentHubUI
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="httpServerContext">The HTTP server context.</param>
        protected ComponentHubUI(IHttpServerContext httpServerContext)
            : base(httpServerContext)
        {
            if (InternationalizationManager is InternationalizationManager internationalizationManager)
            {
                internationalizationManager.Register(typeof(ComponentHubUI).Assembly, typeof(ComponentHubUI).Assembly.GetName().Name?.ToLower());
            }
        }
    }
}
