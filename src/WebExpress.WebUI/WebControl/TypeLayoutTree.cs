namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the different types of layout trees.
    /// </summary>
    public enum TypeLayoutTree
    {
        Default,
        Flat,
        Simple,
        Group,
        Flush,
        Horizontal,
        TreeView
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeLayoutTree"/> enum.
    /// </summary>
    public static class TypeLayoutTreeExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeLayoutTree layout)
        {
            return layout switch
            {
                TypeLayoutTree.TreeView => "tree-treeview",
                TypeLayoutTree.Group => "list-group",
                TypeLayoutTree.Simple => "tree-simple",
                TypeLayoutTree.Flat => "list-unstyled",
                TypeLayoutTree.Flush => "list-group list-group-flush",
                TypeLayoutTree.Horizontal => "list-group list-group-horizontal",
                _ => string.Empty,
            };
        }
    }
}
