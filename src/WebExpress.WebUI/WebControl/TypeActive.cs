namespace WebExpress.WebUI.WebControl
{
    public enum TypeActive
    {
        None,
        Active,
        Disabled
    }

    public static class TypesActiveExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeActive layout)
        {
            return layout switch
            {
                TypeActive.Active => "active",
                TypeActive.Disabled => "disabled",
                _ => string.Empty,
            };
        }
    }
}
