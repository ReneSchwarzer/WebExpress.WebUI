namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The layout options of the panel control.
    /// </summary>
    public enum TypePanelContainer
    {
        /// <summary>
        /// No specific layout.
        /// </summary>
        None,

        /// <summary>
        /// Default layout with fixed width.
        /// </summary>
        Default,

        /// <summary>
        /// Fluid layout with full width.
        /// </summary>
        Fluid
    }

    /// <summary>
    /// Extension methods for the <see cref="TypePanelContainer"/> enum.
    /// </summary>
    public static class TypePanelFluidExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypePanelContainer"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypePanelContainer layout)
        {
            return layout switch
            {
                TypePanelContainer.Default => "container",
                TypePanelContainer.Fluid => "container-fluid",
                _ => string.Empty,
            };
        }
    }
}
