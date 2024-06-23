using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    public class ControlFormItemPanel : ControlFormItem
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public IEnumerable<IControl> Content { get; private set; } = new List<IControl>();

        /// <summary>
        /// Returns or sets the arrangement of the content.
        /// </summary>
        public TypeDirection Direction
        {
            get => (TypeDirection)GetProperty(TypeDirection.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Fixed or full-width adjustment.
        /// </summary>
        public TypePanelContainer Fluid
        {
            get => (TypePanelContainer)GetProperty(TypePanelContainer.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemPanel(string id)
            : base(id)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlFormItemPanel(string id, IEnumerable<Control> content)
            : base(id)
        {
            Content = content;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        public override void Initialize(RenderContextFormular context)
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContextFormular context)
        {
            return new HtmlElementTextContentDiv(from x in Content select x.Render(context))
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
