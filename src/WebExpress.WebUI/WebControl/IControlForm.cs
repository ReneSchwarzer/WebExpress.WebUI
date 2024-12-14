//using System;
//using System.Collections.Generic;
//using WebExpress.WebCore.WebMessage;

//namespace WebExpress.WebUI.WebControl
//{
//    public interface IControlForm : IControl
//    {
//        /// <summary>
//        /// Event to validate the input values.
//        /// </summary>
//        event EventHandler<ValidationEventArgs> Validation;

//        /// <summary>
//        /// Event is raised when the form has been initialized.
//        /// </summary>
//        event EventHandler<FormEventArgs> InitializeForm;

//        /// <summary>
//        /// Event is raised when the form's data needs to be determined.
//        /// </summary>
//        event EventHandler<FormEventArgs> FillForm;

//        /// <summary>
//        /// Event is raised when the form is about to be processed.
//        /// </summary>
//        event EventHandler<FormEventArgs> ProcessForm;

//        /// <summary>
//        /// Event is raised when the form is to be processed and the next data is to be loaded.
//        /// </summary>
//        event EventHandler<FormEventArgs> ProcessAndNextForm;

//        /// <summary>
//        /// Returns or sets the name of the form.
//        /// </summary>
//        string Name { get; set; }

//        /// <summary>
//        /// Returns or sets the target uri.
//        /// </summary>
//        string Uri { get; set; }

//        /// <summary>
//        /// Returns or sets the redirect uri.
//        /// </summary>
//        string RedirectUri { get; set; }

//        /// <summary>
//        /// Returns or sets the form items.
//        /// </summary>
//        IEnumerable<ControlFormItem> Items { get; }

//        /// <summary>
//        /// Returns or sets the request method.
//        /// </summary>
//        RequestMethod Method { get; set; }

//        /// <summary>
//        /// Initializes the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        void Initialize(RenderContextForm context);

//        /// <summary>
//        /// Pre-processes the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        void PreProcess(RenderContextForm context);

//        /// <summary>
//        /// Adds form control items to the form.
//        /// </summary>
//        /// <param name="item">The form items.</param>
//        void Add(params ControlFormItem[] item);

//        /// <summary>
//        /// Removes a form control item from the form.
//        /// </summary>
//        /// <param name="formItem">The form item.</param>
//        void Remove(ControlFormItem formItem);

//        /// <summary>
//        /// Validates the input elements for correctness of the data.
//        /// </summary>
//        /// <param name="context">The context in which the inputs are validated.</param>
//        /// <returns>True if all form items are valid, false otherwise.</returns>
//        bool Validate(RenderContextForm context);
//    }
//}
