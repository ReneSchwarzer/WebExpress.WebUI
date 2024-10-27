using System;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    /// <summary>
    /// Attribute to define a setting group for identity.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingGroupAttribute : System.Attribute, IEndpointAttribute
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
