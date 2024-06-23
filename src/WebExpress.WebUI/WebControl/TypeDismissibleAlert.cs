namespace WebExpress.WebUI.WebControl
{
    public enum TypeDismissibleAlert
    {
        None,
        Dismissible
    }

    public static class TypeDismissibleAlertExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
