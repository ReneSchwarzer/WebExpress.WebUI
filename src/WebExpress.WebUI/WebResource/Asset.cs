﻿using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebResource;

namespace WebExpress.WebUI.WebResource
{
    /// <summary>
    /// Delivery of a resource embedded in the assembly.
    /// </summary>
    [Segment("assets")]
    [ContextPath("/")]
    [IncludeSubPaths(true)]
    [Module<Module>]
    public sealed class Asset : ResourceAsset
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Asset()
        {
        }
    }
}