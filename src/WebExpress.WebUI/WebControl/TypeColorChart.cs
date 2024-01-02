namespace WebExpress.WebUI.WebControl
{
    public enum TypeColorChart
    {
        Default = 0,
        Primary = 1,
        Secondary = 2,
        Success = 3,
        Info = 4,
        Warning = 5,
        Danger = 6,
        Dark = 7,
        Light = 8
    }

    public static class TypeColorChartExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="color">Die Farbe, welches umgewandelt werden soll</param>
        /// <returns>The CSS class belonging to the layout</returns>
        public static string ToChartColor(this TypeColorChart color)
        {
            switch (color)
            {
                case TypeColorChart.Primary:
                    return "#007bff";
                case TypeColorChart.Secondary:
                    return "#6c757d";
                case TypeColorChart.Success:
                    return "#28a745";
                case TypeColorChart.Info:
                    return "#17a2b8";
                case TypeColorChart.Warning:
                    return "#ffc107";
                case TypeColorChart.Danger:
                    return "#dc3545";
                case TypeColorChart.Light:
                    return "#f8f9fa";
                case TypeColorChart.Dark:
                    return "#343a40";
                case TypeColorChart.Default:
                    break;
            }

            return string.Empty;
        }
    }
}
