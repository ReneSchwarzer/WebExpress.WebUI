namespace WebExpress.WebUI.WebControl
{
    public enum TypeChart
    {
        Line = 0,
        Bar = 1,
        Pie = 2,
        Doughnut = 3,
        //Polar = 4,
        Radar = 5
    }

    public static class TypeChartExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="color">Die Farbe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
