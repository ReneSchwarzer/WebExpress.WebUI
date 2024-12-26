namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a toast notification control panel that can contain 
    /// multiple child controls.
    /// </summary>
    public class ControlPanelToast : ControlPanel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="controls">The child controls to be added to the panel.</param>
        public ControlPanelToast(string id = null, params ControlAlert[] controls)
            : base(id, controls)
        {
        }
    }
}
