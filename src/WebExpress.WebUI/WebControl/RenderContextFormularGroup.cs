using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class RenderContextFormularGroup : RenderContextFormular
    {
        /// <summary>
        /// Die Gruppe, indem das Steuerelement gerendert wird
        /// </summary>
        public ControlFormItemGroup Group { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="formular">The form in which the control is rendered.</param>
        /// <param name="group">Die Gruppe</param>
        public RenderContextFormularGroup(RenderContext context, ControlForm formular, ControlFormItemGroup group)
            : base(context, formular)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="group">Die Gruppe</param>
        public RenderContextFormularGroup(RenderContextFormular context, ControlFormItemGroup group)
            : base(context)
        {
            Group = group;
        }
    }
}
