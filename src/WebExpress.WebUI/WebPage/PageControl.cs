using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebPage
{
    /// <summary>
    /// A (web) page, which is built from controls.
    /// </summary>
    public abstract class PageControl<T> : Page<T> where T : VisualTreeControl, new()
    {
        /// <summary>
        /// Returns the links to the JavaScript files to be used, which are inserted in the header.
        /// </summary>
        protected ICollection<string> HeaderScriptLinks { get; } = [];

        /// <summary>
        /// Returns the links to the css files to use.
        /// </summary>
        protected ICollection<string> CssLinks { get; } = [];

        /// <summary>
        /// Returns the meta information.
        /// </summary>
        protected List<KeyValuePair<string, string>> Meta { get; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PageControl()
        {

        }

        ///// <summary>
        ///// Initialization
        ///// </summary>
        ///// <param name="context">The context of the resource.</param>
        //public override void Initialization(IResourceContext context)
        //{
        //    base.Initialization(context);

        //    var module = ComponentManager.ModuleManager.GetModule(context?.ModuleContext?.ApplicationContext, typeof(Module));
        //    if (module != null)
        //    {
        //        var contextPath = module.ContextPath;
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/fontawesome.min.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/bootstrap.min.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/solid.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/summernote-bs5.min.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.expand.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.form.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.modalform.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.modalpage.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.more.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.move.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.pagination.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.search.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.selection.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.table.css"));
        //        CssLinks.Add(UriResource.Combine(contextPath, "/assets/css/webexpress.webui.toolpanel.css"));

        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/jquery-3.7.1.min.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/popper.min.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/bootstrap.min.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/summernote-bs5.min.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.expand.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.form.progress.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.modalform.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.modalpage.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.more.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.move.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.pagination.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.search.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.selection.js"));
        //        HeaderScriptLinks.Add(UriResource.Combine(contextPath, "/assets/js/webexpress.webui.table.js"));
        //    }

        //    Meta.Add(new KeyValuePair<string, string>("charset", "UTF-8"));
        //    Meta.Add(new KeyValuePair<string, string>("viewport", "width=device-width, initial-scale=1"));
        //}

        /// <summary>
        /// Processing of the page.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree control to be processed.</param>
        public override void Process(IRenderContext renderContext, T visualTree)
        {
            visualTree.AddCssLink(CssLinks.ToArray());
            visualTree.AddHeaderScriptLink(HeaderScriptLinks.ToArray());
            //visualTree.AddMeta(Meta);
        }
    }
}
