﻿namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Die Größenmöglichkeiten
    /// </summary>
    public enum TypeSizePagination
    {
        Default,
        Small,
        Large
    }

    public static class TypeSizePaginationExtensions
    {
        /// <summary>
        /// Umwandlung in eine CSS-Klasse
        /// </summary>
        /// <param name="size">Die Größe, welches umgewandelt werden soll</param>
        /// <returns>Die zum Layout gehörende CSS-KLasse</returns>
        public static string ToClass(this TypeSizePagination size)
        {
            return size switch
            {
                TypeSizePagination.Large => "pagination-lg",
                TypeSizePagination.Small => "pagination-sm",
                _ => string.Empty,
            };
        }
    }
}
