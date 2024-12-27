namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the different types of layout lists.
    /// </summary>
    public enum TypeLayoutList
    {
        /// <summary>
        /// The default layout.
        /// </summary>
        Default,

        /// <summary>
        /// A simple, unstyled layout.
        /// </summary>
        Simple,

        /// <summary>
        /// A grouped layout.
        /// </summary>
        Group,

        /// <summary>
        /// A flush layout with no borders.
        /// </summary>
        Flush,

        /// <summary>
        /// A horizontal layout.
        /// </summary>
        Horizontal
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeLayoutList"/> enum.
    /// </summary>
    public static class TypeLayoutListExtensions
    {
        /// <summary>
        /// Converts the layout to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeLayoutList layout)
        {
            return layout switch
            {
                TypeLayoutList.Group => "list-group",
                TypeLayoutList.Simple => "list-unstyled",
                TypeLayoutList.Flush => "list-group list-group-flush",
                TypeLayoutList.Horizontal => "list-group list-group-horizontal",
                _ => string.Empty,
            };
        }
    }
}
