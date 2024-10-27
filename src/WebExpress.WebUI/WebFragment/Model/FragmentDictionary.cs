using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebUI.WebFragment.Model
{
    /// <summary>
    /// Represents a dictionary that maps plugin contexts to application contexts,
    /// which in turn maps to a dictionary of string keys and lists of FragmentItem objects.
    /// key = plugin context 
    /// value application context { key = section:context, value = component item }
    /// </summary>
    internal class FragmentDictionary : Dictionary<IPluginContext, Dictionary<IApplicationContext, Dictionary<Type, List<FragmentItem>>>>
    {
        /// <summary>
        /// Adds a fragment item to the dictionary.
        /// </summary>
        /// <param name="pluginContext">The plugin context.</param>
        /// <param name="applicationContext">The application context.</param>
        /// <param name="fragmentItem">The fragment item.</param>
        /// <returns>True if the fragment item was added successfully, false if an element with the same status code already exists.</returns>
        public bool AddFragmentItem(IPluginContext pluginContext, IApplicationContext applicationContext, FragmentItem fragmentItem)
        {
            var type = fragmentItem.FragmentClass;

            if (!typeof(IFragment).IsAssignableFrom(type))
            {
                return false;
            }

            if (!ContainsKey(pluginContext))
            {
                this[pluginContext] = [];
            }

            var appContextDict = this[pluginContext];

            if (!appContextDict.ContainsKey(applicationContext))
            {
                appContextDict[applicationContext] = [];
            }

            var fragmentDict = appContextDict[applicationContext];

            if (!fragmentDict.ContainsKey(type))
            {
                fragmentDict[type] = [];
                return true;
            }

            return false; // item with the same fragment class already exists
        }

        /// <summary>
        /// Removes fragments from the dictionary.
        /// </summary>
        /// <param name="pluginContext">The plugin context.</param>
        /// <returns>An IEnumerable of fragment contexts that were removed.</returns>
        public IEnumerable<IFragmentContext> RemoveFragments(IPluginContext pluginContext)
        {
            var fragments = GetFragments(pluginContext);

            Remove(pluginContext);

            return fragments;
        }

        /// <summary>
        /// Removes fragments from the dictionary.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        /// <returns>An IEnumerable of fragment contexts that were removed.</returns>
        public IEnumerable<IFragmentContext> RemoveFragments(IApplicationContext applicationContext)
        {
            foreach (var appContextDict in this)
            {
                if (appContextDict.Value.TryGetValue(applicationContext, out var fragmentDict))
                {
                    appContextDict.Value.Remove(applicationContext);

                    if (appContextDict.Value.Count == 0)
                    {
                        Remove(appContextDict.Key);
                    }

                    return fragmentDict.Values.SelectMany(x => x).Select(x => x.FragmentContext);
                }
            }

            return [];
        }

        /// <summary>
        /// Returns the fragment items from the dictionary.
        /// </summary>
        /// <typeparam name="T">The type of fragment.</typeparam>
        /// <param name="applicationContext">The application context.</param>
        /// <returns>An IEnumerable of fragment items</returns>
        public IEnumerable<FragmentItem> GetFragmentItems<T>(IApplicationContext applicationContext) where T : IFragment
        {
            return GetFragmentItems(applicationContext, typeof(T));
        }

        /// <summary>
        /// Returns the fragment items from the dictionary.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        /// <typeparam name="fragmentType">The type of fragment.</typeparam>
        /// <returns>An IEnumerable of fragment items</returns>
        public IEnumerable<FragmentItem> GetFragmentItems(IApplicationContext applicationContext, Type fragmentType)
        {
            if (!typeof(IFragment).IsAssignableFrom(fragmentType))
            {
                return [];
            }

            if (ContainsKey(applicationContext?.PluginContext))
            {
                var appContextDict = this[applicationContext?.PluginContext];

                if (appContextDict.ContainsKey(applicationContext))
                {
                    var fragmentDict = appContextDict[applicationContext];

                    if (fragmentDict.ContainsKey(fragmentType))
                    {
                        return fragmentDict[fragmentType];
                    }
                }
            }

            return [];
        }

        /// <summary>
        /// Returns all fragment contexts for a given plugin context.
        /// </summary>
        /// <param name="pluginContext">The plugin context.</param>
        /// <returns>An IEnumerable of fragment contexts.</returns>
        public IEnumerable<IFragmentContext> GetFragments(IPluginContext pluginContext)
        {
            return this.Where(x => x.Key == pluginContext)
                       .SelectMany(x => x.Value.Values)
                       .SelectMany(x => x.Values)
                       .SelectMany(x => x)
                       .Select(x => x.FragmentContext);
        }
    }
}
