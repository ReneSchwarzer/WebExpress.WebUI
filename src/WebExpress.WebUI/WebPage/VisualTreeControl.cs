﻿using System.Collections.Generic;
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
        /// <summary>
        /// Returns the title of the html document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Returns the favicons.
        /// </summary>
        public List<Favicon> Favicons { get; } = [];

        /// <summary>
        /// Returns the internal stylesheet.  
        /// </summary>
        public List<string> Styles { get; } = [];

        /// <summary>
        /// Returns the links to the java script files to be used, which are inserted in the header.
        /// </summary>
        public List<string> HeaderScriptLinks { get; } = [];

        /// <summary>
        /// Returns the links to the java script files to be used.
        /// </summary>
        public List<string> ScriptLinks { get; } = [];

        /// <summary>
        /// Returns the links to the java script files to be used, which are inserted in the header.
        /// </summary>
        public List<string> HeaderScripts { get; } = [];

        /// <summary>
        /// Returns the links to the java script files to be used.
        /// </summary>
        public IDictionary<string, string> Scripts { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Returns the links to the css files to be used.
        /// </summary>
        public List<string> CssLinks { get; } = [];

        /// <summary>
        /// Returns the meta information.
        /// </summary>
        public List<KeyValuePair<string, string>> Meta { get; } = [];

        /// <summary>
        /// Returns the content.
        /// </summary>
        public List<Control> Content { get; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VisualTreeControl()
        {
        }

        /// <summary>
        /// Adds or replaces a java script if it exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="code">The java script code.</param>
        public virtual void AddScript(string key, string code)
        {
        }

        /// <summary>
        /// Adds a java script.
        /// </summary>
        /// <param name="url">The link of the java script file.</param>
        public virtual void AddScriptLink(string url)
        {
        }

        /// <summary>
        /// Adds a java script in the header.
        /// </summary>
        /// <param name="url">The link of the java script file.</param>
        public virtual void AddHeaderScriptLinks(string url)
        {
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
