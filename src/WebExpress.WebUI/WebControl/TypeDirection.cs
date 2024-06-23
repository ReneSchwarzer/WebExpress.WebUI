namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Anordnungsmöglichkeiten
    /// </summary>
    public enum TypeDirection
    {
        Default,
        Vertical,
        Horizontal,
        VerticalReverse,
        HorizontalReverse
    }

    public static class TypesFlexboxDirectionExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="direction">Die Anordnung, welches umgewandelt werden soll</param>
        /// <returns>Die zur Anordnung gehörende CSS-KLasse</returns>
        public static string ToClass(this TypeDirection direction)
        {
            return direction switch
            {
                TypeDirection.Vertical => "flex-column",
                TypeDirection.VerticalReverse => "flex-column-reverse",
                TypeDirection.Horizontal => "flex-row",
                TypeDirection.HorizontalReverse => "flex-row-reverse",
                _ => string.Empty,
            };
        }
    }
}
