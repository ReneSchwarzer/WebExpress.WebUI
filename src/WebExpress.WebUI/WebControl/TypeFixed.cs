namespace WebExpress.WebUI.WebControl
{
    public enum TypeFixed
    {
        None,
        Top,
        Bottom
    }

    public static class TypeFixedExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeFixed layout)
        {
            return layout switch
            {
                TypeFixed.Top => "fixed-top",
                TypeFixed.Bottom => "fixed-bottom",
                _ => string.Empty,
            };
        }
    }
}
