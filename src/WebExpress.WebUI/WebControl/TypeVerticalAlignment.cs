namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Ausrichtung von Inline-Elementen
    /// </summary>
    public enum TypeVerticalAlignment
    {
        Default = 0,
        Baseline = 1,
        Top = 2,
        Middle = 3,
        Bottom = 4,
        TextTop = 5,
        TextBottom = 6
    }

    public static class TypeVerticalAlignmentExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="color">Die Hintergrundfarbe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeVerticalAlignment color)
        {
            return color switch
            {
                TypeVerticalAlignment.Baseline => "align-baseline",
                TypeVerticalAlignment.Top => "align-top",
                TypeVerticalAlignment.Middle => "align-middle",
                TypeVerticalAlignment.Bottom => "align-bottom",
                TypeVerticalAlignment.TextTop => "align-text-top",
                TypeVerticalAlignment.TextBottom => "align-text-bottom",
                _ => string.Empty,
            };
        }
    }
}
