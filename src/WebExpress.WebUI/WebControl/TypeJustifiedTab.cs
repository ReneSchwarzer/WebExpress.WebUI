namespace WebExpress.WebUI.WebControl
{
    public enum TypeJustifiedTab
    {
        Default,
        Justified
    }

    public static class TypeJustifiedTabExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
