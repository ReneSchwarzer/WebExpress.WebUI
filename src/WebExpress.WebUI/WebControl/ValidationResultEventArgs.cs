﻿using System;
using System.Collections.Generic;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Eventargument, welches nach einer volständigen Validierung des Formulars mit allen Stuerelementen erstellt wird
    /// </summary>
    public class ValidationResultEventArgs : EventArgs
    {
        /// <summary>
        /// Bestimmt, ob die Validierung erfolgreich abgeschlossen wurde
        /// </summary>
        public bool Valid { get; private set; }

        /// <summary>
        /// Liefert oder setzt die Validierungsnachrichten
        /// </summary>
        public List<ValidationResult> Results { get; private set; } = new List<ValidationResult>();

        /// <summary>
        /// Constructor
        /// </summary>
        public ValidationResultEventArgs()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="valid"> true wenn die Validierung erfolgreich abgeschlossen wurde, false sonst</param>
        public ValidationResultEventArgs(bool valid)
        {
            Valid = valid;
        }
    }
}
