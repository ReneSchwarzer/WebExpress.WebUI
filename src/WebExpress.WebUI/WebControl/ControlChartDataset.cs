using System.Collections.Generic;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a dataset for a chart control.
    /// </summary>
    public class ControlChartDataset
    {
        /// <summary>
        /// Returns or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Returns or sets the data.
        /// </summary>
        public float[] Data { get; set; }

        /// <summary>
        /// Returns or sets the background color.
        /// </summary>
        public List<PropertyColorChart> BackgroundColor { get; set; } = [new PropertyColorChart(TypeColorChart.Primary)];

        /// <summary>
        /// Returns or sets the frame color.
        /// </summary>
        public List<PropertyColorChart> BorderColor { get; set; } = [new PropertyColorChart(TypeColorChart.Primary)];

        /// <summary>
        /// Returns or sets how the data series are populated.
        /// </summary>
        public TypeFillChart Fill { get; set; } = TypeFillChart.None;

        /// <summary>
        /// Returns or sets how the data series are populated.
        /// </summary>
        public TypePointChart Point { get; set; } = TypePointChart.Circle;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ControlChartDataset()
        {
        }
    }
}
