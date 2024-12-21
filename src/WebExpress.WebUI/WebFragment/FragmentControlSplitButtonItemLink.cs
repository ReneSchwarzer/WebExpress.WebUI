using System;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a link item within a split button control that is part of a fragment.
    /// </summary>
    public class FragmentControlSplitButtonItemLink : ControlSplitButtonItemLink, IFragmentControl<ControlSplitButtonItemLink>
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context of the fragment.</param>
        public FragmentControlSplitButtonItemLink(IFragmentContext fragmentContext)
            : base(fragmentContext?.FragmentId?.ToString())
        {
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
