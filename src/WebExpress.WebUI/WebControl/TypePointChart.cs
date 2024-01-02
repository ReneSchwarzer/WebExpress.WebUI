namespace WebExpress.WebUI.WebControl
{
    public enum TypePointChart
    {
        Circle = 0,
        Triangle = 1,
        Rect = 2,
        RectRounded = 3,
        Rhombus
    }

    public static class TypePointChartExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="color">Die Farbe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
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
