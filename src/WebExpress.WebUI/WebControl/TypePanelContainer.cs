namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The layout options of the panel control.
    /// </summary>
    public enum TypePanelContainer
    {
        None,
        Default,
        Fluid
    }

    public static class TypePanelFluidExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
