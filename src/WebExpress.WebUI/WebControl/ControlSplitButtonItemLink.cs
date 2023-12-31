﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlSplitButtonItemLink : ControlLink, IControlSplitButtonItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlSplitButtonItemLink(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return base.Render(context);
        }
    }
}
