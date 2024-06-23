namespace WebExpress.WebUI.WebControl
{
    public enum TypeWrap
    {
        None,
        Nowrap,
        Wrap,
        Reverse
    }

    public static class TypeWrapExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeWrap layout)
        {
            return layout switch
            {
                TypeWrap.Nowrap => "flex-nowrap",
                TypeWrap.Wrap => "flex-wrap",
                TypeWrap.Reverse => "flex-wrap-reverse",
                _ => string.Empty,
            };
        }
    }

}
