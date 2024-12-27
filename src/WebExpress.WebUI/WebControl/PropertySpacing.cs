namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the spacing properties for a web control.
    /// </summary>
    public abstract class PropertySpacing : IProperty
    {
        /// <summary>
        /// The possible spacing values.
        /// </summary>
        public enum Space { None, Null, One, Two, Three, Four, Five, Auto };

        /// <summary>
        /// Returns the top spacing.
        /// </summary>
        public Space Top { get; private set; }

        /// <summary>
        /// Returns the bottom spacing.
        /// </summary>
        public Space Bottom { get; private set; }

        /// <summary>
        /// Returns the left spacing.
        /// </summary>
        public Space Left { get; private set; }

        /// <summary>
        /// Returns the right spacing.
        /// </summary>
        public Space Right { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PropertySpacing()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class with the same spacing for all sides.
        /// </summary>
        /// <param name="size">The spacing size for all sides.</param>
        public PropertySpacing(Space size)
        {
            Top = Bottom = Left = Right = size;
        }

        /// <summary>
        /// Initializes a new instance of the class with different horizontal and vertical spacing.
        /// </summary>
        /// <param name="horizontal">The horizontal spacing.</param>
        /// <param name="vertical">The vertical spacing.</param>
        public PropertySpacing(Space horizontal, Space vertical)
        {
            Left = Right = horizontal;
            Top = Bottom = vertical;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertySpacing"/> class with specific spacing for each side.
        /// </summary>
        /// <param name="left">The left spacing.</param>
        /// <param name="right">The right spacing.</param>
        /// <param name="top">The top spacing.</param>
        /// <param name="bottom">The bottom spacing.</param>
        public PropertySpacing(Space left, Space right, Space top, Space bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Converts a spacing value to its string representation.
        /// </summary>
        /// <param name="size">The spacing value.</param>
        /// <returns>The string representation of the spacing value.</returns>
        protected static string ConvertSize(Space size)
        {
            return size switch
            {
                Space.Null => "0",
                Space.One => "1",
                Space.Two => "2",
                Space.Three => "3",
                Space.Four => "4",
                Space.Five => "5",
                Space.Auto => "auto",
                _ => string.Empty,
            };
        }

        /// <summary>
        /// Converts the spacing values to a CSS class.
        /// </summary>
        /// <param name="prefix">The prefix for the CSS class.</param>
        /// <returns>The CSS class representing the spacing values.</returns>
        protected string ToClass(string prefix)
        {
            if (Top == Bottom && Top == Left && Top == Right && Top == Space.None)
            {
                return null;
            }
            if (Top == Bottom && Top == Left && Top == Right)
            {
                return prefix + "-" + ConvertSize(Top);
            }
            // 
            else if (Top == Bottom && Left == Right && Top == Space.None && Left != Space.None)
            {
                return prefix + "x-" + ConvertSize(Left);
            }
            else if (Top == Bottom && Left == Right && Top != Space.None && Left == Space.None)
            {
                return prefix + "y-" + ConvertSize(Top);
            }
            else if (Top == Bottom && Left == Right && Top != Space.None && Left != Space.None)
            {
                return prefix + "x-" + ConvertSize(Left) + " " + prefix + "y-" + ConvertSize(Top);
            }
            //
            else if (Top != Space.None && Bottom == Space.None && Left == Space.None && Right == Space.None)
            {
                return prefix + "t-" + ConvertSize(Top);
            }
            else if (Top != Space.None && Bottom != Space.None && Left == Space.None && Right == Space.None)
            {
                return prefix + "t -" + ConvertSize(Top) + " " + prefix + "b-" + ConvertSize(Bottom);
            }
            else if (Top != Space.None && Bottom == Space.None && Left != Space.None && Right == Space.None)
            {
                return prefix + "t-" + ConvertSize(Top) + " " + prefix + "s-" + ConvertSize(Left);
            }
            else if (Top != Space.None && Bottom == Space.None && Left == Space.None && Right != Space.None)
            {
                return prefix + "t-" + ConvertSize(Top) + " " + prefix + "e-" + ConvertSize(Right);
            }
            else if (Top != Space.None && Bottom != Space.None && Left != Space.None && Right == Space.None)
            {
                return prefix + "t-" + ConvertSize(Top) + " " + prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "s-" + ConvertSize(Left);
            }
            else if (Top != Space.None && Bottom != Space.None && Left == Space.None && Right != Space.None)
            {
                return prefix + "t-" + ConvertSize(Top) + " " + prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "e-" + ConvertSize(Right);
            }
            else if (Top != Space.None && Bottom != Space.None && Left != Space.None && Right != Space.None)
            {
                return prefix + "t-" + ConvertSize(Top) + " " + prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "s-" + ConvertSize(Left) + " " + prefix + "e-" + ConvertSize(Right);
            }
            //
            else if (Top == Space.None && Bottom != Space.None && Left == Space.None && Right == Space.None)
            {
                return prefix + "b-" + ConvertSize(Bottom);
            }
            else if (Top == Space.None && Bottom != Space.None && Left != Space.None && Right == Space.None)
            {
                return prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "s-" + ConvertSize(Left);
            }
            else if (Top == Space.None && Bottom != Space.None && Left == Space.None && Right != Space.None)
            {
                return prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "e-" + ConvertSize(Right);
            }
            else if (Top == Space.None && Bottom != Space.None && Left != Space.None && Right != Space.None)
            {
                return prefix + "b-" + ConvertSize(Bottom) + " " + prefix + "s-" + ConvertSize(Left) + " " + prefix + "e-" + ConvertSize(Right);
            }
            //
            else if (Top == Space.None && Bottom == Space.None && Left != Space.None && Right == Space.None)
            {
                return prefix + "s-" + ConvertSize(Left);
            }
            else if (Top == Space.None && Bottom == Space.None && Left != Space.None && Right != Space.None)
            {
                return prefix + "s-" + ConvertSize(Left) + " " + prefix + "e-" + ConvertSize(Right);
            }
            //
            else if (Top == Space.None && Bottom == Space.None && Left == Space.None && Right != Space.None)
            {
                return prefix + "e-" + ConvertSize(Right);
            }

            return null;
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>The CSS class representing the spacing.</returns>
        public abstract string ToClass();

        /// <summary>
        /// Conversion to a CSS style.
        /// </summary>
        /// <returns>The CSS style representing the spacing.</returns>
        public virtual string ToStyle()
        {
            return null;
        }
    }
}
