namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The possible arrangements.
    /// </summary>
    public enum TypeDirection
    {
        /// <summary>
        /// The default arrangement.
        /// </summary>
        Default,

        /// <summary>
        /// The vertical arrangement.
        /// </summary>
        Vertical,

        /// <summary>
        /// The horizontal arrangement.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The reverse vertical arrangement.
        /// </summary>
        VerticalReverse,

        /// <summary>
        /// The reverse horizontal arrangement.
        /// </summary>
        HorizontalReverse
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeDirection"/> enum.
    /// </summary>
    public static class TypesFlexboxDirectionExtensions
    {
        /// <summary>
        /// Converts the direction to a CSS class.
        /// </summary>
        /// <param name="direction">The direction to be converted.</param>
        /// <returns>The CSS class corresponding to the direction.</returns>
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
