namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the vertical alignment of inline elements.
    /// </summary>
    public enum TypeVerticalAlignment
    {
        /// <summary>
        /// Default alignment.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Aligns with the baseline of the parent element.
        /// </summary>
        Baseline = 1,

        /// <summary>
        /// Aligns with the top of the parent element.
        /// </summary>
        Top = 2,

        /// <summary>
        /// Aligns with the middle of the parent element.
        /// </summary>
        Middle = 3,

        /// <summary>
        /// Aligns with the bottom of the parent element.
        /// </summary>
        Bottom = 4,

        /// <summary>
        /// Aligns with the top of the text.
        /// </summary>
        TextTop = 5,

        /// <summary>
        /// Aligns with the bottom of the text.
        /// </summary>
        TextBottom = 6
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeVerticalAlignment"/> enum.
    /// </summary>
    public static class TypeVerticalAlignmentExtensions
    {
        /// <summary>
        /// Converts the vertical alignment type to a corresponding CSS class.
        /// </summary>
        /// <param name="alignment">The vertical alignment type to convert.</param>
        /// <returns>The CSS class corresponding to the vertical alignment type.</returns>
        public static string ToClass(this TypeVerticalAlignment alignment)
        {
            return alignment switch
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
