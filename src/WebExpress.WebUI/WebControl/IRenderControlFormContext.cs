using System.Collections.Generic;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Interface for rendering control form context, extending the base control context interface.
    /// </summary>
    public interface IRenderControlFormContext : IRenderControlContext
    {
        /// <summary>
        /// Returns the form in which the control is rendered.
        /// </summary>
        public IControlForm Form { get; }

        /// <summary>
        /// Returns the validation errors.
        /// </summary>
        public IEnumerable<ValidationResult> ValidationResults { get; }
    }
}
