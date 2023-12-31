﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebModule;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.SettingPage
{
    /// <summary>
    /// key = The context of the plugin.
    /// value = meta data
    /// </summary>
    public class SettingPageDictionary : Dictionary<IPluginContext, SettingPageDictionaryItemContext>
    {
        /// <summary>
        /// Adds a settings page.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin.</param>
        /// <param name="item">The settings page to insert.</param>
        public void AddPage(IPluginContext pluginContext, SettingPageDictionaryItem item)
        {
            if (!ContainsKey(pluginContext))
            {
                Add(pluginContext, new SettingPageDictionaryItemContext());
            }

            this[pluginContext].AddPage(item.Context, item.Section, item.Group, item);
        }

        /// <summary>
        /// Finds a settings page in an application by its id.
        /// </summary>
        /// <param name="application">The context of the application.</param>
        /// <param name="module">The context of the module.</param>
        /// <param name="pageId">The id of the setting page.</param>
        /// <returns>The setting page found or null.</returns>
        /// <summary>
        public SettingPageSearchResult FindPage(IApplicationContext application, IModuleContext module, string pageId)
        {
            var results = Values
                .SelectMany(c => c.Values)
                .SelectMany(s => s.Values)
                .SelectMany(g => g.Values)
                .SelectMany(i => i)
                .Where(x => x != null && x.ModuleId.Equals(module.ModuleId, StringComparison.OrdinalIgnoreCase))
                .Select(x => new SettingPageSearchResult()
                {
                    Context = x.Context,
                    Section = x.Section,
                    Group = x.Group,
                    Item = x
                });

            return results.FirstOrDefault();
        }

        /// <summary>
        /// Returns all existing contexts.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <returns>A collection of all contexts.</returns>
        /// <summary>
        public IEnumerable<SettingPageDictionaryItemContext> GetContexts(string applicationId)
        {
            var resourceManager = ComponentManager.ResourceManager;

            var results = Values
                 .Where(
                     x => x.SelectMany(c => c.Value)
                           .SelectMany(s => s.Value)
                           .SelectMany(g => g.Value)
                           .Where
                           (
                               x =>
                               resourceManager.GetResorces(applicationId, x.ModuleId, x.ResourceId) != null
                           )
                           .Any()
             );

            return results;
        }

        /// <summary>
        /// Returns all sections that have the same setting context.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="context">The context.</param>
        /// <returns>A listing of all sections of the same context.</returns>
        /// <summary>
        public IEnumerable<SettingPageDictionaryItemSection> GetSections(string applicationId, string context)
        {
            var resourceManager = ComponentManager.ResourceManager;

            var results = Values
                .SelectMany(x => x.Values)
                .Where(
                    x => x.SelectMany(s => s.Value)
                          .SelectMany(g => g.Value)
                          .Where
                          (
                              x => x != null &&
                              resourceManager.GetResorces(applicationId, x.ModuleId, x.ResourceId) != null
                          )
                          .Any()
                );

            return results;
        }
    }
}
