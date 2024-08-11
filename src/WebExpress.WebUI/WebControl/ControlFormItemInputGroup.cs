using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    public class ControlFormItemInputGroup : ControlFormItemInput
    {
        /// <summary>
        /// Returns or sets the group.
        /// </summary>
        public ControlFormItemGroup Group { get; private set; }

        /// <summary>
        /// Determines whether the inputs are valid.
        /// </summary>
        public override ICollection<ValidationResult> ValidationResults => Group != null ? Group.ValidationResults : new List<ValidationResult>();

        /// <summary>
        /// Returns the most serious validation result.
        /// </summary>
        public override TypesInputValidity ValidationResult => Group != null ? Group.ValidationResult : TypesInputValidity.Default;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemInputGroup(string id = null)
            : base(id)
        {
            Name = Id;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="group">The name.</param>
        public ControlFormItemInputGroup(string id, ControlFormItemGroup group)
            : base(id)
        {
            Name = id;
            Group = group;
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public override void Initialize(RenderContextForm context)
        {
            if (Group != null)
            {
                Group.Initialize(context);
            }
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContextForm context)
        {
            return Group?.Render(context);
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="context">The context in which the inputs are validated.</param>
        public override void Validate(RenderContextForm context)
        {
            if (Disabled)
            {
                return;
            }

            Group.Validate(context);
        }
    }
}
