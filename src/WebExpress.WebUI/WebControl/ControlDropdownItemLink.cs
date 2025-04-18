﻿using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a dropdown item link control.
    /// </summary>
    public class ControlDropdownItemLink : ControlLink, IControlDropdownItem
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlDropdownItemLink(string id = null, params IControl[] content)
            : base(id, content)
        {
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var param = ""; // GetParams(context?.Page);

            var html = new HtmlElementTextSemanticsA([.. Controls.Select(x => x.Render(renderContext, visualTree))])
            {
                Id = Id,
                Class = Css.Concatenate("link", GetClasses()),
                Style = GetStyles(),
                Role = Role,
                Href = Uri?.ToString() + (param.Length > 0 ? "?" + param : string.Empty),
                Target = Target,
                Title = string.IsNullOrEmpty(Title) ? I18N.Translate(renderContext.Request, Tooltip) : I18N.Translate(renderContext.Request, Title),
                OnClick = OnClick?.ToString()
            };

            if (Icon != null)
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
                    ) : new PropertySpacingMargin(PropertySpacing.Space.None)
                }.Render(renderContext, visualTree));
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                html.Add(new HtmlText(I18N.Translate(renderContext.Request, Text)));
            }

            if (Modal == null || Modal.Type == TypeModal.None)
            {

            }
            else if (Modal.Type == TypeModal.Form)
            {
                html.OnClick = $"new webexpress.webui.modalFormCtrl({{ close: '{I18N.Translate(renderContext.Request, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                html.Href = "#";
            }
            else if (Modal.Type == TypeModal.Brwoser)
            {
                html.OnClick = $"new webexpress.webui.modalPageCtrl({{ close: '{I18N.Translate(renderContext.Request, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                html.Href = "#";
            }
            else if (Modal.Type == TypeModal.Modal)
            {
                html.AddUserAttribute("data-bs-toggle", "modal");
                html.AddUserAttribute("data-bs-target", "#" + Modal.Modal.Id);
            }

            if (!string.IsNullOrWhiteSpace(Tooltip))
            {
                html.AddUserAttribute("data-bs-toggle", "tooltip");
            }

            return html;
        }
    }
}
