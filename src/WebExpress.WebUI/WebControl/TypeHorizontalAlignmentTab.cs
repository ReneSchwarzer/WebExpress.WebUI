namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die horizontale Anordnung
    /// </summary>
    public enum TypeHorizontalAlignmentTab
    {
        Default,
        Left,
        Center,
        Right
    }

    public static class TypeHorizontalAlignmentTabExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="alignment">Die Ausrichtung, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeHorizontalAlignmentTab alignment)
        {
            return alignment switch
            {
                TypeHorizontalAlignmentTab.Center => "justify-content-center",
                TypeHorizontalAlignmentTab.Right => "justify-content-end",
                _ => string.Empty,
            };
        }
    }
}
