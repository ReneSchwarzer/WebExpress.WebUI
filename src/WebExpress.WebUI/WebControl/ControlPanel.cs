﻿using System.Collections.Generic;
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
        private readonly List<IControl> _content = [];

        /// <summary> 
        /// Returns the content of the panel. 
        /// </summary> 
        /// <remarks> 
        /// The content property holds a collection of controls that represent the visual and interactive elements 
        /// within this container. 
        /// </remarks>
        public IEnumerable<IControl> Content => _content;

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
            _content.AddRange(children.Where(x => x != null));
        }

        /// <summary> 
        /// Adds one or more controls to the content of the control panel.
        /// </summary> 
        /// <param name="controls">The controls to add to the content.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of 
        /// the control panel. It is useful for dynamically constructing the user interface by appending 
        /// various controls to the panel's content. 
        /// Example usage: 
        /// <code> 
        /// var panel = new ControlPanel(); 
        /// var text1 = new ControlText { Text = "Save" };
        /// var text2 = new ControlText { Text = "Cancel" };
        /// panel.Add(text1, text2);
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public virtual void Add(params IControl[] controls)
        {
            _content.AddRange(controls);
        }

        /// <summary> 
        /// Adds one or more controls to the content of the control panel.
        /// </summary> 
        /// <param name="controls">The controls to add to the content.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of 
        /// the control panel. It is useful for dynamically constructing the user interface by appending 
        /// various controls to the panel's content. 
        /// Example usage: 
        /// <code> 
        /// var panel = new ControlPanel(); 
        /// var text1 = new ControlText { Text = "Save" };
        /// var text2 = new ControlText { Text = "Cancel" };
        /// panel.Add(new List<IControl>([text1, text2]));
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public virtual void Add(IEnumerable<IControl> controls)
        {
            _content.AddRange(controls);
        }

        /// <summary>
        /// Removes a control from the content of the control panel.
        /// </summary>
        /// <param name="control">The control to remove from the content.</param>
        /// <remarks>
        /// This method allows removing a specific control from the <see cref="Content"/> collection of 
        /// the control panel.
        /// </remarks>
        public void Remove(Control control)
        {
            _content.Remove(control);
        }
        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            return new HtmlElementTextContentDiv(_content.Select(x => x.Render(renderContext)).ToArray())
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
