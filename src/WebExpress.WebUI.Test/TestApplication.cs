﻿using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.Test
{
    /// <summary>
    /// A dummy application for testing purposes.
    /// </summary>
    [Name("webexpress.webui.unittest")]
    [Description("plugin.description")]
    [Icon("/assets/img/Logo.png")]
    [Dependency("webexpress.webui")]
    public sealed class TestApplication : IApplication
    {
        /// <summary>
        /// Initialization of the application.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public void Initialization(IApplicationContext applicationContext)
        {
        }

        /// <summary>
        /// Called when the plugin starts working. The call is concurrent.
        /// </summary>
        public void Run()
        {
        }

        /// <summary>
        /// Release of unmanaged resources reserved during use.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
