namespace WebExpress.WebUI.WebControl
{
    public class PropertyColorProgress : PropertyColor<TypeColorProgress>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorProgress(TypeColorProgress color)
        {
            SystemColor = color;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="color">Die Farbe</param>
        public PropertyColorProgress(string color)
        {
            SystemColor = (TypeColorProgress)TypeColor.User;
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
                return ((TypeColorProgress)SystemColor).ToClass();
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
                return "background:" + UserColor + ";";
            }

            return null;
        }
    }
}
