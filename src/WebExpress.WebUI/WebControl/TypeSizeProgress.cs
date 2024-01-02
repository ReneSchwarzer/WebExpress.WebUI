namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Größenmöglichkeiten
    /// </summary>
    public enum TypeSizeProgress
    {
        Default = 0,
        ExtraSmall = 1,
        Small = 2,
        Large = 3,
        ExtraLarge = 4
    }

    public static class TypesSizeProgressExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeSizeProgress size)
        {
            return string.Empty;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>Der zur Größe gehörende CSS-Style</returns>
        public static string ToStyle(this TypeSizeProgress size)
        {
            return size switch
            {
                TypeSizeProgress.ExtraLarge => "height:40px;",
                TypeSizeProgress.Large => "height:27px;",
                TypeSizeProgress.Small => "height:10px;",
                TypeSizeProgress.ExtraSmall => "height:2px;",
                _ => string.Empty,
            };
        }
    }
}
