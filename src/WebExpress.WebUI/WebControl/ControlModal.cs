using System.Collections.Generic;
using System.Linq;
using WebExpress.Core.WebHtml;
using WebExpress.Core.WebPage;
using static WebExpress.Core.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlModal : Control
    {
        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public List<Control> Content { get; private set; }

        /// <summary>
        /// Returns or sets whether the fader effect should be used.
        /// </summary>
        public bool Fade { get; set; }

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
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlModal(string id)
            : base(!string.IsNullOrWhiteSpace(id) ? id : "modal")
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        public ControlModal(string id, string header)
            : this(id)
        {
            Header = header;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="header">The headline.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id, string header, params Control[] content)
            : this(id, header)
        {
            if (content != null)
            {
                Content.AddRange(content);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="text">The text.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id, string text, IEnumerable<Control> content)
            : this(id, text)
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="text">The text.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id = null, params Control[] content)
            : this(id, string.Empty)
        {
            Content.AddRange(content);
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            //Id = !string.IsNullOrWhiteSpace(Id) ? Id : "modal";
            Content = new List<Control>();
            Fade = true;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var classes = Classes.ToList();
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

            var body = new HtmlElementTextContentDiv(from x in Content select x.Render(context))
            {
                Class = "modal-body"
            };

            var footer = default(HtmlElementTextContentDiv);

            var footerButton = new HtmlElementFieldButton(new HtmlText(I18N(context.Culture, "webexpress.webui:modal.close.label")))
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

            return html;
        }
    }
}
