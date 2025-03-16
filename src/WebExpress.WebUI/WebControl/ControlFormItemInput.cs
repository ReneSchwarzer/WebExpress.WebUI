using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebIcon;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Identifies a control that is to be filled in by the user.
    /// </summary>
    /// <remarks>
    /// This class provides the base functionality for form input items.
    /// </remarks>
    public abstract class ControlFormItemInput : ControlFormItem, IControlFormLabel, IFormValidation
    {
        private readonly List<ValidationResult> _validationResults = [];
        private readonly List<IControl> _prepend = [];
        private readonly List<IControl> _append = [];

        /// <summary>
        /// Event to validate the input values.
        /// </summary>
        public event EventHandler<ValidationEventArgs> Validation;

        /// <summary>
        /// Determines whether the inputs are valid.
        /// </summary>
        public virtual IEnumerable<ValidationResult> ValidationResults => _validationResults;

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public IIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Returns or sets an optional help text.
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// Returns or sets whether the input element is disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Returns the elements that are displayed in front of the control.
        /// </summary>
        public List<IControl> Prepend => _prepend;

        /// <summary>
        /// Returns the elements that are displayed after the control.
        /// </summary>
        public List<IControl> Append => _append;

        /// <summary>
        /// Returns or sets whether the form element has been validated.
        /// </summary>
        private bool IsValidated { get; set; }

        /// <summary>
        /// Returns or sets an object that is linked to the control.
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Returns the most serious validation result.
        /// </summary>
        public virtual TypesInputValidity ValidationResult
        {
            get
            {
                var buf = ValidationResults;

                if (buf.Where(x => x.Type == TypesInputValidity.Error).Any())
                {
                    return TypesInputValidity.Error;
                }
                else if (buf.Where(x => x.Type == TypesInputValidity.Warning).Any())
                {
                    return TypesInputValidity.Warning;
                }
                else if (buf.Where(x => x.Type == TypesInputValidity.Success).Any())
                {
                    return TypesInputValidity.Success;
                }

                return IsValidated ? TypesInputValidity.Success : TypesInputValidity.Default;
            }
        }

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public virtual string Value { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItemInput(string id)
            : base(id)
        {
            IsValidated = false;
        }

        /// <summary>
        /// Adds one or more controls to the prepend list.
        /// </summary>
        /// <param name="controls">The controls to add.</param>
        public void AddPrepend(params IControl[] controls)
        {
            _prepend.AddRange(controls);
        }

        /// <summary>
        /// Removes a control from the prepend list.
        /// </summary>
        /// <param name="control">The control to remove.</param>
        public void RemovePrepend(IControl control)
        {
            _prepend.Remove(control);
        }

        /// <summary>
        /// Adds one or more controls to the append list.
        /// </summary>
        /// <param name="controls">The controls to add.</param>
        public void AddAppend(params IControl[] controls)
        {
            _append.AddRange(controls);
        }
        /// <summary>
        /// Removes a control from the append list.
        /// </summary>
        /// <param name="control">The control to remove.</param>
        public void RemoveAppend(IControl control)
        {
            _append.Remove(control);
        }

        /// <summary>
        /// Adds a collection of validation results to the existing validation results.
        /// </summary>
        /// <param name="validationResults">The validation results to add.</param>
        /// <remarks>
        /// This method appends the specified collection of <see cref="ValidationResult"/> instances to the 
        /// current list of validation results. It ensures that the new validation results are concatenated 
        /// with the existing ones, maintaining the order of addition.
        /// This method accepts any item that derives from <see cref="ValidationResult"/>.
        /// </remarks>
        public virtual void AddValidationResult(params ValidationResult[] validationResults)
        {
            _validationResults.AddRange(validationResults);
        }

        /// <summary>
        /// Removes a validation result from the validation results collection.
        /// </summary>
        /// <param name="control">The control to remove.</param>
        public virtual void RemoveValidationResult(ValidationResult validationResult)
        {
            _validationResults.Remove(validationResult);
        }

        /// <summary>
        /// Initializes the form emement.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
        }

        /// <summary>
        /// Raises the validation event.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnValidation(ValidationEventArgs e)
        {
            Validation?.Invoke(this, e);
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public virtual void Validate(IRenderControlFormContext renderContext)
        {
            IsValidated = true;

            if (ValidationResults is List<ValidationResult> validationResults)
            {
                validationResults.Clear();

                if (!Disabled)
                {
                    var args = new ValidationEventArgs() { Value = Value, Context = renderContext };
                    OnValidation(args);

                    validationResults.AddRange(args.Results);
                }
            }
        }
    }
}
