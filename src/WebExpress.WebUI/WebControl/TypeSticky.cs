namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of sticky positioning for a web control.
    /// </summary>
    public enum TypeSticky
    {
        /// <summary>
        /// No sticky positioning.
        /// </summary>
        None,

        /// <summary>
        /// Sticky positioning at the top.
        /// </summary>
        Top
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeSticky"/> enumeration.
    /// </summary>
    public static class TypeStickyExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeSticky"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The <see cref="TypeSticky"/> value to be converted.</param>
        /// <returns>The CSS class corresponding to the <see cref="TypeSticky"/> value.</returns>
        public static string ToClass(this TypeSticky layout)
        {
            return layout switch
            {
                TypeSticky.Top => "sticky-top",
                _ => string.Empty,
            };
        }
    }
}
