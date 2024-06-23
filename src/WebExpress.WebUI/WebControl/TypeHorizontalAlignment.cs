namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die horizontale Anordnung
    /// </summary>
    public enum TypeHorizontalAlignment
    {
        Default,
        Left,
        Right
    }

    public static class TypesHorizontalAlignmentExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="alignment">Die Ausrichtung, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeHorizontalAlignment alignment)
        {
            return alignment switch
            {
                TypeHorizontalAlignment.Left => "float-left",
                TypeHorizontalAlignment.Right => "float-right",
                _ => string.Empty,
            };
        }
    }
}
