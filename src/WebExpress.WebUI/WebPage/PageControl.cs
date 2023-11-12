using System.Collections.Generic;
using WebExpress.Core.WebComponent;
using WebExpress.Core.WebPage;
using WebExpress.Core.WebResource;
using WebExpress.Core.WebUri;

namespace WebExpress.WebUI.WebPage
{
    /// <summary>
    /// A (web) page, which is built from controls.
    /// </summary>
    public abstract class PageControl<T> : Page<T> where T : RenderContextControl, new()
    {
        /// <summary>
        /// Returns the links to the JavaScript files to be used, which are inserted in the header.
        /// </summary>
        protected ICollection<string> HeaderScriptLinks { get; } = new List<string>();

        /// <summary>
        /// Returns the links to the css files to use.
        /// </summary>
        protected ICollection<string> CssLinks { get; } = new List<string>();

        /// <summary>
        /// Returns the meta information.
        /// </summary>
        protected List<KeyValuePair<string, string>> Meta { get; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Constructor
        /// </summary>
        public PageControl()
        {

        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context of the resource.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);

            var module = ComponentManager.ModuleManager.GetModule(context?.ModuleContext?.ApplicationContext, typeof(Module));
            if (module != null)
            {
                var contextPath = module.ContextPath;
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/fontawesome.min.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/bootstrap.min.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/solid.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/summernote-bs5.min.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.expand.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.form.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.modalformular.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.modalpage.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.more.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.move.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.pagination.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.search.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.selection.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.table.css"));
                CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.toolpanel.css"));

                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/jquery-3.7.0.min.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/popper.min.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/bootstrap.min.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/summernote-bs5.min.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.expand.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.modalformular.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.modalpage.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.more.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.move.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.pagination.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.search.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.selection.js"));
                HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.table.js"));
            }

            Meta.Add(new KeyValuePair<string, string>("charset", "UTF-8"));
            Meta.Add(new KeyValuePair<string, string>("viewport", "width=device-width, initial-scale=1"));
        }

        /// <summary>
        /// Processing of the page.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        public override void Process(T context)
        {
            context.VisualTree.CssLinks.AddRange(CssLinks);
            context.VisualTree.HeaderScriptLinks.AddRange(HeaderScriptLinks);
            context.VisualTree.Meta.AddRange(Meta);
        }
    }
}
