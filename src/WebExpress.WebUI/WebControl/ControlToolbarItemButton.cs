namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a toolbar item button control.
    /// </summary>
    /// <remarks>
    /// This class is used to create a button within a toolbar.
    /// </remarks>
    public class ControlToolbarItemButton : ControlLink, IControlToolbarItem
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlToolbarItemButton(string id = null)
            : base(id)
        {
            Classes.Add("nav-link");

            //TextColor = LayoutSchema.ToolbarLink;
        }
    }
}
