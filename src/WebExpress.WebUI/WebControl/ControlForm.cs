using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlForm : Control, IControlForm
    {
        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public virtual TypeLayoutForm Layout { get; set; } = TypeLayoutForm.Vertical;

        /// <summary>
        /// Event to validate the input values.
        /// </summary>
        public event EventHandler<ValidationEventArgs> Validation;

        /// <summary>
        /// Event nach Abschluss der Validation
        /// </summary>
        public event EventHandler<ValidationResultEventArgs> Validated;

        /// <summary>
        /// Event is raised when the form has been initialized.
        /// </summary>
        public event EventHandler<FormularEventArgs> InitializeFormular;

        /// <summary>
        /// Event is raised when the form's data needs to be determined.
        /// </summary>
        public event EventHandler<FormularEventArgs> FillFormular;

        /// <summary>
        /// Event is raised when the form is about to be processed.
        /// </summary>
        public event EventHandler<FormularEventArgs> ProcessFormular;

        /// <summary>
        /// Event is raised when the form is to be processed and the next data is to be loaded.
        /// </summary>
        public event EventHandler<FormularEventArgs> ProcessAndNextFormular;

        /// <summary>
        /// Returns or sets the name of the form.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns or sets the target uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Returns or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Returns or sets the hidden field that contains the id.
        /// </summary>
        public ControlFormItemInputHidden FormularId { get; } = new ControlFormItemInputHidden(Guid.NewGuid().ToString())
        {
            Name = "formular-id"
        };

        /// <summary>
        /// Returns or sets the hidden field that contains the submit method.
        /// </summary>
        public ControlFormItemInputHidden SubmitType { get; } = new ControlFormItemInputHidden(Guid.NewGuid().ToString())
        {
            Name = "formular-submit-type",
            Value = "update"
        };

        /// <summary>
        /// Returns or sets the submit button.
        /// </summary>
        public ControlFormItemButton SubmitButton { get; } = new ControlFormItemButton()
        {
            Icon = new PropertyIcon(TypeIcon.Save),
            Color = new PropertyColorButton(TypeColorButton.Success),
            Type = TypeButton.Submit,
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None),
        };

        /// <summary>
        /// Returns or sets the request method.
        /// </summary>
        public RequestMethod Method { get; set; } = RequestMethod.POST;

        /// <summary>
        /// Returns the form items.
        /// </summary>
        protected List<ControlFormItem> _Items { get; } = new List<ControlFormItem>();

        /// <summary>
        /// Returns the form items.
        /// </summary>
        public IEnumerable<ControlFormItem> Items => _Items;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlForm(string id = null)
            : base(id)
        {
            SubmitButton.Name = SubmitButton.Id;
            SubmitButton.OnClick = new PropertyOnClick($"$('#{SubmitType.Id}').val('submit');");
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The controls that are associated with the form.</param>
        public ControlForm(string id, params ControlFormItem[] items)
            : this(id)
        {
            _Items.AddRange(items);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The controls that are associated with the form.</param>
        public ControlForm(params ControlFormItem[] items)
            : this(null, items)
        {
        }

        /// <summary>
        /// Initializes the form.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public virtual void Initialize(RenderContextFormular context)
        {
            // Id überprüfen
            if (string.IsNullOrWhiteSpace(Id))
            {
                context.Host.Log.Warning(I18N("webexpress.webui:form.empty.id"));
            }

            FormularId.Value = Id;

            if (string.IsNullOrWhiteSpace(SubmitButton.Text))
            {
                SubmitButton.Text = context.I18N("webexpress.webui", "form.submit.label");
            }
            else
            {
                SubmitButton.Text = context.I18N(SubmitButton.Text);
            }
        }

        /// <summary>
        /// Filling the form.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public virtual void Fill(RenderContextFormular context)
        {
            OnFill(context);
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="context">The context in which the inputs are validated.</param>
        /// <returns>True if all form items are valid, false otherwise.</returns>
        public virtual bool Validate(RenderContextFormular context)
        {
            var valid = true;
            var validationResults = context.ValidationResults as List<ValidationResult>;

            foreach (var v in Items.Where(x => x is IFormularValidation).Select(x => x as IFormularValidation))
            {
                v.Validate(context);

                if (v.ValidationResult == TypesInputValidity.Error)
                {
                    valid = false;
                }

                validationResults.AddRange(v.ValidationResults);
            }

            var args = new ValidationEventArgs() { Value = null, Context = context };
            OnValidation(args);

            validationResults.AddRange(args.Results);

            if (args.Results.Where(x => x.Type == TypesInputValidity.Error).Any())
            {
                valid = false;
            }

            var validatedArgs = new ValidationResultEventArgs(valid);
            validatedArgs.Results.AddRange(validationResults);

            OnValidated(validatedArgs);

            return valid;
        }

        /// <summary>
        /// Instructs to reload the initial formular data.
        /// </summary>
        public void Reset()
        {
            Fill(null);
        }

        /// <summary>
        /// Pre-processing of the form.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public virtual void PreProcess(RenderContextFormular context)
        {

        }

        /// <summary>
        /// Processing of the resource. des Formulars
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public virtual void Process(RenderContextFormular context)
        {
            OnProcess(context);

            if (!string.IsNullOrWhiteSpace(RedirectUri?.ToString()))
            {
                context.Page.Redirecting(RedirectUri);
            }
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return Render(context, Items);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The formular items.</param>
        /// <returns>The control as html.</returns>
        public virtual IHtmlNode Render(RenderContext context, IEnumerable<ControlFormItem> items)
        {
            var renderContext = new RenderContextFormular(context, this);
            var fill = false;
            var process = false;

            // check if and how the form was submitted
            if (context.Request.GetParameter("formular-id")?.Value == Id && context.Request.HasParameter("formular-submit-type"))
            {
                var value = context.Request.GetParameter("formular-submit-type")?.Value;
                switch (value)
                {
                    case "submit":
                        process = true;
                        fill = false;
                        break;
                    case "reset":
                        process = false;
                        fill = true;
                        break;
                    case "update":
                    default:
                        break;
                }
            }
            else
            {
                // first call
                fill = true;
                process = false;
            }

            // initialization
            Initialize(renderContext);
            foreach (var item in items)
            {
                item.Initialize(renderContext);
            }
            OnInitialize(renderContext);
            SubmitButton.Initialize(renderContext);

            // fill the form with data
            if (fill)
            {
                Fill(renderContext);
            }

            // preprocessing
            PreProcess(renderContext);

            // process form (e.g. save form data)
            if (process && Validate(renderContext))
            {
                Process(renderContext);
            }

            // generate html
            var button = SubmitButton.Render(renderContext);

            var form = new HtmlElementFormForm()
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role,
                Action = Uri?.ToString() ?? renderContext.Uri?.ToString(),
                Method = Method.ToString(),
                Enctype = TypeEnctype.None
            };

            form.Elements.Add(FormularId.Render(renderContext));
            form.Elements.Add(SubmitType.Render(renderContext));
            var header = new HtmlElementSectionHeader();
            header.Elements.Add(new ControlProgressBar()
            {
                Format = TypeFormatProgress.Animated,
                Color = new PropertyColorProgress(TypeColorProgress.Success),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Three),
                Styles = { "height: 3px;", "display: none;" },
                Value = 0
            }.Render(renderContext));

            foreach (var v in renderContext.ValidationResults)
            {
                var bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Default);

                switch (v.Type)
                {
                    case TypesInputValidity.Error:
                        bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Danger);
                        break;
                    case TypesInputValidity.Warning:
                        bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Warning);
                        break;
                }

                header.Elements.Add(new ControlAlert()
                {
                    BackgroundColor = bgColor,
                    Text = I18N(context.Culture, v.Text),
                    Dismissible = TypeDismissibleAlert.Dismissible,
                    Fade = TypeFade.FadeShow
                }.Render(renderContext));
            }

            foreach (var item in items.Where(x => x is ControlFormItemInputHidden))
            {
                form.Elements.Add(item.Render(renderContext));
            }

            var main = new HtmlElementSectionMain();

            var group = default(ControlFormItemGroup);

            group = Layout switch
            {
                TypeLayoutForm.Horizontal => new ControlFormItemGroupHorizontal(),
                TypeLayoutForm.Mix => new ControlFormItemGroupMix(),
                _ => new ControlFormItemGroupVertical(),
            };

            foreach (var item in items.Where(x => x is not ControlFormItemInputHidden))
            {
                group.Items.Add(item);
            }

            main.Elements.Add(group.Render(renderContext));

            var footer = new HtmlElementSectionFooter();

            footer.Elements.Add(button);
            form.Elements.Add(header);
            form.Elements.Add(main);
            form.Elements.Add(footer);

            form.Elements.AddRange(renderContext.Scripts.Select(x => new HtmlElementScriptingScript(x.Value)));

            context.VisualTree.AddScript(Id, $"new webexpress.webui.form.progess('{Id}', '{Method.ToString()}');");

            return form;
        }

        /// <summary>
        /// Adds a form control.
        /// </summary>
        /// <param name="item">The form item.</param>
        public void Add(params ControlFormItem[] item)
        {
            _Items.AddRange(item);
        }

        /// <summary>
        /// Removes a form control item from the form.
        /// </summary>
        /// <param name="formItem">The form item.</param>
        public void Remove(ControlFormItem formItem)
        {
            _Items.Remove(formItem);
        }

        /// <summary>
        /// Raises the process event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnProcess(RenderContextFormular context)
        {
            ProcessFormular?.Invoke(this, new FormularEventArgs() { Context = context });
        }

        /// <summary>
        /// Raises the process event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnProcessAndNextFormular(RenderContextFormular context)
        {
            ProcessAndNextFormular?.Invoke(this, new FormularEventArgs() { Context = context });
        }

        /// <summary>
        /// Raises the Initializations event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnInitialize(RenderContextFormular context)
        {
            InitializeFormular?.Invoke(this, new FormularEventArgs() { Context = context });
        }

        /// <summary>
        /// Raises the data delivery event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnFill(RenderContextFormular context)
        {
            FillFormular?.Invoke(this, new FormularEventArgs() { Context = context });
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
        /// Raises the Validated event.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnValidated(ValidationResultEventArgs e)
        {
            Validated?.Invoke(this, e);
        }
    }
}
