namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Spannt die Schaltfläche über die gesammte Bereite
    /// </summary>
    public enum TypeBlockButton
    {
        None,
        Block
    }

    public static class TypeBlockButtonExtensions
    {
        /// <summary>
        /// Conversion to a CSS class.
        /// </summary>
        /// <param name="block">Der Wert, welches umgewandelt werden soll</param>
        /// <returns>Die zum Block gehörende CSS-KLasse</returns>
        public static string ToClass(this TypeBlockButton block)
        {
            return block switch
            {
                TypeBlockButton.Block => "btn-block",
                _ => string.Empty,
            };
        }
    }
}
