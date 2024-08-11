using System.Globalization;

namespace WebExpress.WebUI.WebControl
{
    public class PropertySizeText : IProperty
    {
        /// <summary>
        /// Die System-Größe
        /// </summary>
        public TypeSizeText SystemSize { get; protected set; }

        /// <summary>
        /// Die benutzerdefinierte Größe
        /// </summary>
        public float? UserSize { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="size">Die System-Größe</param>
        public PropertySizeText(TypeSizeText size)
        {
            SystemSize = size;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="icon">Das benutzerdefinierte Größe in REM</param>
        public PropertySizeText(float size)
        {
            SystemSize = TypeSizeText.Default;
            UserSize = size;
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>Die zur Farbe gehörende CSS-KLasse</returns>
        public virtual string ToClass()
        {
            if (SystemSize != TypeSizeText.Default)
            {
                return SystemSize.ToClass();
            }

            return null;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <returns>Das zur Farbe gehörende CSS-Style</returns>
        public virtual string ToStyle()
        {
            if (SystemSize != TypeSizeText.Default)
            {
                return SystemSize.ToStyle();
            }
            else if (IsUserSize)
            {
                return string.Format(CultureInfo.InvariantCulture, "font-size:{0:f}rem;", UserSize);
            }

            return null;
        }

        /// <summary>
        /// Prüft ob ein Icon gesetzt ist
        /// </summary>
        /// <returns>True wenn ein Icon gesetzt ist, false sonst</returns>
        public virtual bool HasSize => SystemSize != TypeSizeText.Default || UserSize.HasValue;

        /// <summary>
        /// Prüft ob ein benutzerdefiniertes Icon gesetzt ist
        /// </summary>
        /// <returns>True wenn ein benutzerdefiniertes Icon gesetzt ist, false sonst</returns>
        public virtual bool IsUserSize => SystemSize == TypeSizeText.Default && UserSize.HasValue;
    }
}
