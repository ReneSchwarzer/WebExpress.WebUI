using System.Collections.Generic;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Interface representing the context of a web fragment.
    /// Provides access to plugin context, application context, conditions for activation, and caching behavior.
    /// </summary>
    public interface IFragmentContext : IContext
    {
        /// <summary>
        /// Returns the context of the associated plugin.
        /// </summary>
        IPluginContext PluginContext { get; }

        /// <summary>
        /// Returns the application context.
        /// </summary>
        IApplicationContext ApplicationContext { get; }

        /// <summary>
        /// Gets the unique identifier for the fragment.
        /// </summary>
        string FragmentId { get; }

        /// <summary>
        /// Returns the conditions that must be met for the component to be active.
        /// </summary>
        ICollection<ICondition> Conditions { get; }

        /// <summary>
        /// Determines whether the component is created once and reused on each execution.
        /// </summary>
        bool Cache { get; }
    }
}
