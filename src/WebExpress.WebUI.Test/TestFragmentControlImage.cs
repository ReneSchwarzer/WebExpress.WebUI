﻿using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.WebUI.Test
{
    /// <summary>
    /// A dummy fragment for testing purposes.
    /// </summary>
    [Section<TestSectionE>()]
    public sealed class TestFragmentControlImage : FragmentControlImage
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public TestFragmentControlImage(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Uri = "/a/b/c";
        }
    }
}
