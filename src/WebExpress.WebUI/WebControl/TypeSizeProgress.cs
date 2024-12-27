namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The size options for progress elements.
    /// </summary>
    public enum TypeSizeProgress
    {
        /// <summary>
        /// Default size.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Extra small size.
        /// </summary>
        ExtraSmall = 1,

        /// <summary>
        /// Small size.
        /// </summary>
        Small = 2,

        /// <summary>
        /// Large size.
        /// </summary>
        Large = 3,

        /// <summary>
        /// Extra large size.
        /// </summary>
        ExtraLarge = 4
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeSizeProgress"/> enum.
    /// </summary>
    public static class TypesSizeProgressExtensions
    {
        /// <summary>
        /// Converts the size to a CSS class.
        /// </summary>
        /// <param name="size">The size to be converted.</param>
        /// <returns>The CSS class corresponding to the size.</returns>
        public static string ToClass(this TypeSizeProgress size)
        {
            return string.Empty;
        }

        /// <summary>
        /// Converts the size to a CSS style.
        /// </summary>
        /// <param name="size">The size to be converted.</param>
        /// <returns>The CSS style corresponding to the size.</returns>
        public static string ToStyle(this TypeSizeProgress size)
        {
            return size switch
            {
                TypeSizeProgress.ExtraLarge => "height:40px;",
                TypeSizeProgress.Large => "height:27px;",
                TypeSizeProgress.Small => "height:10px;",
                TypeSizeProgress.ExtraSmall => "height:2px;",
                _ => string.Empty,
            };
        }
    }
}
