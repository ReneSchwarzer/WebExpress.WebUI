using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a link button control.
    /// </summary>
    public class ControlButtonLink : ControlButton
    {
        /// <summary>
        /// Returns or sets the target uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Returns or sets the tooltip.
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The child controls to be added to the button.</param>
        public ControlButtonLink(string id = null, params IControl[] content)
            : base(id, content)
        {
            Classes.Add("btn");
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var text = I18N.Translate(Text);

            var html = new HtmlElementTextSemanticsA()
            {
                Id = Id,
                Class = GetClasses(),
                Style = GetStyles(),
                Role = Role,
                Href = Uri?.ToString(),
                Title = Tooltip,
                OnClick = OnClick?.ToString()
            };

            if (Icon != null && Icon.HasIcon)
            {
                html.Add(new ControlIcon()
                {
                    Icon = Icon,
                    Margin = !string.IsNullOrWhiteSpace(Text) ? new PropertySpacingMargin
                    (
                        PropertySpacing.Space.None,
                        PropertySpacing.Space.Two,
                        PropertySpacing.Space.None,
                        PropertySpacing.Space.None
                    ) : new PropertySpacingMargin(PropertySpacing.Space.None),
                    VerticalAlignment = Icon.IsUserIcon ? TypeVerticalAlignment.TextBottom : TypeVerticalAlignment.Default
                }.Render(renderContext));
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                html.Add(new HtmlText(text));
            }

            if (Content.Any())
            {
                html.Add(Content.Select(x => x.Render(renderContext)).ToArray());
            }

            if (Modal == null || Modal.Type == TypeModal.None)
            {

            }
            else if (Modal.Type == TypeModal.Form)
            {
                html.OnClick = $"new webexpress.webui.modalFormCtrl({{ close: '{I18N.Translate(renderContext.Request.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                html.Href = "#";
            }
            else if (Modal.Type == TypeModal.Brwoser)
            {
                html.OnClick = $"new webexpress.webui.modalPageCtrl({{ close: '{I18N.Translate(renderContext.Request.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                html.Href = "#";
            }
            else if (Modal.Type == TypeModal.Modal)
            {
                html.AddUserAttribute("data-bs-toggle", "modal");
                html.AddUserAttribute("data-bs-target", "#" + Modal.Modal.Id);

                return new HtmlList(html, Modal.Modal.Render(renderContext));
            }

            if (!string.IsNullOrWhiteSpace(Tooltip))
            {
                html.AddUserAttribute("data-bs-toggle", "tooltip");
            }

            return html;
        }
    }
}
