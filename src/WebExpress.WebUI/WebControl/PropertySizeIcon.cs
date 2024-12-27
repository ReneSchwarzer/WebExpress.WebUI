using System.Text;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the size properties of an icon, including width, height, and unit.
    /// </summary>
    public class PropertySizeIcon : IProperty
    {
        /// <summary>
        /// Gets the unit of measurement for the size.
        /// </summary>
        public TypeSizeUnit Unit { get; protected set; } = TypeSizeUnit.Pixel;

        /// <summary>
        /// Gets the width of the icon.
        /// </summary>
        public int Width { get; protected set; } = -1;

        /// <summary>
        /// Gets the height of the icon.
        /// </summary>
        public int Height { get; protected set; } = -1;

        /// <summary>
        /// Initializes a new instance of the class with the same width and height.
        /// </summary>
        /// <param name="size">The size of the icon.</param>
        /// <param name="unit">The unit of measurement for the size.</param>
        public PropertySizeIcon(int size, TypeSizeUnit unit)
        {
            Width = size;
            Height = size;
            Unit = unit;
        }

        /// <summary>
        /// Initializes a new instance of the class with specified width and height.
        /// </summary>
        /// <param name="width">The width of the icon.</param>
        /// <param name="height">The height of the icon.</param>
        /// <param name="unit">The unit of measurement for the size.</param>
        public PropertySizeIcon(int width, int height, TypeSizeUnit unit)
        {
            Width = width;
            Height = height;
            Unit = unit;
        }

        /// <summary>
        /// Converts the size properties to a CSS class.
        /// </summary>
        /// <returns>The CSS class representing the size properties.</returns>
        public virtual string ToClass()
        {
            return null;
        }

        /// <summary>
        /// Converts the size properties to a CSS style.
        /// </summary>
        /// <returns>The CSS style representing the size properties.</returns>
        public virtual string ToStyle()
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
                style.Append($"width: {Width}{unit}; ");
            }

            if (Height > -1)
            {
                style.Append($"height: {Height}{unit};");
            }

            return style.ToString();
        }
    }
}
