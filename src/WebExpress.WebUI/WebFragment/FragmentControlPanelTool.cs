using System;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a control panel tool that is part of a fragment and implements the IFragmentControl interface.
    /// </summary>
    public class FragmentControlPanelTool : ControlPanelTool, IFragmentControl<ControlPanelTool>
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context of the fragment.</param>
        public FragmentControlPanelTool(IFragmentContext fragmentContext)
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
