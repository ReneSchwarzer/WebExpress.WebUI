namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Enumeration representing different types of charts.
    /// </summary>
    public enum TypeChart
    {
        /// <summary>
        /// Line chart type.
        /// </summary>
        Line = 0,

        /// <summary>
        /// Bar chart type.
        /// </summary>
        Bar = 1,

        /// <summary>
        /// Pie chart type.
        /// </summary>
        Pie = 2,

        /// <summary>
        /// Doughnut chart type.
        /// </summary>
        Doughnut = 3,

        // Polar = 4,

        /// <summary>
        /// Radar chart type.
        /// </summary>
        Radar = 5
    }

    /// <summary>
    /// Extension methods for the <see cref="TypeChart"/> enumeration.
    /// </summary>
    public static class TypeChartExtensions
    {
        /// <summary>
        /// Converts the chart type to a corresponding CSS class.
        /// </summary>
        /// <param name="color">The chart type to be converted.</param>
        /// <returns>The CSS class corresponding to the chart type.</returns>
        public static string ToType(this TypeChart color)
        {
            return color switch
            {
                TypeChart.Line => "line",
                TypeChart.Bar => "bar",
                TypeChart.Pie => "pie",
                TypeChart.Doughnut => "doughnut",
                TypeChart.Radar => "radar",
                _ => "line",
            };
        }
    }
}
