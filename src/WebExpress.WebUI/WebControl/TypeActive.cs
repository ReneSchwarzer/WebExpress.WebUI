namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents the active state of a web control.
    /// </summary>
    public enum TypeActive
    {
        /// <summary>
        /// No active state.
        /// </summary>
        None,

        /// <summary>
        /// The control is active.
        /// </summary>
        Active,

        /// <summary>
        /// The control is disabled.
        /// </summary>
        Disabled
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeActive"/> enum.
    /// </summary>
    public static class TypesActiveExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeActive"/> value to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The <see cref="TypeActive"/> value to be converted.</param>
        /// <returns>The CSS class corresponding to the <see cref="TypeActive"/> value.</returns>
        public static string ToClass(this TypeActive layout)
        {
            return layout switch
            {
                TypeActive.Active => "active",
                TypeActive.Disabled => "disabled",
                _ => string.Empty,
            };
        }
    }
}
