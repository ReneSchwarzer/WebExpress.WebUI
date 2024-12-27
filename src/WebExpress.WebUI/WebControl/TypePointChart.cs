namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration for different types of point charts.
    /// </summary>
    public enum TypePointChart
    {
        /// <summary>
        /// Circle type point chart.
        /// </summary>
        Circle = 0,

        /// <summary>
        /// Triangle type point chart.
        /// </summary>
        Triangle = 1,

        /// <summary>
        /// Rectangle type point chart.
        /// </summary>
        Rect = 2,

        /// <summary>
        /// Rounded rectangle type point chart.
        /// </summary>
        RectRounded = 3,

        /// <summary>
        /// Rhombus type point chart.
        /// </summary>
        Rhombus
    }

    /// <summary>
    /// Extension methods for the <see cref="TypePointChart"/> enumeration.
    /// </summary>
    public static class TypePointChartExtensions
    {
        /// <summary>
        /// Converts the TypePointChart value to a corresponding CSS class.
        /// </summary>
        /// <param name="color">The TypePointChart value to be converted.</param>
        /// <returns>The CSS class corresponding to the TypePointChart value.</returns>
        public static string ToType(this TypePointChart color)
        {
            return color switch
            {
                TypePointChart.Circle => "circle",
                TypePointChart.Triangle => "triangle",
                TypePointChart.Rect => "rect",
                TypePointChart.RectRounded => "rectRounded",
                TypePointChart.Rhombus => "rectRot",
                _ => "circle",
            };
        }
    }
}
