﻿using WebExpress.WebUI.WebControl;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebFragment
{
    public class FragmentControlSplitButtonItemLink : ControlSplitButtonItemLink, IFragment
    {
        /// <summary>
        /// Returns the context of the fragment.
        /// </summary>
        public IFragmentContext FragmentContext { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the fragment or null.</param>
        public FragmentControlSplitButtonItemLink(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="page">The page where the fragment is active.</param>
        public virtual void Initialization(IFragmentContext context, IPage page)
        {
            FragmentContext = context;
        }
    }
}
