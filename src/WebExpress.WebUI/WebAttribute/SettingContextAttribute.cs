using System;
using WebExpress.Core.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingContextAttribute : Attribute, IResourceAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context in which the settings page is associated.</param>
        public SettingContextAttribute(string context)
        {

        }
    }
}
