namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Interface for defining properties that can be converted to CSS classes or styles.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Converts the property to a CSS class.
        /// </summary>
        /// <returns>The CSS class corresponding to the property.</returns>
        string ToClass();

        /// <summary>
        /// Converts the property to a CSS style.
        /// </summary>
        /// <returns>The CSS style corresponding to the property.</returns>
        public abstract string ToStyle();
    }
}
