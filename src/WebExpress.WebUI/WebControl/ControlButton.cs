using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a button control.
    /// </summary>
    public class ControlButton : Control, IControlButton
    {
        private readonly List<IControl> _content = [];

        /// <summary>
        /// Returns the content of the control.
        /// </summary>
        /// <value>
        /// An enumerable collection of child controls.
        /// </value>
        public IEnumerable<IControl> Content => _content;

        /// <summary>
        /// Returns or sets the color.
        /// </summary>
        public new PropertyColorButton BackgroundColor
        {
            get => (PropertyColorButton)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(Outline), () => value?.ToStyle(Outline));
        }

        /// <summary>
        /// Returns or sets the size.
        /// </summary>
        public TypeSizeButton Size
        {
            get => (TypeSizeButton)GetProperty(TypeSizeButton.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the outline property
        /// </summary>
        public bool Outline { get; set; }

        /// <summary>
        /// Returns or sets whether the button should take up the full width.
        /// </summary>
        public TypeBlockButton Block
        {
            get => (TypeBlockButton)GetProperty(TypeBlockButton.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Returns or sets a modal dialogue.
        /// </summary>
        public PropertyModal Modal { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the activation status of the button.
        /// </summary>
        public TypeActive Active
        {
            get => (TypeActive)GetProperty(TypeActive.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The child controls to be added to the button.</param>
        public ControlButton(string id = null, params IControl[] content)
            : base(id)
        {
            Size = TypeSizeButton.Default;
            _content.AddRange(content);
        }

        /// <summary>
        /// Adds one or more controls to the content.
        /// </summary>
        /// <param name="controls">The controls to add to the content.</param>
        /// <remarks>
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of the control panel. 
        /// It is useful for dynamically constructing the user interface by appending various controls to the panel's content.
        /// 
        /// Example usage:
        /// <code>
        /// var button = new ControlButton();
        /// var text1 = new ControlText { Text = "A" };
        /// var text2 = new ControlText { Text = "B" };
        /// button.Add(text1, text2);
        /// </code>
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public void Add(params IControl[] items)
        {
            _content.AddRange(items);
        }

        /// <summary>
        /// Adds one or more controls to the content.
        /// </summary>
        /// <param name="controls">The controls to add to the content.</param>
        /// <remarks>
        /// This method allows adding one or multiple controls to the <see cref="Content"/> collection of the control panel. 
        /// It is useful for dynamically constructing the user interface by appending various controls to the panel's content.
        /// 
        /// Example usage:
        /// <code>
        /// var button = new ControlButton();
        /// var text1 = new ControlText { Text = "A" };
        /// var text2 = new ControlText { Text = "B" };
        /// button.Add(new List<IControl>([text1, text2]));
        /// </code>
        /// This method accepts any control that implements the <see cref="IControl"/> interface.
        /// </remarks>
        public void Add(IEnumerable<IControl> items)
        {
            _content.AddRange(items);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var html = new HtmlElementFieldButton()
            {
                Id = Id,
                Type = "button",
                Value = Value,
                Class = Css.Concatenate("btn", GetClasses()),
                Style = GetStyles(),
                Role = Role,
                Disabled = Active == TypeActive.Disabled
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
                }.Render(renderContext, visualTree));
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                html.Add(new HtmlText(I18N.Translate(renderContext.Request.Culture, Text)));
            }

            if (!string.IsNullOrWhiteSpace(OnClick?.ToString()))
            {
                html.AddUserAttribute("onclick", OnClick?.ToString());
            }

            if (_content.Count != 0)
            {
                html.Add(_content.Select(x => x.Render(renderContext, visualTree)).ToArray());
            }

            if (Modal == null || Modal.Type == TypeModal.None)
            {

            }
            else if (Modal.Type == TypeModal.Form)
            {
                html.OnClick = $"new webexpress.webui.modalFormCtrl({{ close: '{I18N.Translate(renderContext.Request.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
            }
            else if (Modal.Type == TypeModal.Brwoser)
            {
                html.OnClick = $"new webexpress.WebUI.modalPageCtrl({{ close: '{I18N.Translate(renderContext.Request.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
            }
            else if (Modal.Type == TypeModal.Modal)
            {
                html.AddUserAttribute("data-bs-toggle", "modal");
                html.AddUserAttribute("data-bs-target", "#" + Modal.Modal.Id);

                return new HtmlList(html, Modal.Modal.Render(renderContext, visualTree));
            }

            return html;
        }
    }
}
