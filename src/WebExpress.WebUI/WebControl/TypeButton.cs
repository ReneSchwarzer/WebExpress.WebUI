﻿namespace WebExpress.WebUI.WebControl
{
    public enum TypeButton
    {
        Default = 0, // Button
        Submit = 1,
        Reset = 2
    }

    public static class TypeButtonExtensions
    {
        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="type">Der Typ</param>
        /// <returns>Der String</returns>
        public static string ToTypeString(this TypeButton type)
        {
            switch (type)
            {
                case TypeButton.Submit:
                    return "submit";
                case TypeButton.Reset:
                    return "submit";
            }

            return "button";
        }
    }
}
