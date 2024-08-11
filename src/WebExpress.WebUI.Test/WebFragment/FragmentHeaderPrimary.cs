using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using static System.Collections.Specialized.BitVector32;

namespace WebExpress.WebUI.Test.WebFragment
{
    /// <summary>
    /// A dummy fragment for testing purposes.
    /// </summary>
    [Section(SectionControl.HeaderPrimary)]
    [Module<TestModule>]
    [Scope<ControlForm>]
    public sealed class FragmentHeaderPrimary : FragmentControlText
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FragmentHeaderPrimary()
        {
            Text = "FragmentHeaderPrimary";
            Format = TypeFormatText.Paragraph;
        }
    }
}
