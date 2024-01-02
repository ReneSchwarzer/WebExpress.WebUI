namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Größenmöglichkeiten
    /// </summary>
    public enum TypeSizeButton
    {
        Default,
        Small,
        Large
    }

    public static class TypeSizeButtonExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeSizeButton size)
        {
            return size switch
            {
                TypeSizeButton.Large => "btn-lg",
                TypeSizeButton.Small => "btn-sm",
                _ => string.Empty,
            };
        }
    }
}
