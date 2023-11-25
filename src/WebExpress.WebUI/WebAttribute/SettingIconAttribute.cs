using WebExpress.WebUI.WebControl;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    public class SettingIconAttribute : System.Attribute, IResourceAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="icon">The icon.</param>
        public SettingIconAttribute(TypeIcon icon)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="icon">The icon.</param>
        public SettingIconAttribute(string icon)
        {

        }
    }
}
