namespace WebExpress.WebUI.WebControl
{
    public enum TypeOrientationTab
    {
        Default,
        Horizontal,
        Vertical
    }

    public static class TypeOrientationTabExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeOrientationTab layout)
        {
            return layout switch
            {
                TypeOrientationTab.Vertical => "flex-column",
                _ => string.Empty,
            };
        }
    }
}
