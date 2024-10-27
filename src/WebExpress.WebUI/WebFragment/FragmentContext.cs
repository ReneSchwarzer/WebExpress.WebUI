﻿using System.Collections.Generic;
using System.Globalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Represents the context for a web fragment, including plugin context, application context,
    /// conditions for activation, culture information, and caching behavior.
    /// </summary>
    public class FragmentContext : IFragmentContext
    {
        /// <summary>
        /// Returns the context of the associated plugin.
        /// </summary>
        public IPluginContext PluginContext { get; internal set; }

        /// <summary>
        /// Returns the application context.
        /// </summary>
        public IApplicationContext ApplicationContext { get; internal set; }

        /// <summary>
        /// Gets the unique identifier for the fragment.
        /// </summary>
        public string FragmentId { get; internal set; }

        /// <summary>
        /// Returns the conditions that must be met for the component to be active.
        /// </summary>
        public ICollection<ICondition> Conditions { get; internal set; } = [];

        /// <summary>
        /// Returns the culture.
        /// </summary>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Determines whether the component is created once and reused on each execution.
        /// </summary>
        public bool Cache { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FragmentContext()
        {
        }
    }
}
