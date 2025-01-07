using System;
using System.Collections.Generic;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Provides data for the RetrieveVirtualItem event.
    /// </summary>
    public class RetrieveVirtualItemEventArgs : EventArgs
    {
        /// <summary>
        /// Returns the context for rendering controls within a web page.
        /// </summary>
        public IRenderControlContext RenderContext { get; }

        /// <summary>
        /// Returns or sets the items to retrieve.
        /// </summary>
        public IEnumerable<ControlListItem> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="renderContext">The context for rendering controls within a web page.</param>
        public RetrieveVirtualItemEventArgs(IRenderControlContext renderContext)
        {
            RenderContext = renderContext;
        }
    }
}
