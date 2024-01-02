namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Größenmöglichkeiten
    /// </summary>
    public enum TypeSizeText
    {
        Default = 0,
        ExtraSmall = 1,
        Small = 2,
        Large = 3,
        ExtraLarge = 4
    }

    public static class TypesSizeTextExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeSizeText size)
        {
            return string.Empty;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>Der zur Größe gehörende CSS-Style</returns>
        public static string ToStyle(this TypeSizeText size)
        {
            return size switch
            {
                TypeSizeText.ExtraLarge => "font-size:2rem;",
                TypeSizeText.Large => "font-size:1.5rem;",
                TypeSizeText.Small => "font-size:0.75rem;",
                TypeSizeText.ExtraSmall => "font-size:0.55rem;",
                _ => string.Empty,
            };
        }
    }
}
