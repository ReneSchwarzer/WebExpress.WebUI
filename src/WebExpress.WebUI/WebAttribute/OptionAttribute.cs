﻿using System;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    /// <summary>
    /// Activation of options (e.g. WebEx.WebApp.Setting.SystemInformation for the display of system information).
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class OptionAttribute : System.Attribute, IResourceAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="option">The option to activate.</param>
        public OptionAttribute(string option)
        {

        }
    }
}
