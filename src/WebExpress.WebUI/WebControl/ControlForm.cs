//using System;
//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebFragment;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebMessage;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebCore.WebScope;

//namespace WebExpress.WebUI.WebControl
//{
//    /// <summary>
//    /// Represents a form with various input fields and controls.
//    /// </summary>
//    public class ControlForm : Control, IControlForm, IScope
//    {
//        private readonly List<ControlFormItem> _items = [];
//        private readonly List<ControlFormItemButton> _preferencesButtons = [];
//        private readonly List<ControlFormItemButton> _primaryButtons = [];
//        private readonly List<ControlFormItemButton> _secondaryButtons = [];
//        private readonly List<ControlFormItem> _preferencesControls = [];
//        private readonly List<ControlFormItem> _primaryControls = [];
//        private readonly List<ControlFormItem> _secondaryControls = [];

//        /// <summary>
//        /// Event to validate the input values.
//        /// </summary>
//        public event EventHandler<ValidationEventArgs> Validation;

//        /// <summary>
//        /// Event nach Abschluss der Validation
//        /// </summary>
//        public event EventHandler<ValidationResultEventArgs> Validated;

//        /// <summary>
//        /// Event is raised when the form has been initialized.
//        /// </summary>
//        public event EventHandler<FormEventArgs> InitializeForm;

//        /// <summary>
//        /// Event is raised when the form's data needs to be determined.
//        /// </summary>
//        public event EventHandler<FormEventArgs> FillForm;

//        /// <summary>
//        /// Event is raised when the form is about to be processed.
//        /// </summary>
//        public event EventHandler<FormEventArgs> ProcessForm;

//        /// <summary>
//        /// Event is raised when the form is to be processed and the next data is to be loaded.
//        /// </summary>
//        public event EventHandler<FormEventArgs> ProcessAndNextForm;

//        /// <summary>
//        /// Returns or sets the name of the form.
//        /// </summary>
//        public string Name { get; set; }

//        /// <summary>
//        /// Returns or sets the target uri.
//        /// </summary>
//        public string Uri { get; set; }

//        /// <summary>
//        /// Returns or sets the redirect uri.
//        /// </summary>
//        public string RedirectUri { get; set; }

//        /// <summary>
//        /// Returns or sets the form layout.
//        /// </summary>
//        public virtual TypeLayoutForm FormLayout { get; set; } = TypeLayoutForm.Default;

//        /// <summary>
//        /// Returns or sets the item layout.
//        /// </summary>
//        public virtual TypeLayoutFormItem ItemLayout { get; set; } = TypeLayoutFormItem.Vertical;

//        /// <summary>
//        /// Returns or sets the hidden field that contains the id.
//        /// </summary>
//        public ControlFormItemInputHidden FormId { get; } = new ControlFormItemInputHidden(Guid.NewGuid().ToString())
//        {
//            Name = "form-id"
//        };

//        /// <summary>
//        /// Returns or sets the hidden field that contains the submit method.
//        /// </summary>
//        public ControlFormItemInputHidden SubmitType { get; } = new ControlFormItemInputHidden(Guid.NewGuid().ToString())
//        {
//            Name = "form-submit-type",
//            Value = "update"
//        };

//        /// <summary>
//        /// Returns or sets the request method.
//        /// </summary>
//        public RequestMethod Method { get; set; } = RequestMethod.POST;

//        /// <summary>
//        /// Returns or sets the header preferences section.
//        /// </summary>
//        protected List<IFragmentContext> HeaderPreferences { get; } = [];

//        /// <summary>
//        /// Returns or sets the header primary section.
//        /// </summary>
//        protected List<IFragmentContext> HeaderPrimary { get; } = [];

//        /// <summary>
//        /// Returns or sets the header secondary section.
//        /// </summary>
//        protected List<IFragmentContext> HeaderSecondary { get; } = [];

//        /// <summary>
//        /// Returns or sets the button panel preferences section.
//        /// </summary>
//        protected List<IFragmentContext> ButtonPanelPreferences { get; } = [];

//        /// <summary>
//        /// Returns or sets the button panel primary section.
//        /// </summary>
//        protected List<IFragmentContext> ButtonPanelPrimary { get; } = [];

//        /// <summary>
//        /// Returns or sets the button panel secondary section.
//        /// </summary>
//        protected List<IFragmentContext> ButtonPanelSecondary { get; } = [];

//        /// <summary>
//        /// Returns or sets the footer preferences section.
//        /// </summary>
//        protected List<IFragmentContext> FooterPreferences { get; } = [];

//        /// <summary>
//        /// Returns or sets the footer primary section.
//        /// </summary>
//        protected List<IFragmentContext> FooterPrimary { get; } = [];

//        /// <summary>
//        /// Returns or sets the footer secondary section.
//        /// </summary>
//        protected List<IFragmentContext> FooterSecondary { get; } = [];

//        /// <summary>
//        /// Returns the form items.
//        /// </summary>
//        public IEnumerable<ControlFormItem> Items => _items;

//        /// <summary>
//        /// Returns the form buttons.
//        /// </summary>
//        public IEnumerable<ControlFormItemButton> Buttons => _preferencesButtons.Union(_primaryButtons).Union(_secondaryButtons);

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlForm(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        /// <param name="items">The controls that are associated with the form.</param>
//        public ControlForm(string id, params ControlFormItem[] items)
//            : this(id)
//        {
//            _items.AddRange(items);
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="items">The controls that are associated with the form.</param>
//        public ControlForm(params ControlFormItem[] items)
//            : this(null, items)
//        {
//        }

//        /// <summary>
//        /// Initializes the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public virtual void Initialize(RenderContextForm context)
//        {
//            //var fm = ComponentHub.GetComponent<FragmentManager>();

//            //// check id 
//            //if (string.IsNullOrWhiteSpace(Id))
//            //{
//            //    context.ApplicationContext?.PluginContext.Host.Log.Warning(I18N.Translate("webexpress.webui:form.empty.id"));
//            //}

//            //FormId.Value = Id;

//            //// header
//            //HeaderPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.HeaderPreferences, context.Page, [GetType().FullName]));
//            //HeaderPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.HeaderPrimary, context.Page, [GetType().FullName]));
//            //HeaderSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.HeaderSecondary, context.Page, [GetType().FullName]));

//            //// footer
//            //FooterPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.FooterPreferences, context.Page, [GetType().FullName]));
//            //FooterPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.FooterPrimary, context.Page, [GetType().FullName]));
//            //FooterSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionControl.FooterSecondary, context.Page, [GetType().FullName]));
//        }

//        /// <summary>
//        /// Filling the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public virtual void Fill(RenderContextForm context)
//        {
//            OnFill(context);
//        }

//        /// <summary>
//        /// Checks the input element for correctness of the data.
//        /// </summary>
//        /// <param name="context">The context in which the inputs are validated.</param>
//        /// <returns>True if all form items are valid, false otherwise.</returns>
//        public virtual bool Validate(RenderContextForm context)
//        {
//            var valid = true;
//            var validationResults = context.ValidationResults as List<ValidationResult>;

//            foreach (var v in Items.Where(x => x is IFormValidation).Select(x => x as IFormValidation))
//            {
//                v.Validate(context);

//                if (v.ValidationResult == TypesInputValidity.Error)
//                {
//                    valid = false;
//                }

//                validationResults.AddRange(v.ValidationResults);
//            }

//            var args = new ValidationEventArgs() { Value = null, Context = context };
//            OnValidation(args);

//            validationResults.AddRange(args.Results);

//            if (args.Results.Where(x => x.Type == TypesInputValidity.Error).Any())
//            {
//                valid = false;
//            }

//            var validatedArgs = new ValidationResultEventArgs(valid);
//            validatedArgs.Results.AddRange(validationResults);

//            OnValidated(validatedArgs);

//            return valid;
//        }

//        /// <summary>
//        /// Instructs to reload the initial form data.
//        /// </summary>
//        public void Reset()
//        {
//            Fill(null);
//        }

//        /// <summary>
//        /// Pre-processing of the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public virtual void PreProcess(RenderContextForm context)
//        {

//        }

//        /// <summary>
//        /// Processing of the form. 
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public virtual void Process(RenderContextForm context)
//        {
//            //OnProcess(context);

//            //if (!string.IsNullOrWhiteSpace(RedirectUri?.ToString()))
//            //{
//            //    context.Page.Redirecting(RedirectUri);
//            //}
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            return Render(context, Items);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <param name="items">The form items.</param>
//        /// <returns>The control as html.</returns>
//        public virtual IHtmlNode Render(IRenderContext context, IEnumerable<ControlFormItem> items)
//        {
//            var renderContext = new RenderContextForm(context, this);
//            var fill = false;
//            var process = false;

//            // check if and how the form was submitted
//            if (context.Request.GetParameter("form-id")?.Value == Id && context.Request.HasParameter("form-submit-type"))
//            {
//                var value = context.Request.GetParameter("form-submit-type")?.Value;
//                switch (value)
//                {
//                    case "submit":
//                        process = true;
//                        fill = false;
//                        break;
//                    case "reset":
//                        process = false;
//                        fill = true;
//                        break;
//                    case "update":
//                    default:
//                        break;
//                }
//            }
//            else
//            {
//                // first call
//                fill = true;
//                process = false;
//            }

//            // initialization
//            Initialize(renderContext);
//            foreach (var item in items)
//            {
//                item.Initialize(renderContext);
//            }
//            foreach (var item in Buttons)
//            {
//                item.Initialize(renderContext);
//            }
//            OnInitialize(renderContext);

//            // fill the form with data
//            if (fill)
//            {
//                Fill(renderContext);
//            }

//            // preprocessing
//            PreProcess(renderContext);

//            // process form (e.g. save form data)
//            if (process && Validate(renderContext))
//            {
//                Process(renderContext);
//            }

//            // generate html
//            var form = new HtmlElementFormForm()
//            {
//                Id = Id,
//                Class = FormLayout == TypeLayoutForm.Inline ? Css.Concatenate("form-inline", GetClasses()) : GetClasses(),
//                Style = GetStyles(),
//                Role = Role,
//                Action = Uri?.ToString() ?? renderContext.Uri?.ToString(),
//                Method = Method.ToString(),
//                Enctype = TypeEnctype.None
//            };

//            form.Elements.Add(FormId.Render(renderContext));
//            form.Elements.Add(SubmitType.Render(renderContext));
//            var header = new HtmlElementSectionHeader();
//            header.Elements.Add(new ControlProgressBar()
//            {
//                Format = TypeFormatProgress.Animated,
//                Color = new PropertyColorProgress(TypeColorProgress.Success),
//                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Three),
//                Styles = { "height: 3px;", "display: none;" },
//                Value = 0
//            }.Render(renderContext));

//            //header.Elements.AddRange(HeaderPreferences.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));
//            //header.Elements.AddRange(HeaderPrimary.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));
//            //header.Elements.AddRange(HeaderSecondary.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));

//            foreach (var v in renderContext.ValidationResults)
//            {
//                var bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Default);

//                switch (v.Type)
//                {
//                    case TypesInputValidity.Error:
//                        bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Danger);
//                        break;
//                    case TypesInputValidity.Warning:
//                        bgColor = new PropertyColorBackgroundAlert(TypeColorBackground.Warning);
//                        break;
//                }

//                header.Elements.Add(new ControlAlert()
//                {
//                    BackgroundColor = bgColor,
//                    Text = I18N.Translate(v.Text),
//                    Dismissible = TypeDismissibleAlert.Dismissible,
//                    Fade = TypeFade.FadeShow
//                }.Render(renderContext));
//            }

//            foreach (var item in items.Where(x => x is ControlFormItemInputHidden))
//            {
//                form.Elements.Add(item.Render(renderContext));
//            }

//            var main = new HtmlElementSectionMain();

//            var group = default(ControlFormItemGroup);

//            group = ItemLayout switch
//            {
//                TypeLayoutFormItem.Horizontal => new ControlFormItemGroupHorizontal(),
//                TypeLayoutFormItem.Mix => new ControlFormItemGroupMix(),
//                _ => new ControlFormItemGroupVertical(),
//            };

//            foreach (var item in items.Where(x => x is not ControlFormItemInputHidden))
//            {
//                group.Items.Add(item);
//            }

//            main.Elements.Add(group.Render(renderContext));

//            var buttonPannel = new HtmlElementTextContentDiv();
//            buttonPannel.Elements.AddRange(Buttons.Select(x => x.Render(renderContext)));

//            var footer = new HtmlElementSectionFooter();
//            //footer.Elements.AddRange(FooterPreferences.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));

//            //footer.Elements.AddRange(FooterPrimary.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));
//            //footer.Elements.AddRange(FooterSecondary.SelectMany(x => x.CreateInstance<IControl>(context.Page, context.Request)).Select(x => x.Render(context)));

//            form.Elements.Add(header);
//            form.Elements.Add(main);
//            form.Elements.Add(buttonPannel);
//            form.Elements.Add(footer);

//            form.Elements.AddRange(renderContext.Scripts.Select(x => new HtmlElementScriptingScript(x.Value)));

//            context.VisualTree.AddScript(Id, $"new webexpress.webui.form.progess('{Id}', '{Method.ToString()}');");

//            return form;
//        }

//        /// <summary>
//        /// Adds a form control.
//        /// </summary>
//        /// <param name="item">The form item.</param>
//        public void Add(params ControlFormItem[] item)
//        {
//            _items.AddRange(item);
//        }

//        /// <summary>
//        /// Adds a preferences control.
//        /// </summary>
//        /// <param name="controls">The controls.</param>
//        public void AddPreferencesControl(params ControlFormItem[] controls)
//        {
//            _preferencesControls.AddRange(controls);
//        }

//        /// <summary>
//        /// Adds a preferences form control button.
//        /// </summary>
//        /// <param name="button">The form buttons.</param>
//        public void AddPreferencesButton(params ControlFormItemButton[] buttons)
//        {
//            _preferencesButtons.AddRange(buttons);
//        }

//        /// <summary>
//        /// Adds a primary control.
//        /// </summary>
//        /// <param name="controls">The controls.</param>
//        public void AddPrimaryControl(params ControlFormItem[] controls)
//        {
//            _primaryControls.AddRange(controls);
//        }

//        /// <summary>
//        /// Adds a primary form control button.
//        /// </summary>
//        /// <param name="button">The form buttons.</param>
//        public void AddPrimaryButton(params ControlFormItemButton[] buttons)
//        {
//            _primaryButtons.AddRange(buttons);
//        }

//        /// <summary>
//        /// Adds a secondary control.
//        /// </summary>
//        /// <param name="controls">The controls.</param>
//        public void AddSecondaryControl(params ControlFormItem[] controls)
//        {
//            _secondaryControls.AddRange(controls);
//        }

//        /// <summary>
//        /// Adds a secondary form control button.
//        /// </summary>
//        /// <param name="button">The form buttons.</param>
//        public void AddSecondaryButton(params ControlFormItemButton[] buttons)
//        {
//            _secondaryButtons.AddRange(buttons);
//        }

//        /// <summary>
//        /// Removes a form control item from the form.
//        /// </summary>
//        /// <param name="formItem">The form item.</param>
//        public void Remove(ControlFormItem formItem)
//        {
//            _items.Remove(formItem);
//        }

//        /// <summary>
//        /// Removes a form control button from the form.
//        /// </summary>
//        /// <param name="button">The form button.</param>
//        public void RemoveButton(ControlFormItemButton button)
//        {
//            _preferencesButtons.Remove(button);
//            _primaryButtons.Remove(button);
//            _secondaryButtons.Remove(button);
//        }

//        /// <summary>
//        /// Raises the process event.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        protected virtual void OnProcess(RenderContextForm context)
//        {
//            ProcessForm?.Invoke(this, new FormEventArgs() { Context = context });
//        }

//        /// <summary>
//        /// Raises the process event.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        protected virtual void OnProcessAndNextForm(RenderContextForm context)
//        {
//            ProcessAndNextForm?.Invoke(this, new FormEventArgs() { Context = context });
//        }

//        /// <summary>
//        /// Raises the Initializations event.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        protected virtual void OnInitialize(RenderContextForm context)
//        {
//            InitializeForm?.Invoke(this, new FormEventArgs() { Context = context });
//        }

//        /// <summary>
//        /// Raises the data delivery event.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        protected virtual void OnFill(RenderContextForm context)
//        {
//            FillForm?.Invoke(this, new FormEventArgs() { Context = context });
//        }

//        /// <summary>
//        /// Raises the validation event.
//        /// </summary>
//        /// <param name="e">The event argument.</param>
//        protected virtual void OnValidation(ValidationEventArgs e)
//        {
//            Validation?.Invoke(this, e);
//        }

//        /// <summary>
//        /// Raises the Validated event.
//        /// </summary>
//        /// <param name="e">The event argument.</param>
//        protected virtual void OnValidated(ValidationResultEventArgs e)
//        {
//            Validated?.Invoke(this, e);
//        }
//    }
//}
