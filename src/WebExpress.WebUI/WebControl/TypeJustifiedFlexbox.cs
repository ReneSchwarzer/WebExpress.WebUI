namespace WebExpress.WebUI.WebControl
{
    public enum TypeJustifiedFlexbox
    {
        None,
        Start,
        End,
        Center,
        Between,
        Around
    }

    public static class TypeTypeJustifiedFlexboxExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeJustifiedFlexbox layout)
        {
            return layout switch
            {
                TypeJustifiedFlexbox.Start => "justify-content-start",
                TypeJustifiedFlexbox.End => "justify-content-end",
                TypeJustifiedFlexbox.Center => "justify-content-center",
                TypeJustifiedFlexbox.Between => "justify-content-between",
                TypeJustifiedFlexbox.Around => "justify-content-around",
                _ => string.Empty,
            };
        }
    }

}
