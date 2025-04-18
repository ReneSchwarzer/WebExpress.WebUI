using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.WebUI.Test
{
    /// <summary>
    /// A dummy fragment for testing purposes.
    /// </summary>
    [Section<TestSectionFragmentControlTree>()]
    public sealed class TestFragmentControlTree : FragmentControlList
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public TestFragmentControlTree(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Add(new ControlListItem());
        }
    }
}
