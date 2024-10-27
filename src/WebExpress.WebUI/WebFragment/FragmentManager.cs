using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebPlugin;
using WebExpress.WebUI.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment.Model;

namespace WebExpress.WebUI.WebFragment
{
    /// <summary>
    /// Fragment manager.
    /// </summary>
    public sealed class FragmentManager : IFragmentManager
    {
        private readonly IComponentHub _componentHub;
        private readonly IHttpServerContext _httpServerContext;
        private readonly FragmentDictionary _dictionary = [];

        /// <summary>
        /// An event that fires when an fragment is added.
        /// </summary>
        public event EventHandler<IFragmentContext> AddFragment;

        /// <summary>
        /// An event that fires when an fragment is removed.
        /// </summary>
        public event EventHandler<IFragmentContext> RemoveFragment;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="httpServerContext">The reference to the context of the host.</param>
        private FragmentManager(IComponentHub componentHub, IHttpServerContext httpServerContext)
        {
            _componentHub = componentHub;
            _httpServerContext = httpServerContext;

            _componentHub.PluginManager.AddPlugin += OnAddPlugin;
            _componentHub.PluginManager.RemovePlugin += OnRemovePlugin;
            _componentHub.ApplicationManager.AddApplication += OnAddApplication;
            _componentHub.ApplicationManager.RemoveApplication += OnRemoveApplication;

            _httpServerContext.Log.Debug
            (
                I18N.Translate("webexpress.webui:fragmentmanager.initialization")
            );
        }

        /// <summary>
        /// Discovers and binds fragments to an application.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin whose fragments are to be associated.</param>
        private void Register(IPluginContext pluginContext)
        {
            if (_dictionary.ContainsKey(pluginContext))
            {
                return;
            }

            Register(pluginContext, _componentHub.ApplicationManager.GetApplications(pluginContext));
        }

        /// <summary>
        /// Discovers and binds fragments to an application.
        /// </summary>
        /// <param name="applicationContext">The context of the application whose fragments are to be associated.</param>
        private void Register(IApplicationContext applicationContext)
        {
            foreach (var pluginContext in _componentHub.PluginManager.GetPlugins(applicationContext))
            {
                if (_dictionary.TryGetValue(pluginContext, out var appDict) && appDict.ContainsKey(applicationContext))
                {
                    continue;
                }

                Register(pluginContext, [applicationContext]);
            }
        }

        /// <summary>
        /// Registers pages for a given plugin and application context.
        /// </summary>
        /// <param name="pluginContext">The plugin context.</param>
        /// <param name="applicationContext">The application context (optional).</param>
        private void Register(IPluginContext pluginContext, IEnumerable<IApplicationContext> applicationContexts)
        {
            var assembly = pluginContext.Assembly;

            foreach (var fragmentType in assembly.GetTypes().Where
                (
                    x => x.IsClass &&
                    x.IsSealed &&
                    x.IsPublic &&
                    (
                        x.GetInterfaces().Contains(typeof(IFragment)) ||
                        x.GetInterfaces().Contains(typeof(IFragmentDynamic))
                    )
                ))
            {
                var id = fragmentType.FullName?.ToLower();
                var scopes = new List<string>();
                var section = string.Empty;
                var conditions = new List<ICondition>();
                var cache = false;
                var order = 0;

                // determining attributes
                foreach (var customAttribute in fragmentType.CustomAttributes.Where
                (
                    x => x.AttributeType.GetInterfaces()
                            .Contains(typeof(IEndpointAttribute))
                ))
                {
                    if (customAttribute.AttributeType.Name == typeof(ScopeAttribute<>).Name && customAttribute.AttributeType.Namespace == typeof(ScopeAttribute<>).Namespace)
                    {
                        scopes.Add(customAttribute.AttributeType.GenericTypeArguments.FirstOrDefault()?.FullName?.ToLower());
                    }
                    else if (customAttribute.AttributeType.Name == typeof(ConditionAttribute<>).Name && customAttribute.AttributeType.Namespace == typeof(ConditionAttribute<>).Namespace)
                    {
                        var condition = customAttribute.AttributeType.GenericTypeArguments.FirstOrDefault();
                        conditions.Add(Activator.CreateInstance(condition) as ICondition);
                    }
                    else if (customAttribute.AttributeType == typeof(CacheAttribute))
                    {
                        cache = true;
                    }
                }

                foreach (var customAttribute in fragmentType.CustomAttributes.Where
                (
                    x => x.AttributeType.GetInterfaces().Contains(typeof(IFragmentAttribute))
                ))
                {
                    if (customAttribute.AttributeType == typeof(SectionAttribute))
                    {
                        section = customAttribute.ConstructorArguments.FirstOrDefault().Value?.ToString().ToLower();
                    }
                    else if (customAttribute.AttributeType == typeof(OrderAttribute))
                    {
                        try
                        {
                            order = Convert.ToInt32(customAttribute.ConstructorArguments.FirstOrDefault().Value);
                        }
                        catch
                        {
                        }
                    }
                }

                // check section
                if (string.IsNullOrWhiteSpace(section))
                {
                    _httpServerContext.Log.Warning(I18N.Translate
                    (
                        "webexpress.webui:fragmentmanager.error.section"
                    ));

                    continue;
                }

                // assign the fragment to existing applications
                foreach (var applicationContext in _componentHub.ApplicationManager.GetApplications(pluginContext))
                {
                    // register fragment
                    foreach (var context in scopes.Count != 0 ? scopes : [""])
                    {
                        var fragmentContext = new FragmentContext()
                        {
                            PluginContext = pluginContext,
                            ApplicationContext = applicationContext,
                            FragmentId = id,
                            Cache = cache,
                            //Scopes = scopes,
                            Conditions = conditions
                        };

                        var fragmentItem = new FragmentItem()
                        {
                            PluginContext = pluginContext,
                            ApplicationContext = applicationContext,
                            FragmentContext = fragmentContext,
                            FragmentClass = fragmentType,
                            Order = order,
                            Cache = cache,
                            Conditions = conditions,
                            Section = section,
                            Scopes = scopes
                        };

                        if (_dictionary.AddFragmentItem(pluginContext, applicationContext, fragmentItem))
                        {
                            OnAddFragment(fragmentContext);

                            _httpServerContext?.Log.Debug
                            (
                                I18N.Translate
                                (
                                    "webexpress:fragmentmanager.register",
                                    id,
                                    section,
                                    applicationContext.ApplicationId
                                )
                            );
                        }
                    }
                }
            }

            Log();
        }

        /// <summary>
        /// Removes all components associated with the specified plugin context.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin that contains the components to remove.</param>
        internal void Remove(IPluginContext pluginContext)
        {
            if (pluginContext == null)
            {
                return;
            }

            var fragments = _dictionary.RemoveFragments(pluginContext);

            foreach (var fragment in fragments)
            {
                OnRemoveFragment(fragment);
            }
        }

        /// <summary>
        /// Removes all fragments associated with the specified application context.
        /// </summary>
        /// <param name="applicationContext">The context of the application that contains the fragments to remove.</param>
        internal void Remove(IApplicationContext applicationContext)
        {
            if (applicationContext == null)
            {
                return;
            }

            var fragments = _dictionary.RemoveFragments(applicationContext);

            foreach (var fragment in fragments)
            {
                OnRemoveFragment(fragment);
            }
        }

        /// <summary>
        /// Raises the AddFragment event.
        /// </summary>
        /// <param name="fragmentContext">The fragment context.</param>
        private void OnAddFragment(IFragmentContext fragmentContext)
        {
            AddFragment?.Invoke(this, fragmentContext);
        }

        /// <summary>
        /// Raises the RemoveFragment event.
        /// </summary>
        /// <param name="fragmentContext">The fragment context.</param>
        private void OnRemoveFragment(IFragmentContext fragmentContext)
        {
            RemoveFragment?.Invoke(this, fragmentContext);
        }

        /// <summary>
        /// Raises the event when an plugin is added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The context of the plugin being added.</param>
        private void OnAddPlugin(object sender, IPluginContext e)
        {
            Register(e);
        }

        /// <summary>  
        /// Raises the event when a plugin is removed.  
        /// </summary>  
        /// <param name="sender">The source of the event.</param>  
        /// <param name="e">The context of the plugin being removed.</param>  
        private void OnRemovePlugin(object sender, IPluginContext e)
        {
            Remove(e);
        }

        /// <summary>
        /// Raises the event when an application is added.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The context of the application being added.</param>
        private void OnAddApplication(object sender, IApplicationContext e)
        {
            Register(e);
        }

        /// <summary>
        /// Raises the event when an application is removed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The context of the application being removed.</param>
        private void OnRemoveApplication(object sender, IApplicationContext e)
        {
            Remove(e);
        }

        /// <summary>
        /// Returns all fragment contexts that belong to a given section.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <returns>An enumeration of the filtered fragment contexts.</returns>
        public IEnumerable<IFragmentContext> GetFragmentContexts(string section)
        {
            return GetFragmentItems(section)
                .SelectMany(x => x.FragmentContexts);
        }

        /// <summary>
        /// Returns all fragment contexts that belong to a given application.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="applicationContext">The allpication context.</param>
        /// <returns>An enumeration of the filtered fragment contexts.</returns>
        public IEnumerable<IFragmentContext> GetFragmentContexts(string section, IApplicationContext applicationContext)
        {
            return GetFragmentItems(section)
                .SelectMany(x => x.FragmentContexts)
                .Where(x => x.ApplicationContext == applicationContext);
        }

        /// <summary>
        /// Returns all fragment contexts that belong to a given application.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <returns>An enumeration of the filtered fragment contexts.</returns>
        private IEnumerable<FragmentItem> GetFragmentItems(string section)
        {
            return _dictionary.Values
                .Where(x => x.ContainsKey(section?.ToLower()))
                .SelectMany(x => x[section?.ToLower()])
                .Select(x => x);
        }

        /// <summary>
        /// Determines all fragments that match the parameters.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="page">The page that holds the fragments.</param>
        /// <returns>A list of fragments.</returns>
        public IEnumerable<FragmentCacheItem> GetCacheableFragments<T>
        (
            string section,
            IPage page
        ) where T : IControl
        {
            return GetCacheableFragments<T>(section, page, page?.ResourceContext?.Scopes);
        }

        /// <summary>
        /// Determines all fragments that match the parameters.
        /// </summary>
        /// <param name="section">The section where the fragment is embedded.</param>
        /// <param name="page">The page that holds the fragments.</param>
        /// <param name="scopes">The scopes where the fragments exists.</param>
        /// <returns>A list of fragments.</returns>
        public IEnumerable<FragmentCacheItem> GetCacheableFragments<T>
        (
            string section,
            IPage page,
            IEnumerable<string> scopes
        ) where T : IControl
        {
            var applicationContext = page?.ResourceContext?.ModuleContext?.ApplicationContext;
            scopes ??= Enumerable.Empty<string>();

            var fragmentItems = GetFragmentItems($"{section}:")
                .Union(scopes.SelectMany(x => GetFragmentItems
                (
                    string.Join(":", section?.ToLower(), x?.ToLower())
                )));

            var fragmentCacheItems = fragmentItems.Where
               (
                   x => x.FragmentClass.GetInterfaces().Contains(typeof(T)) ||
                   x.FragmentClass.GetInterfaces().Contains(typeof(IFragmentDynamic))
               )
               .Select(x => new
               {
                   x.FragmentClass,
                   FragmentContext = x.FragmentContexts
                       .Where(y => y.ModuleContext?.ApplicationContext == applicationContext)
                       .FirstOrDefault()
               })
               .Where(x => x.FragmentContext != null)
               .Select(x => new FragmentCacheItem(x.FragmentContext, x.FragmentClass));

            return fragmentCacheItems;
        }

        /// <summary>
        /// Returns the fragment items.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin.</param>
        /// <returns>A list with the fragment items.</returns>
        private IEnumerable<FragmentItem> GetFragmentItems(IPluginContext pluginContext)
        {
            if (!_dictionary.ContainsKey(pluginContext))
            {
                return [];
            }

            return _dictionary[pluginContext].Values
                .SelectMany(x => x);
        }

        /// <summary>
        /// Information about the component is collected and prepared for output in the log.
        /// </summary>
        private void Log()
        {
            //output.Add
            //(
            //    string.Empty.PadRight(deep) +
            //    I18N.Translate("webexpress.webui:fragmentmanager.titel")
            //);

            //foreach (var fragmentItem in GetFragmentItems(pluginContext))
            //{
            //    output.Add
            //    (
            //        string.Empty.PadRight(deep + 2) +
            //        I18N.Translate
            //        (
            //            "webexpress.webui:fragmentmanager.fragment",
            //            fragmentItem.FragmentClass.Name
            //        )
            //    );
            //}
        }

        /// <summary>
        /// Release of unmanaged resources reserved during use.
        /// </summary>
        public void Dispose()
        {
            _componentHub.PluginManager.AddPlugin -= OnAddPlugin;
            _componentHub.PluginManager.RemovePlugin -= OnRemovePlugin;
            _componentHub.ApplicationManager.AddApplication -= OnAddApplication;
            _componentHub.ApplicationManager.RemoveApplication -= OnRemoveApplication;

            GC.SuppressFinalize(this);
        }
    }
}
