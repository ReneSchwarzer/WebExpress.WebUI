﻿namespace WebExpress.WebUI.WebControl
{
    public class PropertyIcon : IProperty
    {
        /// <summary>
        /// Das System-Icon
        /// </summary>
        public TypeIcon SystemIcon { get; protected set; }

        /// <summary>
        /// Das benutzerdefinierte Icon
        /// </summary>
        public string UserIcon { get; protected set; }

        /// <summary>
        /// Die Größe des Icons (nur bei Benutzerdefinierten Icons)
        /// </summary>
        public PropertySizeIcon Size { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="icon">Das System-Icon</param>
        public PropertyIcon(TypeIcon icon)
        {
            SystemIcon = icon;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="icon">Das benutzerdefinierte Icon</param>
        public PropertyIcon(string icon, PropertySizeIcon size = null)
        {
            SystemIcon = TypeIcon.None;
            UserIcon = icon;
            Size = size;
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>Die zum Icon gehörende CSS-KLasse</returns>
        public virtual string ToClass()
        {
            if (SystemIcon != TypeIcon.None)
            {
                return SystemIcon.ToClass();
            }

            return null;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <returns>Das zum Icon gehörende CSS-Style</returns>
        public virtual string ToStyle()
        {
            if (SystemIcon == TypeIcon.None)
            {
                return Size?.ToStyle();
            }

            return null;
        }

        /// <summary>
        /// Prüft ob ein Icon gesetzt ist
        /// </summary>
        /// <returns>True wenn ein Icon gesetzt ist, false sonst</returns>
        public virtual bool HasIcon => SystemIcon != TypeIcon.None || UserIcon != null;

        /// <summary>
        /// Prüft ob ein benutzerdefiniertes Icon gesetzt ist
        /// </summary>
        /// <returns>True wenn ein benutzerdefiniertes Icon gesetzt ist, false sonst</returns>
        public virtual bool IsUserIcon => UserIcon != null;
    }
}
