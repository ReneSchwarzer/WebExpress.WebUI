namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Layoutmöglichkeiten des Tabulator-Steuerelementes
    /// </summary>
    public enum TypeLayoutTab
    {
        Default,
        Menu,
        Tab,
        Pill
    }

    public static class TypeLayoutTabExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeLayoutTab layout)
        {
            return layout switch
            {
                TypeLayoutTab.Tab => "nav-tabs",
                TypeLayoutTab.Pill => "nav-pills",
                _ => string.Empty,
            };
        }
    }
}
