namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a separator item in a toolbar.
    /// </summary>
    public class ControlToolbarItemDivider : ControlLine, IControlToolbarItem
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlToolbarItemDivider(string id = null)
            : base(id)
        {
        }
    }
}
