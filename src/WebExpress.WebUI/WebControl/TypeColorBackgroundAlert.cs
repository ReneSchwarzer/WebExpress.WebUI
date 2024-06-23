namespace WebExpress.WebUI.WebControl
{
    public enum TypeColorBackgroundAlert
    {
        Default = 0,
        Primary = 1,
        Secondary = 2,
        Success = 3,
        Info = 4,
        Warning = 5,
        Danger = 6,
        Dark = 7,
        Light = 8,
        White = 9,
        Transparent = 10
    }

    public static class TypeColorBackgroundAlertExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeColorBackgroundAlert layout)
        {
            return layout switch
            {
                TypeColorBackgroundAlert.Primary => "bg-primary",
                TypeColorBackgroundAlert.Secondary => "bg-secondary",
                TypeColorBackgroundAlert.Success => "alert-success",
                TypeColorBackgroundAlert.Info => "alert-info",
                TypeColorBackgroundAlert.Warning => "alert-warning",
                TypeColorBackgroundAlert.Danger => "alert-danger",
                TypeColorBackgroundAlert.Light => "alert-light",
                TypeColorBackgroundAlert.Dark => "alert-dark",
                TypeColorBackgroundAlert.White => "bg-white",
                TypeColorBackgroundAlert.Transparent => "bg-transparent",
                _ => string.Empty,
            };
        }
    }
}
