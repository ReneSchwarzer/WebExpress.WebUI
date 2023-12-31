﻿namespace WebExpress.WebUI.WebControl
{
    public class ControlToolBarItemButton : ControlLink, IControlToolBarItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlToolBarItemButton(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Classes.Add("nav-link");

            //TextColor = LayoutSchema.ToolbarLink;
        }
    }
}
