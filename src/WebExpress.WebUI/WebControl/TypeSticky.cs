﻿namespace WebExpress.WebUI.WebControl
{
    public enum TypeSticky
    {
        None,
        Top
    }

    public static class TypeStickyExtensions
    {
        /// <summary>
        /// Umwandlung in eine CSS-Klasse
        /// </summary>
        /// <param name="layout">Das Layout, welches umgewandelt werden soll</param>
        /// <returns>Die zum Layout gehörende CSS-KLasse</returns>
        public static string ToClass(this TypeSticky layout)
        {
            return layout switch
            {
                TypeSticky.Top => "sticky-top",
                _ => string.Empty,
            };
        }
    }
}
