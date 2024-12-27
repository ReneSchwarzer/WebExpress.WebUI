namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the fixed position types for a web control.
    /// </summary>
    public enum TypeFixed
    {
        /// <summary>
        /// No fixed position.
        /// </summary>
        None,

        /// <summary>
        /// Fixed position at the top.
        /// </summary>
        Top,

        /// <summary>
        /// Fixed position at the bottom.
        /// </summary>
        Bottom
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeFixed"/> enum.
    /// </summary>
    public static class TypeFixedExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeFixed"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The <see cref="TypeFixed"/> value to be converted.</param>
        /// <returns>A string representing the CSS class corresponding to the <see cref="TypeFixed"/> value.</returns>
        public static string ToClass(this TypeFixed layout)
        {
            return layout switch
            {
                TypeFixed.Top => "fixed-top",
                TypeFixed.Bottom => "fixed-bottom",
                _ => string.Empty,
            };
        }
    }
}
