namespace WebExpress.WebUI.WebControl
{
    public enum TypePillBadge
    {
        None,
        Pill
    }

    public static class TypePillBadgeExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypePillBadge layout)
        {
            return layout switch
            {
                TypePillBadge.Pill => "badge-pill",
                _ => string.Empty,
            };
        }
    }
}
