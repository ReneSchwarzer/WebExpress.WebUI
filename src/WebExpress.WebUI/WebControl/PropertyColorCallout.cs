﻿namespace WebExpress.WebUI.WebControl
{
    public class PropertyColorCallout : PropertyColor<TypeColorCallout>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorCallout(TypeColorCallout color)
        {
            SystemColor = color;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorCallout(string color)
        {
            SystemColor = (TypeColorCallout)TypeColor.User;
            UserColor = color;
        }

        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>Die zur Farbe gehörende CSS-KLasse</returns>
        public override string ToClass()
        {
            if ((TypeColor)SystemColor != TypeColor.Default && (TypeColor)SystemColor != TypeColor.User)
            {
                return SystemColor.ToClass();
            }

            return null;
        }

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <returns>Der zur Farbe gehörende CSS-Style</returns>
        public override string ToStyle()
        {
            if ((TypeColor)SystemColor == TypeColor.User)
            {
                return "border-left-color:" + UserColor + ";";
            }

            return null;
        }

    }
}
