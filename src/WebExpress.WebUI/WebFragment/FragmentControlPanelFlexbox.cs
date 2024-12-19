using System;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a control panel that uses a flexbox layout to arrange its child controls within a fragment context.
    /// </summary>
    public class FragmentControlPanelFlexbox : ControlPanelFlexbox, IFragmentControl<ControlPanelFlexbox>
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context of the fragment.</param>
        public FragmentControlPanelFlexbox(IFragmentContext fragmentContext)
            : base(fragmentContext?.FragmentId?.ToString())
        {
            FragmentContext = fragmentContext;
        }

        /// <summary>
        /// Releases all resources used by the fragment.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
