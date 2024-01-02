namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Kennzeichnet ein Element als Eigenschaft
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
