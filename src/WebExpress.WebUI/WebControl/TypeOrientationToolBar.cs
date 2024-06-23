namespace WebExpress.WebUI.WebControl
{
    public enum TypeOrientationToolBar
    {
        Default,
        Horizontal,
        Vertical
    }

    public static class TypeOrientationToolBarExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeOrientationToolBar layout)
        {
            return layout switch
            {
                TypeOrientationToolBar.Horizontal => string.Empty,
                _ => "navbar-expand-sm",
            };
        }
    }
}
