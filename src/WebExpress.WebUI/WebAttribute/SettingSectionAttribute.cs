﻿using System;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebUI.WebAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SettingSectionAttribute : System.Attribute, IResourceAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="section">The section where the settings page is listed.</param>
        public SettingSectionAttribute(SettingSection section)
        {

        }
    }
}
