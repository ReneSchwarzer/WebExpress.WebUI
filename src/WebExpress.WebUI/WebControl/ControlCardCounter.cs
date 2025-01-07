﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a counter with an icon, value, progress, and text.
    /// </summary>
    public class ControlCardCounter : Control
    {
        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the counter value.
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Returns or sets the value of the progrss.
        /// </summary>
        public uint? Progress { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlCardCounter(string id = null)
            : base(id)
        {
            TextColor = new PropertyColorText(TypeColorText.Default);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var html = new HtmlElementTextSemanticsSpan()
            {
                Id = Id,
                Class = Css.Concatenate("card-counter", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            if (Icon != null && Icon.HasIcon)
            {
                html.Add(new ControlIcon()
                {
                    Icon = Icon,
                    TextColor = TextColor,
                    HorizontalAlignment = TypeHorizontalAlignment.Right
                }.Render(renderContext, visualTree));
            }

            var text = new ControlText(string.IsNullOrWhiteSpace(Id) ? null : Id + "_header")
            {
                Text = Value.HasValue ? Value.Value.ToString() : null,
                Format = TypeFormatText.H4
            };

            var info = new ControlText()
            {
                Text = Text,
                Format = TypeFormatText.Span,
                TextColor = new PropertyColorText(TypeColorText.Muted)
            };

            html.Add(new ControlPanel(null, text, info) { }.Render(renderContext, visualTree));

            if (Progress.HasValue)
            {
                html.Add(new ControlProgressBar()
                {
                    Value = Progress.Value,
                    Format = TypeFormatProgress.Striped,
                    BackgroundColor = BackgroundColor,
                    //Color = Color,
                    Size = TypeSizeProgress.Small
                }.Render(renderContext, visualTree));
            }

            return html;
        }
    }
}
