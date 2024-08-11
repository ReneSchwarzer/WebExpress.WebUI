using System;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingGroupAttribute : System.Attribute, IResourceAttribute
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="name">The group name.</param>
        public SettingGroupAttribute(string name)
        {

        }
    }
}
