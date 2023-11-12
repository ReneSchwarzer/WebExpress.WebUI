using WebExpress.WebUI.WebControl;
using WebExpress.Core.WebPage;

namespace WebExpress.WebUI.WebFragment
{
    public interface IFragment : IControl
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        IFragmentContext FragmentContext { get; }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="page">The page where the fragment is active.</param>
        void Initialization(IFragmentContext context, IPage page);
    }
}
