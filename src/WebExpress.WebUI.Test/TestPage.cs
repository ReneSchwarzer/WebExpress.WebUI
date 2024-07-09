using System.Globalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebModule;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebResource;

namespace WebExpress.WebUI.Test
{
    /// <summary>
    /// A dummy class for testing purposes.
    /// </summary>
    public sealed class TestPage : IPage
    {
        /// <summary>
        /// Returns or sets the title of the page.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Returns or sets the ID of the page.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Returns or sets the application context.
        /// </summary>
        public IApplicationContext ApplicationContext { get; set; }

        /// <summary>
        /// Returns or sets the module context.
        /// </summary>
        public IModuleContext ModuleContext { get; set; }

        /// <summary>
        /// Returns or sets the resource context.
        /// </summary>
        public IResourceContext ResourceContext { get; set; }

        /// <summary>
        /// Returns or sets the culture information.
        /// </summary>
        public CultureInfo Culture { get => CultureInfo.CurrentCulture; set => throw new NotImplementedException(); }

        /// <summary>
        /// Initializes the resource context.
        /// </summary>
        /// <param name="resourceContext">The resource context.</param>
        public void Initialization(IResourceContext resourceContext)
        {

        }

        /// <summary>
        /// Post-processes the request and response.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <returns>The processed response.</returns>
        public Response PostProcess(Request request, Response response)
        {
            return null;
        }

        /// <summary>
        /// Pre-processes the request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void PreProcess(Request request)
        {

        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The processed response.</returns>
        public Response Process(Request request)
        {
            return null;
        }

        /// <summary>
        /// Redirects to the specified URI.
        /// </summary>
        /// <param name="uri">The URI to redirect to.</param>
        public void Redirecting(string uri)
        {

        }
    }
}
