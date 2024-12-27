namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration representing the type of fill for a chart.
    /// </summary>
    public enum TypeFillChart
    {
        /// <summary>
        /// No fill.
        /// </summary>
        None = 0,

        /// <summary>
        /// Fill from the origin.
        /// </summary>
        Origin = 1,

        /// <summary>
        /// Fill from the start.
        /// </summary>
        Start = 2,

        /// <summary>
        /// Fill to the end.
        /// </summary>
        End = 3
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeFillChart"/> enumeration.
    /// </summary>
    public static class TypeFillChartExtensions
    {
        /// <summary>
        /// Converts the TypeFillChart value to a corresponding CSS class.
        /// </summary>
        /// <param name="color">The TypeFillChart value to convert.</param>
        /// <returns>The CSS class corresponding to the TypeFillChart value.</returns>
        public static string ToType(this TypeFillChart color)
        {
            return color switch
            {
                TypeFillChart.None => "false",
                TypeFillChart.Origin => "origin",
                TypeFillChart.Start => "start",
                TypeFillChart.End => "end",
                _ => "false",
            };
        }
    }
}
