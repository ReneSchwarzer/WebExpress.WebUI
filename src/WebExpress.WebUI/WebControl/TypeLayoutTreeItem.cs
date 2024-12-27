namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the different types of layout for a tree item.
    /// </summary>
    public enum TypeLayoutTreeItem
    {
        /// <summary>
        /// The default layout.
        /// </summary>
        Default,

        /// <summary>
        /// A flat, unstyled layout.
        /// </summary>
        Flat,

        /// <summary>
        /// A simple layout.
        /// </summary>
        Simple,

        /// <summary>
        /// A grouped layout.
        /// </summary>
        Group,

        /// <summary>
        /// A flush layout.
        /// </summary>
        Flush,

        /// <summary>
        /// A horizontal layout.
        /// </summary>
        Horizontal,

        /// <summary>
        /// A tree view layout.
        /// </summary>
        TreeView
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeLayoutTreeItem"/> enum.
    /// </summary>
    public static class TypeLayoutTreeItemExtensions
    {
        /// <summary>
        /// Converts the layout to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeLayoutTreeItem layout)
        {
            return layout switch
            {
                TypeLayoutTreeItem.TreeView => "list-treeview",
                TypeLayoutTreeItem.Group => "list-group",
                TypeLayoutTreeItem.Simple => "list-simple",
                TypeLayoutTreeItem.Flat => "list-unstyled",
                TypeLayoutTreeItem.Flush => "list-group list-group-flush",
                TypeLayoutTreeItem.Horizontal => "list-group list-group-horizontal",
                _ => string.Empty,
            };
        }
    }
}
