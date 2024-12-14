using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a modal control that can display content in a modal dialog.
    /// </summary>
    public class ControlModal : Control
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public IEnumerable<Control> Content { get; private set; } = [];

        /// <summary>
        /// Returns or sets whether the fader effect should be used.
        /// </summary>
        public bool Fade { get; set; } = true;

        /// <summary>
        /// Returns or sets the header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Returns or sets whether the modal should be displayed when the control is loaded or only after the user is prompted.
        /// </summary>
        public bool ShowIfCreated { get; set; }

        /// <summary>
        /// Returns or sets the jquerry code to be executed when the modal dialog is displayed.
        /// </summary>
        public string OnShownCode { get; set; }

        /// <summary>
        /// Returns or sets the jquerry code to be executed when the modal dialog is hidden.
        /// </summary>
        public string OnHiddenCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlModal(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        public ControlModal(string id, string header)
            : this(id)
        {
            Header = header;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id, string header, params Control[] content)
            : this(id, header)
        {
            Content = content ?? [];
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="text">The text.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id = null, params Control[] content)
            : this(id, string.Empty)
        {
            Content = content ?? [];
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var classes = Classes.ToList();
            classes.Add("modal");

            if (Fade)
            {
                classes.Add("fade");
            }

            var headerText = new HtmlElementSectionH4(I18N.Translate(renderContext.Request.Culture, Header))
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

            var body = new HtmlElementTextContentDiv(from x in Content select x.Render(renderContext))
            {
                Class = "modal-body"
            };

            var footer = default(HtmlElementTextContentDiv);

            var footerButton = new HtmlElementFieldButton(new HtmlText(I18N.Translate(renderContext.Request.Culture, "webexpress.webui:modal.close.label")))
            {
                Type = "button",
                Class = Css.Concatenate("btn", new PropertyColorButton(TypeColorButton.Primary).ToStyle())
            };
            footerButton.AddUserAttribute("data-bs-dismiss", "modal");

            footer = new HtmlElementTextContentDiv(footerButton)
            {
                Class = "modal-footer"
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
                renderContext.AddScript(Id + "_shown", shown);
            }

            if (!string.IsNullOrWhiteSpace(OnHiddenCode))
            {
                var hidden = "$('#" + Id + "').on('hidden.bs.modal', function() { " + OnHiddenCode + " });";
                renderContext.AddScript(Id + "_hidden", hidden);
            }

            if (ShowIfCreated)
            {
                var show = "$('#" + Id + "').modal('show');";
                renderContext.AddScript(Id + "_showifcreated", show);
            }

            return html;
        }
    }
}
