namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of justification for a flexbox layout.
    /// </summary>
    public enum TypeJustifiedFlexbox
    {
        /// <summary>
        /// No justification.
        /// </summary>
        None,

        /// <summary>
        /// Items are justified at the start of the container.
        /// </summary>
        Start,

        /// <summary>
        /// Items are justified at the end of the container.
        /// </summary>
        End,

        /// <summary>
        /// Items are justified at the center of the container.
        /// </summary>
        Center,

        /// <summary>
        /// Items are justified with space between them.
        /// </summary>
        Between,

        /// <summary>
        /// Items are justified with space around them.
        /// </summary>
        Around
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeJustifiedFlexbox"/> enum.
    /// </summary>
    public static class TypeTypeJustifiedFlexboxExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeJustifiedFlexbox"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeJustifiedFlexbox layout)
        {
            return layout switch
            {
                TypeJustifiedFlexbox.Start => "justify-content-start",
                TypeJustifiedFlexbox.End => "justify-content-end",
                TypeJustifiedFlexbox.Center => "justify-content-center",
                TypeJustifiedFlexbox.Between => "justify-content-between",
                TypeJustifiedFlexbox.Around => "justify-content-around",
                _ => string.Empty,
            };
        }
    }

}
