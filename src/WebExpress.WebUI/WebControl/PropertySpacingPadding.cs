namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the padding properties for a web control.
    /// </summary>
    public class PropertySpacingPadding : PropertySpacing
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PropertySpacingPadding()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class with the same padding for all sides.
        /// </summary>
        /// <param name="size">The padding size for all sides.</param>
        public PropertySpacingPadding(Space size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class with different horizontal and vertical padding.
        /// </summary>
        /// <param name="horizontal">The horizontal padding.</param>
        /// <param name="vertical">The vertical padding.</param>
        public PropertySpacingPadding(Space horizontal, Space vertical)
            : base(horizontal, vertical)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class with specific padding for each side.
        /// </summary>
        /// <param name="left">The left padding.</param>
        /// <param name="right">The right padding.</param>
        /// <param name="top">The top padding.</param>
        /// <param name="bottom">The bottom padding.</param>
        public PropertySpacingPadding(Space left, Space right, Space top, Space bottom)
            : base(left, right, top, bottom)
        {
        }

        /// <summary>
        /// Converts the padding values to a CSS class.
        /// </summary>
        /// <returns>The CSS class representing the padding values.</returns>
        public override string ToClass()
        {
            return ToClass("p");
        }
    }
}
