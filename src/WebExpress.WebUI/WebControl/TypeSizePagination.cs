namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// The size options for pagination.
    /// </summary>
    public enum TypeSizePagination
    {
        /// <summary>
        /// The default size.
        /// </summary>
        Default,

        /// <summary>
        /// The small size.
        /// </summary>
        Small,

        /// <summary>
        /// The large size.
        /// </summary>
        Large
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeSizePagination"/> enum.
    /// </summary>
    public static class TypeSizePaginationExtensions
    {
        /// <summary>
        /// Converts the size to a corresponding CSS class.
        /// </summary>
        /// <param name="size">The size to be converted.</param>
        /// <returns>The CSS class corresponding to the size.</returns>
        public static string ToClass(this TypeSizePagination size)
        {
            return size switch
            {
                TypeSizePagination.Large => "pagination-lg",
                TypeSizePagination.Small => "pagination-sm",
                _ => string.Empty,
            };
        }
    }
}
