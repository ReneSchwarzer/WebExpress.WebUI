﻿namespace WebExpress.WebUI.WebControl
{
    public enum TypeOnChange
    {
        None,
        Submit
    }


    public static class TypeOnChangeExtensions
    {
        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Der String</returns>
        public static string ToValue(this TypeOnChange value)
        {
            return value switch
            {
                TypeOnChange.Submit => "this.form.submit()",
                _ => string.Empty,
            };
        }
    }
}
