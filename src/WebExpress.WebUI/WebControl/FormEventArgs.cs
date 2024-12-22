﻿using System;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Event argument for forms.
    /// </summary>
    public class FormEventArgs : EventArgs
    {
        /// <summary>
        /// The form render context.
        /// </summary>
        public IRenderControlFormContext Context { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FormEventArgs()
        {
        }
    }
}
