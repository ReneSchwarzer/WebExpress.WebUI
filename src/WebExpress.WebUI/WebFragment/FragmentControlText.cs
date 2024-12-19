using System;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a text control fragment that can be processed and rendered within a web page.
    /// </summary>
    public abstract class FragmentControlText : ControlText, IFragmentControl<ControlText>
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context of the fragment.</param>
        protected FragmentControlText(IFragmentContext fragmentContext)
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
