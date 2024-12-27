namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The layout options for the grid system.
    /// </summary>
    public enum TypePanelGridRow
    {
        /// <summary>
        /// No specific layout.
        /// </summary>
        None,

        /// <summary>
        /// Automatic layout.
        /// </summary>
        Auto,

        /// <summary>
        /// Fluid layout.
        /// </summary>
        Fluid
    }

    /// <summary>
    /// Extension methods for the <see cref="TypePanelGridRow"/> enum.
    /// </summary>
    public static class TypePanelGridRowExtensions
    {
        /// <summary>
        /// Converts the layout to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
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
