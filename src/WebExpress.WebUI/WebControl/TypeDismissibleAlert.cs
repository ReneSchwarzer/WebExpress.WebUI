namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Specifies the type of dismissible alert.
    /// </summary>
    public enum TypeDismissibleAlert
    {
        /// <summary>
        /// No dismissible alert.
        /// </summary>
        None,

        /// <summary>
        /// Dismissible alert.
        /// </summary>
        Dismissible
    }

    /// <summary>
    /// Provides extension methods for the <see cref="TypeDismissibleAlert"/> enum.
    /// </summary>
    public static class TypeDismissibleAlertExtensions
    {
        /// <summary>
        /// Converts the <see cref="TypeDismissibleAlert"/> to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The CSS class corresponding to the layout.</returns>
        public static string ToClass(this TypeDismissibleAlert layout)
        {
            return layout switch
            {
                TypeDismissibleAlert.Dismissible => "alert-dismissible",
                _ => string.Empty,
            };
        }
    }
}
