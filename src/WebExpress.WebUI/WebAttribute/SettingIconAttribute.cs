using WebExpress.WebUI.WebControl;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    public class SettingIconAttribute : System.Attribute, IResourceAttribute
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
