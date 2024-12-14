using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebPage
{
    /// <summary>
    /// Provides the context for rendering controls within a web page.
    /// </summary>
    public interface IRenderControlContext : IRenderContext
    {
        /// <summary>
        /// Adds or replaces a java script if it exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="code">The java script code.</param>
        void AddScript(string key, string code);

        /// <summary>
        /// Adds a java script.
        /// </summary>
        /// <param name="url">The link of the java script file.</param>
        void AddScriptLink(string url);
    }
}
