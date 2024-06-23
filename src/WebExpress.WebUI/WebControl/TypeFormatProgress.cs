namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die ProgressBar Formate
    /// </summary>
    public enum TypeFormatProgress
    {
        Default,
        Colored,
        Striped,
        Animated
    }

    public static class TypesProgressBarFormatExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
