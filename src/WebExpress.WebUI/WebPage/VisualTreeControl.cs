using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebPage
{
    /// <summary>
    /// The content design of a page is realized by controls.
    /// </summary>
    public class VisualTreeControl : IVisualTree
    {
        private readonly List<Favicon> _favicons = [];
        private readonly List<string> _styles = [];
        private readonly List<string> _headerScriptLinks = [];
        private readonly List<string> _scriptLinks = [];
        private readonly List<string> _headerScripts = [];
        private readonly Dictionary<string, string> _scripts = [];
        private readonly List<string> _cssLinks = [];
        private readonly Dictionary<string, string> _meta = [];
        private readonly List<IControl> _content = [];

        /// <summary>
        /// Returns the title of the html document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Returns the favicons.
        /// </summary>
        public IEnumerable<Favicon> Favicons => _favicons;

        /// <summary>
        /// Returns the internal stylesheet.  
        /// </summary>
        public IEnumerable<string> Styles => _styles;

        /// <summary>
        /// Returns the links to the java script files to be used, which are inserted in the header.
        /// </summary>
        public IEnumerable<string> HeaderScriptLinks => _headerScriptLinks;

        /// <summary>
        /// Returns the links to the java script files to be used.
        /// </summary>
        public IEnumerable<string> ScriptLinks => _scriptLinks;

        /// <summary>
        /// Returns the links to the java script files to be used, which are inserted in the header.
        /// </summary>
        public IEnumerable<string> HeaderScripts => _headerScripts;

        /// <summary>
        /// Returns the links to the java script files to be used.
        /// </summary>
        public IReadOnlyDictionary<string, string> Scripts => _scripts;

        /// <summary>
        /// Returns the links to the css files to be used.
        /// </summary>
        public IEnumerable<string> CssLinks => _cssLinks;

        /// <summary>
        /// Returns the meta information.
        /// </summary>
        public IReadOnlyDictionary<string, string> Meta => _meta;

        /// <summary>
        /// Returns the content.
        /// </summary>
        public IEnumerable<IControl> Content => _content;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VisualTreeControl()
        {
        }

        /// <summary>
        /// Adds a favicon to the web application.
        /// </summary>
        /// <param name="url">The URL of the favicon.</param>
        /// <param name="mediatype">The media type of the favicon.</param>
        public void AddFavicon(string url, string mediatype)
        {
            _favicons.Add(new Favicon(url, mediatype));
        }

        /// <summary>
        /// Removes a favicon from the web application.
        /// </summary>
        /// <param name="url">The URL of the favicon to remove.</param>
        public void RemoveFavicon(string url)
        {
            _favicons.RemoveAll(x => x.Url.Equals(url));
        }

        /// <summary>
        /// Adds one or more styles to the head.
        /// </summary>
        /// <param name="styles">The styles to add.</param>
        public void AddStyle(params string[] styles)
        {
            _styles.AddRange(styles);
        }

        /// <summary>
        /// Removes a style from the head.
        /// </summary>
        /// <param name="style">The style to remove.</param>
        public void RemoveStyle(string style)
        {
            _styles.RemoveAll(x => x.Equals(style));
        }

        /// <summary>
        /// Adds one or more URLs to the list of header script links.
        /// </summary>
        /// <param name="urls">The URLs of the script to add.</param>
        public void AddHeaderScriptLink(params string[] urls)
        {
            _headerScriptLinks.AddRange(urls);
        }

        /// <summary>
        /// Removes a URL from the list of header script links.
        /// </summary>
        /// <param name="url">The URL of the script to remove.</param>
        public void RemoveHeaderScriptLink(string url)
        {
            _headerScriptLinks.RemoveAll(x => x.Equals(url));
        }

        /// <summary>
        /// Adds one or more URLs to the list of script links.
        /// </summary>
        /// <param name="urls">The URLs of the script to add.</param>
        public void AddScriptLink(params string[] urls)
        {
            _scriptLinks.AddRange(urls);
        }

        /// <summary>
        /// Removes a URL from the list of script links.
        /// </summary>
        /// <param name="url">The URL of the script to remove.</param>
        public void RemoveScriptLink(string url)
        {
            _scriptLinks.RemoveAll(x => x.Equals(url));
        }

        /// <summary>
        /// Adds one or more URLs to the list of header scripts.
        /// </summary>
        /// <param name="urls">The URLs of the script to add.</param>
        public void AddHeaderScript(params string[] urls)
        {
            _headerScripts.AddRange(urls);
        }

        /// <summary>
        /// Removes a URL from the list of header scripts.
        /// </summary>
        /// <param name="url">The URL of the script to remove.</param>
        public void RemoveHeaderScript(string url)
        {
            _headerScripts.RemoveAll(x => x.Equals(url));
        }

        /// <summary>
        /// Adds a script to the collection. If a script with the same identifier already exists, it will be overwritten.
        /// </summary>
        /// <param name="id">The identifier of the script.</param>
        /// <param name="script">The script content.</param>
        public void AddScript(string id, string script)
        {
            _scripts[id] = script;
        }

        /// <summary>
        /// Removes a script from the collection.
        /// </summary>
        /// <param name="id">The identifier of the script to remove.</param>
        public void RemoveScript(string id)
        {
            _scripts.Remove(id);
        }

        /// <summary>
        /// Adds one or more URLs to the list of CSS links.
        /// </summary>
        /// <param name="urls">The URLs of the CSS file to add.</param>
        public void AddCssLink(params string[] urls)
        {
            _cssLinks.AddRange(urls);
        }

        /// <summary>
        /// Removes all CSS links that match the specified URL.
        /// </summary>
        /// <param name="url">The URL of the CSS link to remove.</param>
        public void RemoveCssLink(string url)
        {
            _cssLinks.RemoveAll(x => x.Equals(url));
        }

        /// <summary>
        /// Adds a meta tag to the collection. If a meta tag with the same name already exists, it will be overwritten.
        /// </summary>
        /// <param name="name">The name of the meta tag.</param>
        /// <param name="content">The content of the meta tag.</param>
        public void AddMeta(string name, string content)
        {
            _meta[name] = content;
        }

        /// <summary>
        /// Removes a meta tag from the collection.
        /// </summary>
        /// <param name="name">The name of the meta tag to remove.</param>
        public void RemoveMeta(string name)
        {
            _meta.Remove(name);
        }

        /// <summary>
        /// Adds one or more controls to the content of the page.
        /// </summary>
        /// <param name="controls">The controls to add to the content.</param>
        public void AddContent(params IControl[] controls)
        {
            _content.AddRange(controls);
        }

        /// <summary>
        /// Removes a control from the content of the page.
        /// </summary>
        /// <param name="control">The control to remove from the content.</param>
        public void RemoveContent(IControl control)
        {
            _content.Remove(control);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        /// <returns>The page as an html tree.</returns>
        public virtual IHtmlNode Render(IVisualTreeContext context)
        {
            var html = new HtmlElementRootHtml();
            html.Head.Title = I18N.Translate(context.Request, Title);
            html.Head.Favicons = Favicons?.Select(x => new Favicon(x.Url, x.Mediatype));
            html.Head.Styles = Styles;
            html.Head.Meta = Meta;
            html.Head.Scripts = HeaderScripts;
            //html.Body.Elements.AddRange(Content?.Where(x => x.Enable).Select(x => x.Render(context)));
            html.Body.Scripts = [.. Scripts.Values];

            html.Head.CssLinks = CssLinks.Where(x => x != null).Select(x => x.ToString());
            html.Head.ScriptLinks = HeaderScriptLinks?.Where(x => x != null).Select(x => x.ToString());

            return html;
        }


    }
}
