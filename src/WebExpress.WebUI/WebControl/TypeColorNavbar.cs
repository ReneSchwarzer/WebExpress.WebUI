namespace WebExpress.WebUI.WebControl
{
    public enum TypeColorNavbar
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

    public static class TypeColorNavbarExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeColorNavbar layout)
        {
            return layout switch
            {
                TypeColorNavbar.Primary => "navbar-primary",
                TypeColorNavbar.Secondary => "navbar-secondary",
                TypeColorNavbar.Success => "navbar-success",
                TypeColorNavbar.Info => "navbar-info",
                TypeColorNavbar.Warning => "navbar-warning",
                TypeColorNavbar.Danger => "navbar-danger",
                TypeColorNavbar.Light => "navbar-light",
                TypeColorNavbar.Dark => "navbar-dark",
                TypeColorNavbar.White => "navbar-white",
                TypeColorNavbar.Transparent => "navbar-transparent",
                _ => string.Empty,
            };
        }
    }
}
