namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Creates a slideshow element.
    /// </summary>
    public class ControlCarouselItem
    {
        /// <summary>
        /// Returns or sets the headline.
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Retruns or sets the slideshow element, such as an image.
        /// </summary>
        public IControl Control { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControlCarouselItem()
        {
        }

    }
}
