using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a form item input group control.
    /// </summary>
    public class ControlFormItemInputGroup : ControlFormItemInput
    {
        /// <summary>
        /// Returns the group.
        /// </summary>
        public ControlFormItemGroup Group { get; private set; }

        /// <summary>
        /// Determines whether the inputs are valid.
        /// </summary>
        public override IEnumerable<ValidationResult> ValidationResults => Group != null ? Group.ValidationResults : [];

        /// <summary>
        /// Returns the most serious validation result.
        /// </summary>
        public override TypesInputValidity ValidationResult => Group != null ? Group.ValidationResult : TypesInputValidity.Default;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="group">The group of form items.</param>
        public ControlFormItemInputGroup(string id = null, ControlFormItemGroup group = null)
            : base(id)
        {
            Name = id;
            Group = group;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None);
        }

        /// <summary>
        /// Initializes the form emement.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            if (Group != null)
            {
                Group.Initialize(renderContext);
            }
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext, IVisualTreeControl visualTree)
        {
            return Group?.Render(renderContext, visualTree);
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public virtual void Validate(IRenderControlFormContext renderContext)
        {
            if (Disabled)
            {
                return;
            }

            Group.Validate(renderContext);
        }
    }
}
