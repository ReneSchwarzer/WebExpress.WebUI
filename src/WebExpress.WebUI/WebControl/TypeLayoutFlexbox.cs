namespace WebExpress.WebUI.WebControl
{
    public enum TypeLayoutFlexbox
    {
        None,
        Default,
        Inline
    }

    public static class TypeInlineFlexboxExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeLayoutFlexbox layout)
        {
            return layout switch
            {
                TypeLayoutFlexbox.Default => "d-flex",
                TypeLayoutFlexbox.Inline => "d-inline-flex",
                _ => string.Empty,
            };
        }
    }
}
