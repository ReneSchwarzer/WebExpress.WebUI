namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration of supported device types
    /// </summary>
    public enum TypeDevice
    {
        /// <summary>
        /// No selection
        /// </summary>
        None,
        /// <summary>
        /// Automatic adjustment
        /// </summary>
        Auto,
        /// <summary>
        /// Suitable for phones < 576px
        /// </summary>
        ExtraSmall,
        /// <summary>
        /// Suitable for tablets >= 576px
        /// </summary>
        Small,
        /// <summary>
        /// Suitable for small laptops >= 768px
        /// </summary>
        Medium,
        /// <summary>
        /// Suitable for laptops & desktops >= 992px
        /// </summary>
        Large,
        /// <summary>
        /// Suitable for laptops & desktops >= 1200px
        /// </summary>
        ExtraLarge
    }
}
