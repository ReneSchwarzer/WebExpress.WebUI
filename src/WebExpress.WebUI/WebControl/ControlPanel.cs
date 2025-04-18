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
        /// <param name="controls">The child controls to be added to the panel.</param>
        public ControlPanel(string id = null, params IControl[] controls)
            : base(id)
        {
            _content.AddRange(controls.Where(x => x != null));
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
        /// var text1 = new ControlText { Text = "A" };
        /// var text2 = new ControlText { Text = "B" };
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
        /// var text1 = new ControlText { Text = "A" };
        /// var text2 = new ControlText { Text = "B" };
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
        public virtual void Remove(IControl control)
        {
            _content.Remove(control);
        }

        /// <summary>
        /// Clears all controls from the content of the control panel.
        /// </summary>
        /// <remarks>
        /// This method removes all controls from the <see cref="Content"/> collection of the control panel.
        /// It is useful for resetting the panel's content to an empty state.
        /// </remarks>
        public virtual void Clear()
        {
            _content.Clear();
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return new HtmlElementTextContentDiv(_content
                .Select(x => x.Render(renderContext, visualTree))
                .ToArray())
            {
                Id = Id,
                Class = GetClasses(),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
