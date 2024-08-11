using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

[assembly: SystemPlugin()]

namespace WebExpress.WebUI
{
    [Name("webexpress.webui")]
    [Description("plugin.description")]
    [Icon("/assets/img/Logo.png")]
    public sealed class Plugin : WebCore.WebPlugin.Plugin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Plugin()
        {
        }

        /// <summary>
        /// Initialization of the plugin. Here, for example, managed resources can be loaded. 
        /// </summary>
        /// <param name="context">The context of the plugin that applies to the execution of the plugin.</param>
        public override void Initialization(IPluginContext context)
        {
            base.Initialization(context);
        }

        /// <summary>
        /// Called when the plugin starts working. Run is called concurrently.
        /// </summary>
        public override void Run()
        {
            base.Run();
        }

        /// <summary>
        /// Release of unmanaged resources reserved during use.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
