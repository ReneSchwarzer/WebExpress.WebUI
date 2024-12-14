using System.Runtime.CompilerServices;
using WebExpress.WebCore;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebUI.WebComponent;

[assembly: InternalsVisibleTo("WebExpress.WebUI.Test")]

namespace WebExpress.WebUI
{
    /// <summary>
    /// Represents the WebExpress UI component that extends the WebEx class with the IComponentHubUI interface.
    /// </summary>
    public class WebExUI : WebEx<IComponentHubUI>
    {
        /// <summary>
        /// Creates and returns a new instance of <see cref="IComponentHubUI"/>.
        /// </summary>
        /// <param name="httpServerContext">The HTTP server context used to initialize the component manager.</param>
        /// <returns>A new instance of <see cref="IComponentHubUI"/>.</returns>
        protected override IComponentHubUI CreateComponentManager(IHttpServerContext httpServerContext)
        {
            return ComponentActivator.CreateInstance<ComponentHubUI>(httpServerContext);
        }
    }
}
