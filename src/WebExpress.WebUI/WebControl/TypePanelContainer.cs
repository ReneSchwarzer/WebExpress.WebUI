﻿namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Layoutmöglichkeiten des Panels-Steuerelementes
    /// </summary>
    public enum TypePanelContainer
    {
        None,
        Default,
        Fluid
    }

    public static class TypePanelFluidExtensions
    {
        /// <summary>
        /// Umwandlung in eine CSS-Klasse
        /// </summary>
        /// <param name="layout">Das Layout, welches umgewandelt werden soll</param>
        /// <returns>Die zum Layout gehörende CSS-KLasse</returns>
        public static string ToClass(this TypePanelContainer layout)
        {
            return layout switch
            {
                TypePanelContainer.Default => "container",
                TypePanelContainer.Fluid => "container-fluid",
                _ => string.Empty,
            };
        }
    }
}
