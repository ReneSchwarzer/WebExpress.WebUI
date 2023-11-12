namespace WebExpress.WebUI.WebControl
{
    public class ControlPanelFilter : ControlForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelFilter(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            SubmitButton.Text = "Update";
        }
    }
}
