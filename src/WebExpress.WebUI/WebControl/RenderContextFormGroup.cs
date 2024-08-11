using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class RenderContextFormGroup : RenderContextForm
    {
        /// <summary>
        /// Die Gruppe, indem das Steuerelement gerendert wird
        /// </summary>
        public ControlFormItemGroup Group { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="form">The form in which the control is rendered.</param>
        /// <param name="group">Die Gruppe</param>
        public RenderContextFormGroup(RenderContext context, ControlForm form, ControlFormItemGroup group)
            : base(context, form)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="group">Die Gruppe</param>
        public RenderContextFormGroup(RenderContextForm context, ControlFormItemGroup group)
            : base(context)
        {
            Group = group;
        }
    }
}
