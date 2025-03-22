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
        private readonly List<IControl> _content = [];

        /// <summary>
        /// Returns the content.
        /// </summary>
        public IEnumerable<IControl> Content => _content;

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
        /// <param name="text">The text.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlModal(string id = null, params IControl[] content)
            : base(id)
        {
            _content.AddRange(content);
        }

        /// <summary> 
        /// Adds one or more controls to the content of the modal.
        /// </summary> 
        /// <param name="controls">The controls to add to the modal.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of 
        /// the modal. It is useful for dynamically constructing the user interface by appending 
        /// various controls to the panel's content. 
        /// Example usage: 
        /// <code> 
        /// var modal = new ControlModal(); 
        /// var text1 = new ControlText { Text = "Save" };
        /// var text2 = new ControlText { Text = "Cancel" };
        /// modal.Add(text1, text2);
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public virtual void Add(params IControl[] controls)
        {
            _content.AddRange(controls);
        }

        /// <summary> 
        /// Adds one or more controls to the content of the modal.
        /// </summary> 
        /// <param name="controls">The controls to add to the v.</param> 
        /// <remarks> 
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of 
        /// the modal. It is useful for dynamically constructing the user interface by appending 
        /// various controls to the panel's content. 
        /// Example usage: 
        /// <code> 
        /// var modal = new ControlModal(); 
        /// var text1 = new ControlText { Text = "Save" };
        /// var text2 = new ControlText { Text = "Cancel" };
        /// modal.Add(new List<IControl>([text1, text2]));
        /// </code> 
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public virtual void Add(IEnumerable<IControl> controls)
        {
            _content.AddRange(controls);
        }

        /// <summary>
        /// Removes a control from the content of the modal.
        /// </summary>
        /// <param name="control">The control to remove from the content.</param>
        /// <remarks>
        /// This method allows removing a specific control from the <see cref="Content"/> collection of 
        /// the modal.
        /// </remarks>
        public virtual void Remove(IControl control)
        {
            _content.Remove(control);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var classes = Classes.ToList();
            classes.Add("modal");

            if (Fade)
            {
                classes.Add("fade");
            }

            var headerText = new HtmlElementSectionH4(I18N.Translate(renderContext.Request, Header))
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

            var body = new HtmlElementTextContentDiv(Content.Select(x => x.Render(renderContext, visualTree)).ToArray())
            {
                Class = "modal-body"
            };

            var footer = default(HtmlElementTextContentDiv);

            var footerButton = new HtmlElementFieldButton(new HtmlText(I18N.Translate(renderContext.Request, "webexpress.webui:modal.close.label")))
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
                visualTree.AddScript(Id + "_shown", shown);
            }

            if (!string.IsNullOrWhiteSpace(OnHiddenCode))
            {
                var hidden = "$('#" + Id + "').on('hidden.bs.modal', function() { " + OnHiddenCode + " });";
                visualTree.AddScript(Id + "_hidden", hidden);
            }

            if (ShowIfCreated)
            {
                var show = "$('#" + Id + "').modal('show');";
                visualTree.AddScript(Id + "_showifcreated", show);
            }

            return html;
        }
    }
}
