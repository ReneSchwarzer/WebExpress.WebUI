﻿namespace WebExpress.WebUI.WebControl
{
    public class PropertyColorText : PropertyColor<TypeColorText>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PropertyColorText()
        {
            SystemColor = (TypeColorText)TypeColor.Default;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorText(TypeColorText color)
        {
            SystemColor = color;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorText(string color)
        {
            SystemColor = (TypeColorText)TypeColor.User;
            UserColor = color;
        }

        /// <summary>
        /// Umwandlung in eine CSS-Klasse
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
                return "color:" + UserColor + ";";
            }

            return null;
        }
    }
}
