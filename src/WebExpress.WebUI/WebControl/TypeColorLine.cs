namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The standard background colors.
    /// </summary>
    public enum TypeColorLine
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
        Light = 8
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeColorLine"/> enum.
    /// </summary>
    public static class TypeColorLineExtensions
    {
        /// <summary>
        /// Converts the background color to a CSS class.
        /// </summary>
        /// <param name="color">The background color to be converted.</param>
        /// <returns>The CSS class corresponding to the background color.</returns>
        public static string ToClass(this TypeColorLine color)
        {
            return color switch
            {
                TypeColorLine.Primary => "bg-primary",
                TypeColorLine.Secondary => "bg-secondary",
                TypeColorLine.Success => "bg-success",
                TypeColorLine.Info => "bg-info",
                TypeColorLine.Warning => "bg-warning",
                TypeColorLine.Danger => "bg-danger",
                TypeColorLine.Light => "bg-light",
                TypeColorLine.Dark => "bg-dark",
                _ => string.Empty,
            };
        }
    }
}
