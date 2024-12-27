namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of justified tab.
    /// </summary>
    public enum TypeJustifiedTab
    {
        /// <summary>
        /// The default tab type.
        /// </summary>
        Default,

        /// <summary>
        /// The justified tab type.
        /// </summary>
        Justified
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeJustifiedTab"/> enumeration.
    /// </summary>
    public static class TypeJustifiedTabExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeJustifiedTab"/> to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeJustifiedTab layout)
        {
            return layout switch
            {
                TypeJustifiedTab.Justified => "nav-justified",
                _ => string.Empty,
            };
        }
    }
}
