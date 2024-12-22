﻿using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a progress bar control.
    /// </summary>
    public class ControlProgressBar : Control
    {
        /// <summary>
        /// Returns or sets the format of the progress bar.
        /// </summary>
        public TypeFormatProgress Format { get; set; }

        /// <summary>
        /// Returns or sets the size.
        /// </summary>
        public TypeSizeProgress Size
        {
            get => (TypeSizeProgress)GetProperty(TypeSizeButton.Default);
            set => SetProperty(value, () => value.ToClass(), () => value.ToStyle());
        }

        /// <summary>
        /// Returns or sets the progress bar color.
        /// </summary>
        public PropertyColorProgress Color { get; set; }

        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        public new PropertyColorText TextColor { get; set; }

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Returns or sets the minimum value.
        /// </summary>
        public uint Min { get; set; } = 0;

        /// <summary>
        /// Returns or sets the maximum value.
        /// </summary>
        public uint Max { get; set; } = 100;

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlProgressBar(string id = null)
            : base(id)
        {
            BackgroundColor = new PropertyColorBackground(TypeColorBackground.Default);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            if (Format == TypeFormatProgress.Default)
            {
                return new HtmlElementFormProgress(Value + "%")
                {
                    Id = Id,
                    Class = GetClasses(),
                    Style = GetStyles(),
                    Role = Role,
                    Min = Min.ToString(),
                    Max = Max.ToString(),
                    Value = Value.ToString()
                };
            }

            var bar = new HtmlElementTextContentDiv(new HtmlText(I18N.Translate(renderContext.Request?.Culture, Text)))
            {
                Role = "progressbar",
                Class = Css.Concatenate
                (
                    "progress-bar",
                    Color?.ToClass(),
                    TextColor?.ToClass(),
                    Format.ToClass()
                ),
                Style = Css.Concatenate
                (
                    "width: " + Value + "%;",
                    Color?.ToStyle(),
                    TextColor?.ToStyle()
                )
            };
            bar.AddUserAttribute("aria-valuenow", Value.ToString());
            bar.AddUserAttribute("aria-valuemin", Min.ToString());
            bar.AddUserAttribute("aria-valuemax", Max.ToString());

            var html = new HtmlElementTextContentDiv(bar)
            {
                Id = Id,
                Role = Role,
                Class = Css.Concatenate
                (
                    "progress",
                    GetClasses()
                ),
                Style = GetStyles()
            };

            return html;
        }
    }
}
