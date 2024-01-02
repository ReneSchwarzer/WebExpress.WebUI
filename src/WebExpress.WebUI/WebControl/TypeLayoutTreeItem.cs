namespace WebExpress.WebUI.WebControl
{
    public enum TypeLayoutTreeItem
    {
        Default,
        Flat,
        Simple,
        Group,
        Flush,
        Horizontal,
        TreeView
    }

    public static class TypeLayoutTreeItemExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
