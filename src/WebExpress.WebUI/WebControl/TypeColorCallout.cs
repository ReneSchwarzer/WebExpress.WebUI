namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration representing different types of color callouts.
    /// </summary>
    public enum TypeColorCallout
    {
        /// <summary>
        /// Default color callout.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Primary color callout.
        /// </summary>
        Primary = 1,

        /// <summary>
        /// Secondary color callout.
        /// </summary>
        Secondary = 2,

        /// <summary>
        /// Success color callout.
        /// </summary>
        Success = 3,

        /// <summary>
        /// Info color callout.
        /// </summary>
        Info = 4,

        /// <summary>
        /// Warning color callout.
        /// </summary>
        Warning = 5,

        /// <summary>
        /// Danger color callout.
        /// </summary>
        Danger = 6,

        /// <summary>
        /// Dark color callout.
        /// </summary>
        Dark = 7,

        /// <summary>
        /// Light color callout.
        /// </summary>
        Light = 8
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeColorCallout"/> enumeration.
    /// </summary>
    public static class TypeColorCalloutExtensions
    {
        /// <summary>
        /// Converts the TypeColorCallout to a corresponding CSS class.
        /// </summary>
        /// <param name="layout">The TypeColorCallout to be converted.</param>
        /// <returns>The CSS class corresponding to the TypeColorCallout.</returns>
        public static string ToClass(this TypeColorCallout layout)
        {
            return layout switch
            {
                TypeColorCallout.Primary => "callout-primary",
                TypeColorCallout.Secondary => "callout-secondary",
                TypeColorCallout.Success => "callout-success",
                TypeColorCallout.Info => "callout-info",
                TypeColorCallout.Warning => "callout-warning",
                TypeColorCallout.Danger => "callout-danger",
                TypeColorCallout.Light => "callout-light",
                TypeColorCallout.Dark => "callout-dark",
                _ => string.Empty,
            };
        }
    }
}
