namespace WebExpress.WebUI.WebControl
{
    public enum TypeFade
    {
        None,
        FadeIn,
        FadeOut,
        FadeShow,
    }

    public static class TypeFadeExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="layout">The layout to be converted</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToClass(this TypeFade layout)
        {
            return layout switch
            {
                TypeFade.FadeIn => "fade in",
                TypeFade.FadeOut => "fade out",
                TypeFade.FadeShow => "fade show",
                _ => string.Empty,
            };
        }
    }
}
