using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents a fragment control interface.
    /// </summary>
    public interface IFragmentControl : IFragment<IRenderControlContext>, IControl
    {
    }

    /// <summary>
    /// Represents a fragment interface with a generic type parameter.
    /// </summary>
    /// <typeparam name="T">The type of control that implements the IControl interface.</typeparam>
    public interface IFragmentControl<T> : IFragmentControl where T : class, IControl
    {
        /// <summary>
        /// Gets the context of the fragment.
        /// </summary>
        IFragmentContext FragmentContext { get; }
    }
}
