namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a property color chart that can be converted to CSS classes or styles.
    /// </summary>
    public class PropertyColorChart : PropertyColor<TypeColorChart>
    {
        /// <summary>
        /// Initializes a new instance of the class with the default color.
        /// </summary>
        public PropertyColorChart()
        {
            SystemColor = (TypeColorChart)TypeColor.Default;
        }

        /// <summary>
        /// Initializes a new instance of the class with the specified system color.
        /// </summary>
        /// <param name="color">The system color.</param>
        public PropertyColorChart(TypeColorChart color)
        {
            SystemColor = color;
        }

        /// <summary>
        /// Initializes a new instance of the class with the specified user-defined color.
        /// </summary>
        /// <param name="color">The user-defined color.</param>
        public PropertyColorChart(string color)
        {
            SystemColor = (TypeColorChart)TypeColor.User;
            UserColor = color;
        }

        /// <summary>
        /// Converts the property color to a CSS class.
        /// </summary>
        /// <returns>The CSS class corresponding to the badge color.</returns>
        public override string ToClass()
        {
            return null;
        }

        /// <summary>
        /// Converts the property color to a CSS style.
        /// </summary>
        /// <returns>The CSS style corresponding to the progress color.</returns>
        public override string ToStyle()
        {
            return null;
        }

        /// <summary>
        /// Converts the property color to a string representation.
        /// </summary>
        /// <returns>The CSS class or user-defined color as a string.</returns>
        public override string ToString()
        {
            if ((TypeColor)SystemColor != TypeColor.Default && (TypeColor)SystemColor != TypeColor.User)
            {
                return SystemColor.ToChartColor();
            }
            else if ((TypeColor)SystemColor == TypeColor.User)
            {
                return UserColor;
            }

            return null;
        }
    }
}
