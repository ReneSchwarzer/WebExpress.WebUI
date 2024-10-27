using System;
using System.Collections.Generic;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.WebFragment.Model
{
    /// <summary>
    /// Fragments are components that can be integrated into pages to dynamically expand functionalities.
    /// </summary>
    internal class FragmentItem : IDisposable
    {
        /// <summary>
        /// Returns the context of the associated plugin.
        /// </summary>
        public IPluginContext PluginContext { get; set; }

        /// <summary>
        /// Returns the application context.
        /// </summary>
        public IApplicationContext ApplicationContext { get; set; }

        /// <summary>
        /// Returns the fragment context.
        /// </summary>
        public IFragmentContext FragmentContext { get; set; }

        /// <summary>
        /// The type of fragment.
        /// </summary>
        public Type FragmentClass { get; set; }

        /// <summary>
        /// Returns the section.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Returns the scopes.
        /// </summary>
        public IEnumerable<string> Scopes { get; set; }

        /// <summary>
        /// Returns the conditions that must be met for the component to be active.
        /// </summary>
        public ICollection<ICondition> Conditions { get; set; }

        /// <summary>
        /// The order of the fragment.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Determines whether the component is created once and reused on each execution.
        /// </summary>
        public bool Cache { get; set; }

        /// <summary>
        /// Performs application-specific tasks related to sharing, returning, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Convert the resource element to a string.
        /// </summary>
        /// <returns>The resource element in its string representation.</returns>
        public override string ToString()
        {
            return $"Fragment: '{FragmentContext.FragmentId}'";
        }
    }
}
