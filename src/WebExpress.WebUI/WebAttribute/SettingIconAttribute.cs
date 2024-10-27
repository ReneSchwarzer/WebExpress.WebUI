using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.WebAttribute
{
    /// <summary>
    /// Attribute to set an icon for a setting.
    /// </summary>
    public class SettingIconAttribute : System.Attribute, IEndpointAttribute
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="icon">The icon.</param>
        public SettingIconAttribute(TypeIcon icon)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="icon">The icon.</param>
        public SettingIconAttribute(string icon)
        {

        }
    }
}
