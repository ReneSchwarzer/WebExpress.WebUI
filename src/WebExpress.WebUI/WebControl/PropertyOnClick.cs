﻿namespace WebExpress.WebUI.WebControl
{
    public class PropertyOnClick
    {
        /// <summary>
        /// Der System-Wert
        /// </summary>
        public TypeOnChange SystemValue { get; protected set; }

        /// <summary>
        /// Der benutzerdefinierte Wert
        /// </summary>
        public string Value { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Der benutzerdefinierte Wert</param>
        public PropertyOnClick(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <returns>Die Stringrepräsentation</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
