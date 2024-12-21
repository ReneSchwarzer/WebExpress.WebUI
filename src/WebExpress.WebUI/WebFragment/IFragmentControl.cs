using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a fragment interface with a generic type parameter.
    /// </summary>
    public interface IFragmentControl : IFragmentControl<IControl>
    {
    }

    /// <summary>
    /// Represents a fragment interface with a generic type parameter.
    /// </summary>
    /// <typeparam name="T">The type of control that implements the IControl interface.</typeparam>
    public interface IFragmentControl<T> : IFragment<IRenderControlContext> where T : class, IControl
    {
        /// <summary>
        /// Gets the context of the fragment.
        /// </summary>
        IFragmentContext FragmentContext { get; }
    }
}
