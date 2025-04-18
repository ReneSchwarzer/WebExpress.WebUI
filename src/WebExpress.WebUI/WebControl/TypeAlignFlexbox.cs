namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the alignment of flexbox items.
    /// </summary>
    public enum TypeAlignFlexbox
    {
        /// <summary>
        /// No alignment.
        /// </summary>
        None,

        /// <summary>
        /// Items are packed toward the start of the flex container.
        /// </summary>
        Start,

        /// <summary>
        /// Items are packed toward the end of the flex container.
        /// </summary>
        End,

        /// <summary>
        /// Items are centered in the flex container.
        /// </summary>
        Center,

        /// <summary>
        /// Items are aligned such that their baselines align.
        /// </summary>
        Baseline,

        /// <summary>
        /// Items are stretched to fill the flex container.
        /// </summary>
        Stretch
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeAlignFlexbox"/> enum.
    /// </summary>
    public static class TypeAlignFlexboxExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeAlignFlexbox"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeAlignFlexbox layout)
        {
            return layout switch
            {
                TypeAlignFlexbox.Start => "align-items-start",
                TypeAlignFlexbox.End => "align-items-end",
                TypeAlignFlexbox.Center => "align-items-center",
                TypeAlignFlexbox.Baseline => "align-items-baseline",
                TypeAlignFlexbox.Stretch => "align-items-stretch",
                _ => string.Empty,
            };
        }
    }

}
