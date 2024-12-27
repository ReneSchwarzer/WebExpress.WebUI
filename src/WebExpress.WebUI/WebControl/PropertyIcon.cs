namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents an icon property that can be either a system-defined icon or a user-defined icon.
    /// </summary>
    public class PropertyIcon : IProperty
    {
        /// <summary>
        /// Returns the system icon.
        /// </summary>
        public TypeIcon SystemIcon { get; protected set; }

        /// <summary>
        /// Returns te user-defined icon.
        /// </summary>
        public string UserIcon { get; protected set; }

        /// <summary>
        /// Returns the size of the icon (only for user-defined icons).
        /// </summary>
        public PropertySizeIcon Size { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the class with a system icon.
        /// </summary>
        /// <param name="icon">The system icon.</param>
        public PropertyIcon(TypeIcon icon)
        {
            SystemIcon = icon;
        }

        /// <summary>
        /// Initializes a new instance of the class with a user-defined icon.
        /// </summary>
        /// <param name="icon">The user-defined icon.</param>
        /// <param name="size">The size of the icon.</param>
        public PropertyIcon(string icon, PropertySizeIcon size = null)
        {
            SystemIcon = TypeIcon.None;
            UserIcon = icon;
            Size = size;
        }

        /// <summary>
        /// Converts the icon to a CSS class.
        /// </summary>
        /// <returns>The CSS class corresponding to the icon.</returns>
        public virtual string ToClass()
        {
            if (SystemIcon != TypeIcon.None)
            {
                return SystemIcon.ToClass();
            }

            return null;
        }

        /// <summary>
        /// Converts the icon to a CSS style.
        /// </summary>
        /// <returns>The CSS style corresponding to the icon.</returns>
        public virtual string ToStyle()
        {
            if (SystemIcon == TypeIcon.None)
            {
                return Size?.ToStyle();
            }

            return null;
        }

        /// <summary>
        /// Checks if an icon is set.
        /// </summary>
        /// <returns>True if an icon is set, false otherwise.</returns>
        public virtual bool HasIcon => SystemIcon != TypeIcon.None || UserIcon != null;

        /// <summary>
        /// Checks if a user-defined icon is set.
        /// </summary>
        /// <returns>True if a user-defined icon is set, false otherwise.</returns>
        public virtual bool IsUserIcon => UserIcon != null;
    }
}
