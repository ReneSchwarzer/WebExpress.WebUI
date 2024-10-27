using System;
using System.Collections.Generic;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Interface for managing web fragments.
    /// </summary>
    public interface IFragmentManager : IComponentManager
    {
        /// <summary>
        /// An event that fires when a fragment is added.
        /// </summary>
        public event EventHandler<IFragmentContext> AddFragment;

        /// <summary>
        /// An event that fires when a fragment is removed.
        /// </summary>
        public event EventHandler<IFragmentContext> RemoveFragment;

        /// <summary>
        /// Returns all fragment contexts that belong to a given section.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <returns>An enumeration of the filtered fragment contexts.</returns>
        IEnumerable<IFragmentContext> GetFragmentContexts(string section);

        /// <summary>
        /// Returns all fragment contexts that belong to a given application.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="applicationContext">The allpication context.</param>
        /// <returns>An enumeration of the filtered fragment contexts.</returns>
        IEnumerable<IFragmentContext> GetFragmentContexts(string section, IApplicationContext applicationContext);

        /// <summary>
        /// Determines all fragments that match the parameters.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="page">The page that holds the fragments.</param>
        /// <returns>A list of fragments.</returns>
        IEnumerable<FragmentCacheItem> GetCacheableFragments<T>(string section, IPage page) where T : IControl;

        /// <summary>
        /// Determines all fragments that match the parameters.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="page">The page that holds the fragments.</param>
        /// <param name="scopes">The scopes where the fragments exists.</param>
        /// <returns>A list of fragments.</returns>
        IEnumerable<FragmentCacheItem> GetCacheableFragments<T>(string section, IPage page, IEnumerable<string> scopes) where T : IControl;
    }
}
