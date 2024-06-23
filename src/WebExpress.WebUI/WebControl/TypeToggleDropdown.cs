namespace WebExpress.WebUI.WebControl
{
    public enum TypeToggleDropdown
    {
        None,
        Toggle
    }

    public static class TypeToggleDropdownExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeToggleDropdown layout)
        {
            return layout switch
            {
                TypeToggleDropdown.Toggle => "dropdown-toggle",
                _ => string.Empty,
            };
        }
    }
}
