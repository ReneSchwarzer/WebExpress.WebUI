namespace WebExpress.WebUI.WebControl
{
    public enum TypeSticky
    {
        None,
        Top
    }

    public static class TypeStickyExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeSticky layout)
        {
            return layout switch
            {
                TypeSticky.Top => "sticky-top",
                _ => string.Empty,
            };
        }
    }
}
