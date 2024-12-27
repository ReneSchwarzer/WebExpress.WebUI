namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The formats for the progress bar.
    /// </summary>
    public enum TypeFormatProgress
    {
        /// <summary>
        /// The default format.
        /// </summary>
        Default,

        /// <summary>
        /// The colored format.
        /// </summary>
        Colored,

        /// <summary>
        /// The striped format.
        /// </summary>
        Striped,

        /// <summary>
        /// The animated format.
        /// </summary>
        Animated
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeFormatProgress"/> enum.
    /// </summary>
    public static class TypesProgressBarFormatExtensions
    {
        /// <summary>
        /// Converts the layout to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeFormatProgress layout)
        {
            return layout switch
            {
                TypeFormatProgress.Colored => "progress-bar",
                TypeFormatProgress.Striped => "progress-bar progress-bar-striped",
                TypeFormatProgress.Animated => "progress-bar progress-bar-striped progress-bar-animated",
                _ => string.Empty,
            };
        }
    }
}
