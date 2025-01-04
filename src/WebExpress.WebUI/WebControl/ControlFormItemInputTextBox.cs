using System;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a text box input form item control.
    /// </summary>
    public class ControlFormItemInputTextBox : ControlFormItemInput
    {
        /// <summary>
        /// Determines whether the control is automatically initialized.
        /// </summary>
        public bool AutoInitialize { get; set; }

        /// <summary>
        /// Determines whether it is a multi-line text box.
        /// </summary>
        public TypesEditTextFormat Format { get; set; }

        /// <summary>
        /// Returns or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets a placeholder text.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Returns or sets the minimum length.
        /// </summary>
        public uint? MinLength { get; set; }

        /// <summary>
        /// Returns or sets the maximum length.
        /// </summary>
        public uint? MaxLength { get; set; }

        /// <summary>
        /// Returns or sets whether inputs are enforced.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Returns or sets a search pattern that checks the content.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Returns or sets the height of the text field (for Multiline and WYSIWYG).
        /// </summary>
        public uint? Rows { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemInputTextBox(string id = null)
            : base(id)
        {
            Name = Id;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None);
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            base.Initialize(renderContext);

            Rows = 8;
            AutoInitialize = true;

            Value = renderContext?.Request.GetParameter(Name)?.Value;

            if (Format == TypesEditTextFormat.Wysiwyg)
            {
                var contextPath = renderContext?.PageContext?.ApplicationContext?.ContextPath;
                //renderContext.AddCssLinks(UriResource.Combine(contextPath, "/assets/css/summernote-bs5.min.css"));
                //renderContext.AddHeaderScriptLinks(UriResource.Combine(contextPath, "/assets/js/summernote-bs5.min.js"));
            }
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext, IVisualTreeControl visualTree)
        {
            var id = Id ?? Guid.NewGuid().ToString();

            Classes.Add("form-control");

            if (Disabled)
            {
                Classes.Add("disabled");
            }

            switch (ValidationResult)
            {
                case TypesInputValidity.Warning:
                    Classes.Add("input-warning");
                    break;
                case TypesInputValidity.Error:
                    Classes.Add("input-error");
                    break;
            }

            if (AutoInitialize && Format == TypesEditTextFormat.Wysiwyg && !string.IsNullOrWhiteSpace(Id))
            {
                var initializeCode = $"$(document).ready(function() {{ $('#{id}').summernote({{ tabsize: 2, height: '{Rows}rem', lang: 'de-DE' }}); }});";

                visualTree.AddScript(id, initializeCode);

                AutoInitialize = false;
            }

            return Format switch
            {
                TypesEditTextFormat.Multiline => new HtmlElementFormTextarea()
                {
                    Id = Id,
                    Value = Value,
                    Name = Name,
                    Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Role = Role,
                    Placeholder = I18N.Translate(renderContext.Request?.Culture, Placeholder),
                    Rows = Rows.ToString()
                },
                TypesEditTextFormat.Wysiwyg => new HtmlElementFormTextarea()
                {
                    Id = id,
                    Value = Value,
                    Name = Name,
                    Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Role = Role,
                    Placeholder = I18N.Translate(renderContext.Request?.Culture, Placeholder),
                    Rows = Rows.ToString()
                },
                _ => new HtmlElementFieldInput()
                {
                    Id = Id,
                    Value = Value,
                    Name = Name,
                    MinLength = MinLength?.ToString(),
                    MaxLength = MaxLength?.ToString(),
                    Required = Required,
                    Pattern = Pattern,
                    Type = "text",
                    Disabled = Disabled,
                    Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                    Role = Role,
                    Placeholder = I18N.Translate(renderContext.Request?.Culture, Placeholder)
                },
            };
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public override void Validate(IRenderControlFormContext renderContext)
        {
            base.Validate(renderContext);

            if (Disabled)
            {
                return;
            }

            if (Required && string.IsNullOrWhiteSpace(base.Value))
            {
                AddValidationResult(new ValidationResult(TypesInputValidity.Error, "webexpress.webui:form.inputtextbox.validation.required"));

                return;
            }

            if (!string.IsNullOrWhiteSpace(MinLength?.ToString()) && Convert.ToInt32(MinLength) > base.Value.Length)
            {
                AddValidationResult(new ValidationResult(TypesInputValidity.Error, string.Format(I18N.Translate(renderContext.Request?.Culture, "webexpress.webui:form.inputtextbox.validation.min"), MinLength)));
            }

            if (!string.IsNullOrWhiteSpace(MaxLength?.ToString()) && Convert.ToInt32(MaxLength) < base.Value.Length)
            {
                AddValidationResult(new ValidationResult(TypesInputValidity.Error, string.Format(I18N.Translate(renderContext.Request?.Culture, "webexpress.webui:form.inputtextbox.validation.max"), MaxLength)));
            }
        }
    }
}
