namespace WebExpress.WebUI.WebControl
{
    public enum TypeLayoutList
    {
        Default,
        Simple,
        Group,
        Flush,
        Horizontal
    }

    public static class TypeLayoutListExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
