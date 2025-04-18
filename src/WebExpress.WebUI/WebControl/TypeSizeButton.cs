namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The size options for buttons.
    /// </summary>
    public enum TypeSizeButton
    {
        /// <summary>
        /// The default size.
        /// </summary>
        Default,

        /// <summary>
        /// The small size.
        /// </summary>
        Small,

        /// <summary>
        /// The large size.
        /// </summary>
        Large
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeSizeButton"/> enum.
    /// </summary>
    public static class TypeSizeButtonExtensions
    {
        /// <summary>
        /// Converts the button size to a CSS class.
        /// </summary>
        /// <param name="size">The size to be converted.</param>
        /// <returns>The CSS class corresponding to the size.</returns>
        public static string ToClass(this TypeSizeButton size)
        {
            return size switch
            {
                TypeSizeButton.Large => "btn-lg",
                TypeSizeButton.Small => "btn-sm",
                _ => string.Empty,
            };
        }
    }
}
