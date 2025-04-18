using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.WebUI.Test
{
    /// <summary>
    /// A dummy fragment for testing purposes.
    /// </summary>
    [Section<TestSectionFragmentControlPanelFlexbox>()]
    public sealed class TestFragmentControlPanelFlexbox : FragmentControlPanelFlexbox
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public TestFragmentControlPanelFlexbox(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
        }
    }
}
