namespace WebExpress.WebUI.WebControl
{
    public class PropertySpacingMargin : PropertySpacing
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PropertySpacingMargin()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="size">Die Abstände</param>
        public PropertySpacingMargin(Space size)
            : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="horizontal">Der horzontale Abstand</param>
        /// <param name="vertical">Der vertikale Abstand</param>
        public PropertySpacingMargin(Space horizontal, Space vertical)
            : base(horizontal, vertical)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="left">Der linke Abstand</param>
        /// <param name="right">Der rechte Abstand</param>
        /// <param name="top">Der obere Abstand</param>
        /// <param name="bottom">Der untere Abstand</param>
        public PropertySpacingMargin(Space left, Space right, Space top, Space bottom)
            : base(left, right, top, bottom)
        {
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>The CSS class belonging to the layout</returns>
        public override string ToClass()
        {
            return ToClass("m");
        }
    }
}
