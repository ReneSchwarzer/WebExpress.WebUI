using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlModalForm : ControlModal
    {
        /// <summary>
        /// Returns the form.
        /// </summary>
        public ControlForm Form { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlModalForm(string id = null)
            : this(id, string.Empty, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        public ControlModalForm(string id, string header)
            : this(id, header, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalForm(string id, params ControlFormItem[] content)
            : this(id, string.Empty, content)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalForm(string id, string header, params ControlFormItem[] content)
            : base("modal_" + id, string.Empty, null)
        {
            Form = content != null ? new ControlForm(id, content) : new ControlForm(id);
            Form.InitializeForm += OnInitializeForm;
            Form.Validated += OnValidatedForm;
            Header = header;
        }

        /// <summary>
        /// Adds a form control.
        /// </summary>
        /// <param name="item">The form item.</param>
        public void Add(params ControlFormItem[] item)
        {
            Form.Add(item);
        }

        /// <summary>
        /// Removes a form control.
        /// </summary>
        /// <param name="item">The form item.</param>
        public void Remove(ControlFormItem item)
        {
            Form.Remove(item);
        }

        /// <summary>
        /// Invoked when the form is initialized.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnInitializeForm(object sender, FormEventArgs e)
        {
            ShowIfCreated = false;
        }

        /// <summary>
        /// Invoked when the form has been validated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnValidatedForm(object sender, ValidationResultEventArgs e)
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
            return Render(context, Form.Items);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The form items.</param>
        /// <returns>The control as html.</returns>
        public virtual IHtmlNode Render(RenderContext context, IEnumerable<ControlFormItem> items)
        {
            var fade = Fade;
            var classes = Classes.ToList();

            var form = Form.Render(context, items) as HtmlElementFormForm;

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

            var submitFooterButton = new ControlFormItemButton();

            var cancelFooterButton = new ControlButtonLink()
            {
                Text = I18N(context.Culture, "webexpress.webui:modal.close.label")
            }.Render(context) as HtmlElement;

            cancelFooterButton.AddUserAttribute("data-bs-dismiss", "modal");

            footer = new HtmlElementTextContentDiv(submitFooterButton.Render(new RenderContextForm(context, Form)), cancelFooterButton)
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
