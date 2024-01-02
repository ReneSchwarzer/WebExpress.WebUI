namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Layoutmöglichkeiten des Grid-Systems
    /// </summary>
    public enum TypePanelGridRow
    {
        None,
        Auto,
        Fluid
    }

    public static class TypePanelGridRowExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypePanelGridRow layout)
        {
            return layout switch
            {
                TypePanelGridRow.Auto => "container",
                TypePanelGridRow.Fluid => "container-fluid",
                _ => string.Empty,
            };
        }
    }
}
