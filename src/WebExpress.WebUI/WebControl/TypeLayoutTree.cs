namespace WebExpress.WebUI.WebControl
{
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
