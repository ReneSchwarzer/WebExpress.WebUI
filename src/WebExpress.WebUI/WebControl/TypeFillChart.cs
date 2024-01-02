namespace WebExpress.WebUI.WebControl
{
    public enum TypeFillChart
    {
        None = 0,
        Origin = 1,
        Start = 2,
        End = 3
    }

    public static class TypeFillChartExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="color">Die Farbe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
