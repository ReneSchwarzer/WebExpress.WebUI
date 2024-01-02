namespace WebExpress.WebUI.WebControl
{
    public enum TypeColorBackgroundBadge
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

    public static class TypeColorBackgroundBadgeExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeColorBackgroundBadge layout)
        {
            return layout switch
            {
                TypeColorBackgroundBadge.Primary => "bg-primary",
                TypeColorBackgroundBadge.Secondary => "bg-secondary",
                TypeColorBackgroundBadge.Success => "bg-success",
                TypeColorBackgroundBadge.Info => "bg-info",
                TypeColorBackgroundBadge.Warning => "bg-warning",
                TypeColorBackgroundBadge.Danger => "bg-danger",
                TypeColorBackgroundBadge.Light => "bg-light",
                TypeColorBackgroundBadge.Dark => "bg-dark",
                TypeColorBackgroundBadge.White => "bg-white",
                TypeColorBackgroundBadge.Transparent => "bg-transparent",
                _ => string.Empty,
            };
        }
    }
}
