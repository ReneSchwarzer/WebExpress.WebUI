using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlPanelNavbar : ControlPanel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelNavbar(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The navbar items.</param>
        public ControlPanelNavbar(string id, params Control[] items)
            : base(id, items)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The navbar items.</param>
        public ControlPanelNavbar(params Control[] items)
            : base(items)
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
            var html = new HtmlElementSectionNav()
            {
                Id = Id,
                Class = Css.Concatenate("navbar", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            html.Elements.AddRange(from x in Content select x?.Render(context));

            return html;
        }
    }
}
