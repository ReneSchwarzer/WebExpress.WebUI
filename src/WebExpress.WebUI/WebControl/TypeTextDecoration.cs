namespace WebExpress.WebUI.WebControl
{
    public enum TypeTextDecoration
    {
        Default,
        None
    }

    public static class TypeTextDecorationExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeTextDecoration layout)
        {
            return layout switch
            {
                TypeTextDecoration.None => "text-decoration-none",
                _ => string.Empty,
            };
        }
    }
}
