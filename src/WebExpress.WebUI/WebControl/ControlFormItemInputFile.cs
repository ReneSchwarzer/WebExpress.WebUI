using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a form item input control for file uploads.
    /// </summary>
    /// <remarks>
    /// This control allows users to select files to upload. It supports setting descriptions, placeholders, 
    /// required fields, and accepted file types. It also provides validation and rendering functionalities.
    /// </remarks>
    public class ControlFormItemInputFile : ControlFormItemInput
    {
        private readonly List<string> _acceptFile = [];

        /// <summary>
        /// Returns or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets a placeholder text.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Returns or sets whether inputs are enforced.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Returns or sets the accepted files.
        /// </summary>
        public IEnumerable<string> AcceptFile => _acceptFile;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemInputFile(string id = null)
            : base(!string.IsNullOrWhiteSpace(id) ? id : "file")
        {
            Name = Id;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None);
        }

        /// <summary>
        /// Adds one or more accepted file types to the control.
        /// </summary>
        /// <param name="controls">The file types to add.</param>
        public void AddAcceptFile(params string[] controls)
        {
            _acceptFile.AddRange(controls);
        }

        /// <summary>
        /// Removes an accepted file type from the control.
        /// </summary>
        /// <param name="control">The file type to remove.</param>
        public void RemoveAcceptFile(string control)
        {
            _acceptFile.Remove(control);
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            Value = renderContext?.Request.GetParameter(Name)?.Value;
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext, IVisualTreeControl visualTree)
        {
            var resultClasses = ValidationResult switch
            {
                TypesInputValidity.Warning => "input-warning",
                TypesInputValidity.Error => "input-error",
                _ => ""
            };

            var html = new HtmlElementFieldInput()
            {
                Id = Id,
                Value = Value,
                Name = Name,
                Type = "file",
                Class = Css.Concatenate("form-control-file", resultClasses, GetClasses()),
                Style = GetStyles(),
                Role = Role,
                Placeholder = Placeholder
            };

            html.AddUserAttribute("accept", string.Join(",", AcceptFile));

            return html;
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public override void Validate(IRenderControlFormContext renderContext)
        {
            if (Disabled)
            {
                return;
            }

            if (Required && string.IsNullOrWhiteSpace(base.Value))
            {
                AddValidationResult(new ValidationResult(TypesInputValidity.Error, "webexpress.webui:form.inputfile.validation.required"));

                return;
            }

            base.Validate(renderContext);
        }
    }
}
