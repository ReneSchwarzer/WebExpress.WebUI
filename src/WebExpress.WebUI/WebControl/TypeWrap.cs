namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of wrapping for a web control.
    /// </summary>
    public enum TypeWrap
    {
        /// <summary>
        /// No wrapping.
        /// </summary>
        None,

        /// <summary>
        /// No wrapping, content stays on a single line.
        /// </summary>
        Nowrap,

        /// <summary>
        /// Content wraps onto multiple lines.
        /// </summary>
        Wrap,

        /// <summary>
        /// Content wraps in reverse order.
        /// </summary>
        Reverse
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeWrap"/> enumeration.
    /// </summary>
    public static class TypeWrapExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeWrap"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The <see cref="TypeWrap"/> value to be converted.</param>
        /// <returns>The CSS class corresponding to the <see cref="TypeWrap"/> value.</returns>
        public static string ToClass(this TypeWrap layout)
        {
            return layout switch
            {
                TypeWrap.Nowrap => "flex-nowrap",
                TypeWrap.Wrap => "flex-wrap",
                TypeWrap.Reverse => "flex-wrap-reverse",
                _ => string.Empty,
            };
        }
    }

}
