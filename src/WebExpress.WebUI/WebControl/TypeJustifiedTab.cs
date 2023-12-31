﻿namespace WebExpress.WebUI.WebControl
{
    public enum TypeJustifiedTab
    {
        Default,
        Justified
    }

    public static class TypeJustifiedTabExtensions
    {
        /// <summary>
        /// Umwandlung in eine CSS-Klasse
        /// </summary>
        /// <param name="layout">Das Layout, welches umgewandelt werden soll</param>
        /// <returns>Die zum Layout gehörende CSS-KLasse</returns>
        public static string ToClass(this TypeJustifiedTab layout)
        {
            return layout switch
            {
                TypeJustifiedTab.Justified => "nav-justified",
                _ => string.Empty,
            };
        }
    }
}
