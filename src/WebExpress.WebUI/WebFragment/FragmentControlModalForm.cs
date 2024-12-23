using System;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a modal form control fragment that can display a form in a modal dialog.
    /// </summary>
    public class FragmentControlModalForm : ControlModalForm, IFragmentControl<ControlModalForm>
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context of the fragment.</param>
        public FragmentControlModalForm(IFragmentContext fragmentContext)
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
