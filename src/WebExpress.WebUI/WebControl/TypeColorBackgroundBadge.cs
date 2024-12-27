namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration for different types of background colors for badges.
    /// </summary>
    public enum TypeColorBackgroundBadge
    {
        /// <summary>
        /// Default background color.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Primary background color.
        /// </summary>
        Primary = 1,

        /// <summary>
        /// Secondary background color.
        /// </summary>
        Secondary = 2,

        /// <summary>
        /// Success background color.
        /// </summary>
        Success = 3,

        /// <summary>
        /// Info background color.
        /// </summary>
        Info = 4,

        /// <summary>
        /// Warning background color.
        /// </summary>
        Warning = 5,

        /// <summary>
        /// Danger background color.
        /// </summary>
        Danger = 6,

        /// <summary>
        /// Dark background color.
        /// </summary>
        Dark = 7,
        /// <summary>
        /// Light background color.
        /// </summary>
        Light = 8,

        /// <summary>
        /// White background color.
        /// </summary>
        White = 9,

        /// <summary>
        /// Transparent background color.
        /// </summary>
        Transparent = 10
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeColorBackgroundBadge"/> enumeration.
    /// </summary>
    public static class TypeColorBackgroundBadgeExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeColorBackgroundBadge layout)
        {
            return layout switch
            {
                TypeColorBackgroundBadge.Primary => "bg-primary",
                TypeColorBackgroundBadge.Secondary => "bg-secondary",
                TypeColorBackgroundBadge.Success => "bg-success",
                TypeColorBackgroundBadge.Info => "bg-info",
                TypeColorBackgroundBadge.Warning => "bg-warning",
                TypeColorBackgroundBadge.Danger => "bg-danger",
                TypeColorBackgroundBadge.Light => "bg-light",
                TypeColorBackgroundBadge.Dark => "bg-dark",
                TypeColorBackgroundBadge.White => "bg-white",
                TypeColorBackgroundBadge.Transparent => "bg-transparent",
                _ => string.Empty,
            };
        }
    }
}
