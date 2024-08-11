﻿namespace WebExpress.WebUI.WebControl
{
    public class PropertyColorBackgroundAlert : PropertyColorBackground
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorBackgroundAlert(TypeColorBackground color)
            : base(color)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorBackgroundAlert(string color)
            : base(color)
        {
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>Die zur Farbe gehörende CSS-KLasse</returns>
        public override string ToClass()
        {
            if ((TypeColor)SystemColor != TypeColor.Default && (TypeColor)SystemColor != TypeColor.User)
            {
                return ((TypeColorBackgroundAlert)SystemColor).ToClass();
            }

            return null;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <returns>Der zur Farbe gehörende CSS-Style</returns>
        public override string ToStyle()
        {
            return base.ToStyle();
        }
    }
}
