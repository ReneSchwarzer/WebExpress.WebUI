using System;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingContextAttribute : Attribute, IResourceAttribute
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="context">The context in which the settings page is associated.</param>
        public SettingContextAttribute(string context)
        {

        }
    }
}
