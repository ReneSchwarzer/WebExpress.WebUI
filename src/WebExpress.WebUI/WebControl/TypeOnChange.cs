namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of action to take on change.
    /// </summary>
    public enum TypeOnChange
    {
        /// <summary>
        /// No action.
        /// </summary>
        None,

        /// <summary>
        /// Submit the form.
        /// </summary>
        Submit
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeOnChange"/> enumeration.
    /// </summary>
    public static class TypeOnChangeExtensions
    {
        /// <summary>
        /// Converts the TypeOnChange value to its corresponding string representation.
        /// </summary>
        /// <param name="value">The TypeOnChange value.</param>
        /// <returns>A string representing the action to take on change.</returns>
        public static string ToValue(this TypeOnChange value)
        {
            return value switch
            {
                TypeOnChange.Submit => "this.form.submit()",
                _ => string.Empty,
            };
        }
    }
}
