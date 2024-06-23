namespace WebExpress.WebUI.WebControl
{
    public enum TypeAlignFlexbox
    {
        None,
        Start,
        End,
        Center,
        Baseline,
        Stretch
    }

    public static class TypeAlignFlexboxExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeAlignFlexbox layout)
        {
            return layout switch
            {
                TypeAlignFlexbox.Start => "align-items-start",
                TypeAlignFlexbox.End => "align-items-end",
                TypeAlignFlexbox.Center => "align-items-center",
                TypeAlignFlexbox.Baseline => "align-items-baseline",
                TypeAlignFlexbox.Stretch => "align-items-stretch",
                _ => string.Empty,
            };
        }
    }

}
