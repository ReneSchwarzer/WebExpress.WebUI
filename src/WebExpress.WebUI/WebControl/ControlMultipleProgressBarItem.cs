namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents an item in a multiple progress bar control.
    /// </summary>
    public class ControlMultipleProgressBarItem
    {
        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        public PropertyColorText Color { get; set; } = new PropertyColorText(TypeColorText.Default);

        /// <summary>
        /// Returns or sets the background color.
        /// </summary>
        public PropertyColorBackground BackgroundColor { get; set; } = new PropertyColorBackground(TypeColorBackground.Default);

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public uint Value { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }
    }
}
