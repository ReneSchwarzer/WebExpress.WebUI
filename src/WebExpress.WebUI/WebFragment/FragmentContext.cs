﻿using System.Collections.Generic;
using System.Globalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebModule;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.WebFragment
{
    public class FragmentContext : IFragmentContext
    {
        /// <summary>
        /// Returns the context of the associated plugin.
        /// </summary>
        public IPluginContext PluginContext { get; internal set; }

        /// <summary>
        /// Returns the application context.
        /// </summary>
        public IApplicationContext ApplicationContext => ModuleContext.ApplicationContext;

        /// <summary>
        /// Returns the module context.
        /// </summary>
        public IModuleContext ModuleContext { get; internal set; }

        /// <summary>
        /// Returns the conditions that must be met for the component to be active.
        /// </summary>
        public ICollection<ICondition> Conditions { get; internal set; } = new List<ICondition>();

        /// <summary>
        /// Returns the culture.
        /// </summary>
        public CultureInfo Culture { get; set; }

        /// <summary>
        /// Determines whether the component is created once and reused on each execution.
        /// </summary>
        public bool Cache { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FragmentContext()
        {
        }
    }
}
