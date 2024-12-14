using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a control panel that can contain multiple child controls and manage their layout and rendering.
    /// </summary>
    public class ControlPanel : Control
    {
        private readonly List<IControl> _children = [];

        // <summary>
        // Returns the child controls contained within the control panel.
        // </summary>
        public IEnumerable<IControl> Children => _children;

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
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="children">The child controls to be added to the panel.</param>
        public ControlPanel(string id = null, params IControl[] children)
            : base(id)
        {
            _children.AddRange(children.Where(x => x != null));
        }

        /// <summary>
        /// Adds one or more child controls to the control panel.
        /// </summary>
        /// <param name="children">The child controls to add.</param>
        public void AddChild(params IControl[] children)
        {
            _children.AddRange(children);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            return new HtmlElementTextContentDiv(Children.Select(x => x.Render(renderContext)).ToArray())
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
