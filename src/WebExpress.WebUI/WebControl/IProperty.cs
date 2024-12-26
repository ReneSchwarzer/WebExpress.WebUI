namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Interface for defining properties that can be converted to CSS classes or styles.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <returns>Die zur Eigenschaft gehörende CSS-KLasse</returns>
        string ToClass();

        /// <summary>
        /// Umwandlung in einen CSS-Style
        /// </summary>
        /// <returns>Der zur Eigenschaft gehörende CSS-Style</returns>
        public abstract string ToStyle();
    }
}
