namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the margin spacing properties for a web control.
    /// </summary>
    public class PropertySpacingMargin : PropertySpacing
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PropertySpacingMargin()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class with the same spacing for all sides.
        /// </summary>
        /// <param name="size">The spacing size for all sides.</param>
        public PropertySpacingMargin(Space size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class with different horizontal and vertical spacing.
        /// </summary>
        /// <param name="horizontal">The horizontal spacing.</param>
        /// <param name="vertical">The vertical spacing.</param>
        public PropertySpacingMargin(Space horizontal, Space vertical)
            : base(horizontal, vertical)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySpacingMargin"/> class with specific spacing for each side.
        /// </summary>
        /// <param name="left">The left spacing.</param>
        /// <param name="right">The right spacing.</param>
        /// <param name="top">The top spacing.</param>
        /// <param name="bottom">The bottom spacing.</param>
        public PropertySpacingMargin(Space left, Space right, Space top, Space bottom)
            : base(left, right, top, bottom)
        {
        }

        /// <summary>
        /// Converts the margin spacing values to a CSS class.
        /// </summary>
        /// <returns>The CSS class representing the margin spacing.</returns>
        public override string ToClass()
        {
            return ToClass("m");
        }
    }
}
