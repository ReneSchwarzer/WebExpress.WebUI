namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a property for border color, which can be converted to CSS class or style.
    /// </summary>
    public class PropertyColorBorder : PropertyColor<TypeColorBorder>
    {
        /// <summary>
        /// Initializes a new instance of the class with a specified system color.
        /// </summary>
        /// <param name="color">The system color.</param>
        public PropertyColorBorder(TypeColorBorder color)
        {
            SystemColor = color;
        }

        /// <summary>
        /// Initializes a new instance of the class with a specified user color.
        /// </summary>
        /// <param name="color">The user-defined color.</param>
        public PropertyColorBorder(string color)
        {
            SystemColor = (TypeColorBorder)TypeColor.User;
            UserColor = color;
        }

        /// <summary>
        /// Converts the border color property to a CSS class.
        /// </summary>
        /// <returns>The CSS class corresponding to the border color.</returns>
        public override string ToClass()
        {
            if ((TypeColor)SystemColor != TypeColor.Default && (TypeColor)SystemColor != TypeColor.User)
            {
                return SystemColor.ToClass();
            }

            return null;
        }

        /// <summary>
        /// Converts the border color property to a CSS style.
        /// </summary>
        /// <returns>The CSS style corresponding to the border color.</returns>
        public override string ToStyle()
        {
            if ((TypeColor)SystemColor == TypeColor.User)
            {
                return "border-color:" + UserColor + ";";
            }

            return null;
        }
    }
}
