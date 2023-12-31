﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlSplitButtonLink : ControlSplitButton
    {
        /// <summary>
        /// Returns or sets the target.
        /// </summary>
        public TypeTarget Target { get; set; }

        /// <summary>
        /// Returns or sets the uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlSplitButtonLink(string id)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlSplitButtonLink(string id, params IControlSplitButtonItem[] content)
            : base(id)
        {
            Items.AddRange(content);

            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="content">The content of the html element.</param>
        public ControlSplitButtonLink(params IControlSplitButtonItem[] content)
            : base(id: null)
        {
            Items.AddRange(content);

            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlSplitButtonLink(string id, IEnumerable<IControlSplitButtonItem> content)
            : base(id)
        {
            Items.AddRange(content);

            Init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlSplitButtonLink(IEnumerable<IControlSplitButtonItem> content)
            : base(id: null)
        {
            Items.AddRange(content);

            Init();
        }

        /// <summary>
        /// Fügt ein neues Item hinzu
        /// </summary>
        /// <param name="item"></param>
        public void Add(IControlSplitButtonItem item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Fügt ein neuen Seterator hinzu
        /// </summary>
        public void AddSeperator()
        {
            Items.Add(null);
        }

        /// <summary>
        /// Fügt ein neuen Kopf hinzu
        /// </summary>
        /// <param name="text">Der Überschriftstext</param>
        public void AddHeader(string text)
        {
            Items.Add(new ControlSplitButtonItemHeader() { Text = text });
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Size = TypeSizeButton.Default;
            Role = "button";
        }

        /// <summary>
        /// Fügt Einträge hinzu
        /// </summary>
        /// <param name="item">The entries. welcher hinzugefügt werden sollen</param>
        public void Add(params IControlSplitButtonItem[] item)
        {
            Items.AddRange(item);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var button = new HtmlElementTextSemanticsA()
            {
                Id = string.IsNullOrWhiteSpace(Id) ? "" : Id + "_btn",
                Class = Css.Concatenate("btn", Css.Remove(GetClasses(), Margin.ToClass())),
                Style = GetStyles(),
                Target = Target,
                Href = Uri?.ToString(),
                OnClick = OnClick?.ToString()
            };

            if (Icon != null && Icon.HasIcon)
            {
                button.Elements.Add(new ControlIcon()
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
                }.Render(context));
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                button.Elements.Add(new HtmlText(Text));
            }

            if (Modal == null || Modal.Type == TypeModal.None)
            {

            }
            else if (Modal.Type == TypeModal.Formular)
            {
                button.OnClick = $"new webexpress.webui.modalFormularCtrl({{ close: '{InternationalizationManager.I18N(context.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? button.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                button.Href = "#";
            }
            else if (Modal.Type == TypeModal.Brwoser)
            {
                button.OnClick = $"new webexpress.webui.modalPageCtrl({{ close: '{InternationalizationManager.I18N(context.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? button.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
                button.Href = "#";
            }
            else if (Modal.Type == TypeModal.Modal)
            {
                button.AddUserAttribute("data-bs-toggle", "modal");
                button.AddUserAttribute("data-bs-target", "#" + Modal.Modal.Id);
            }

            var dropdownButton = new HtmlElementTextSemanticsSpan(new HtmlElementTextSemanticsSpan() { Class = "caret" })
            {
                Id = string.IsNullOrWhiteSpace(Id) ? "" : Id + "_btn",
                Class = Css.Concatenate("btn dropdown-toggle dropdown-toggle-split", Css.Remove(GetClasses(), "btn-block", Margin.ToClass())),
                Style = GetStyles()
            };
            dropdownButton.AddUserAttribute("data-bs-toggle", "dropdown");
            dropdownButton.AddUserAttribute("aria-expanded", "false");

            var dropdownElements = new HtmlElementTextContentUl
                (
                    Items.Select
                    (
                        x =>
                        x == null || x is ControlDropdownItemDivider || x is ControlLine ?
                        new HtmlElementTextContentLi() { Class = "dropdown-divider", Inline = true } :
                        x is ControlDropdownItemHeader ?
                        x.Render(context) :
                        new HtmlElementTextContentLi(x.Render(context)) { Class = "dropdown-item" }
                    )
                )
            {
                Class = HorizontalAlignment == TypeHorizontalAlignment.Right ? "dropdown-menu dropdown-menu-right" : "dropdown-menu"
            };

            var html = new HtmlElementTextContentDiv
            (
                Modal != null && Modal.Type == TypeModal.Modal ? (IHtmlNode)new HtmlList(button, Modal.Modal.Render(context)) : button,
                dropdownButton,
                dropdownElements
            )
            {
                Class = Css.Concatenate
                (
                    "btn-group",
                    Margin.ToClass(),
                    (Block == TypeBlockButton.Block ? "btn-block" : "")
                ),
                Role = Role
            };

            return html;
        }
    }
}
