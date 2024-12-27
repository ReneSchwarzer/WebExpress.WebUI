using System.Text;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the maximum size properties of an icon, including width, height, and unit.
    /// </summary>
    public class PropertyMaxSizeIcon : PropertySizeIcon
    {
        /// <summary>
        /// Initializes a new instance of the class with a specified size and unit.
        /// </summary>
        /// <param name="size">The size of the icon.</param>
        /// <param name="unit">The unit of the size.</param>
        public PropertyMaxSizeIcon(int size, TypeSizeUnit unit)
            : base(size, unit)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class with specified width, height, and unit.
        /// </summary>
        /// <param name="width">The width of the icon in pixels.</param>
        /// <param name="height">The height of the icon in pixels.</param>
        /// <param name="unit">The unit of the size.</param>
        public PropertyMaxSizeIcon(int width, int height, TypeSizeUnit unit)
            : base(width, height, unit)
        {
        }

        /// <summary>
        /// Converts the property to a CSS class.
        /// </summary>
        /// <returns>The CSS class corresponding to the property.</returns>
        public override string ToClass()
        {
            return null;
        }

        /// <summary>
        /// Converts the property to a CSS style.
        /// </summary>
        /// <returns>The CSS style corresponding to the property.</returns>
        public override string ToStyle()
        {
            var style = new StringBuilder();

            var unit = Unit switch
            {
                TypeSizeUnit.Pixel => "px",
                TypeSizeUnit.Percent => "%",
                TypeSizeUnit.Em => "em",
                TypeSizeUnit.Rem => "rem",
                _ => string.Empty
            };

            if (Width > -1)
            {
                style.Append($"max-width: {Width}{unit}; ");
            }

            if (Height > -1)
            {
                style.Append($"max-height: {Height}{unit};");
            }

            return style.ToString();
        }
    }
}
