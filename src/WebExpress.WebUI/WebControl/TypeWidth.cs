namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the width types for a web control.
    /// </summary>
    public enum TypeWidth
    {
        /// <summary>
        /// Default width.
        /// </summary>
        Default,

        /// <summary>
        /// Twenty-five percent width.
        /// </summary>
        TwentyFive,

        /// <summary>
        /// Fifty percent width.
        /// </summary>
        Fifty,

        /// <summary>
        /// Seventy-five percent width.
        /// </summary>
        SeventyFive,

        /// <summary>
        /// One hundred percent width.
        /// </summary>
        OneHundred
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeWidth"/> enum.
    /// </summary>
    public static class TypesWidthExtensions
    {
        /// <summary>
        /// Converts the width to a CSS class.
        /// </summary>
        /// <param name="width">The width to be converted.</param>
        /// <returns>The corresponding CSS class for the width.</returns>
        public static string ToClass(this TypeWidth width)
        {
            return width switch
            {
                TypeWidth.TwentyFive => "w-25",
                TypeWidth.Fifty => "w-50",
                TypeWidth.SeventyFive => "w-75",
                TypeWidth.OneHundred => "w-100",
                _ => string.Empty,
            };
        }
    }
}
