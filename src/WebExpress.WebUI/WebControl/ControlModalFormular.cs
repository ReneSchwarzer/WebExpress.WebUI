﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlModalFormular : ControlModal
    {
        /// <summary>
        /// Returns the form
        /// </summary>
        public ControlForm Formular { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlModalFormular(string id = null)
            : this(id, string.Empty, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        public ControlModalFormular(string id, string header)
            : this(id, header, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalFormular(string id, params ControlFormItem[] content)
            : this(id, string.Empty, content)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalFormular(string id, string header, params ControlFormItem[] content)
            : base("modal_" + id, string.Empty, null)
        {
            Formular = content != null ? new ControlForm(id, content) : new ControlForm(id);
            Formular.InitializeFormular += OnInitializeFormular;
            Formular.Validated += OnValidatedFormular;
            Header = header;
        }

        /// <summary>
        /// Adds a form control.
        /// </summary>
        /// <param name="item">The form item.</param>
        public void Add(params ControlFormItem[] item)
        {
            Formular.Add(item);
        }

        /// <summary>
        /// Removes a form control.
        /// </summary>
        /// <param name="item">The form item.</param>
        public void Remove(ControlFormItem item)
        {
            Formular.Remove(item);
        }

        /// <summary>
        /// Invoked when the form is initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnInitializeFormular(object sender, FormularEventArgs e)
        {
            ShowIfCreated = false;
        }

        /// <summary>
        /// Invoked when the form has been validated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnValidatedFormular(object sender, ValidationResultEventArgs e)
        {
            if (!e.Valid)
            {
                ShowIfCreated = true;
                Fade = false;
            }
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return Render(context, Formular.Items);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The formular items.</param>
        /// <returns>The control as html.</returns>
        public virtual IHtmlNode Render(RenderContext context, IEnumerable<ControlFormItem> items)
        {
            var fade = Fade;
            var classes = Classes.ToList();

            var form = Formular.Render(context, items) as HtmlElementFormForm;

            classes.Add("modal");

            if (Fade)
            {
                classes.Add("fade");
            }

            var headerText = new HtmlElementSectionH4(I18N(context.Culture, Header))
            {
                Class = "modal-title"
            };

            var headerButton = new HtmlElementFieldButton()
            {
                Class = "btn-close"
            };
            headerButton.AddUserAttribute("aria-label", "close");
            headerButton.AddUserAttribute("data-bs-dismiss", "modal");

            var header = new HtmlElementTextContentDiv(headerText, headerButton)
            {
                Class = "modal-header"
            };

            var formElements = form.Elements.Where(x => !(x is HtmlElementSectionFooter));

            var body = new HtmlElementTextContentDiv(formElements)
            {
                Class = "modal-body"
            };

            var footer = default(HtmlElementTextContentDiv);

            var submitFooterButton = new ControlFormItemButton()
            {
                Name = "submit_" + Formular?.Id?.ToLower(),
                Text = Formular.SubmitButton.Text,
                Icon = Formular.SubmitButton.Icon,
                Color = Formular.SubmitButton.Color,
                Type = TypeButton.Submit,
                Value = "1",
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None),
                OnClick = new PropertyOnClick($"$('#{Formular?.SubmitType.Id}').val('submit');")
            };

            var cancelFooterButton = new ControlButtonLink()
            {
                Text = I18N(context.Culture, "webexpress.webui:modal.close.label")
            }.Render(context) as HtmlElement;

            cancelFooterButton.AddUserAttribute("data-bs-dismiss", "modal");

            footer = new HtmlElementTextContentDiv(submitFooterButton.Render(new RenderContextFormular(context, Formular)), cancelFooterButton)
            {
                Class = "modal-footer d-flex justify-content-between"
            };

            var content = new HtmlElementTextContentDiv(header, body, footer)
            {
                Class = "modal-content"
            };

            var dialog = new HtmlElementTextContentDiv(content)
            {
                Class = "modal-dialog",
                Role = "document"
            };

            var html = new HtmlElementTextContentDiv(dialog)
            {
                Id = Id,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = "dialog"
            };

            if (!string.IsNullOrWhiteSpace(OnShownCode))
            {
                var shown = "$('#" + Id + "').on('shown.bs.modal', function(e) { " + OnShownCode + " });";
                context.VisualTree.AddScript(Id + "_shown", shown);
            }

            if (!string.IsNullOrWhiteSpace(OnHiddenCode))
            {
                var hidden = "$('#" + Id + "').on('hidden.bs.modal', function() { " + OnHiddenCode + " });";
                context.VisualTree.AddScript(Id + "_hidden", hidden);
            }

            if (ShowIfCreated)
            {
                var show = "$('#" + Id + "').modal('show');";
                context.VisualTree.AddScript(Id + "_showifcreated", show);
            }

            form.Elements.Clear();
            form.Elements.Add(html);

            Fade = fade;

            return form;
        }
    }
}
