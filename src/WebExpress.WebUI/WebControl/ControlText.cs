﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebUI.WebControl
{
    public class ControlText : Control
    {
        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        public new virtual PropertyColorText TextColor
        {
            get => (PropertyColorText)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Liefert oder setzt das Format des Textes
        /// </summary>
        public TypeFormatText Format { get; set; }

        /// <summary>
        /// Returns or sets the size of the text.
        /// </summary>
        public PropertySizeText Size
        {
            get => (PropertySizeText)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets a tooltip text.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ControlText()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlText(string id)
            : base(id)
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var text = I18N(context.Culture, Text);
            HtmlElement html;

            switch (Format)
            {
                case TypeFormatText.Paragraph:
                    html = new HtmlElementTextContentP(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Italic:
                    html = new HtmlElementTextSemanticsI(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Bold:
                    html = new HtmlElementTextSemanticsB(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Underline:
                    html = new HtmlElementTextSemanticsU(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.StruckOut:
                    html = new HtmlElementTextSemanticsS(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Cite:
                    html = new HtmlElementTextSemanticsCite(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H1:
                    html = new HtmlElementSectionH1(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H2:
                    html = new HtmlElementSectionH2(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H3:
                    html = new HtmlElementSectionH3(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H4:
                    html = new HtmlElementSectionH4(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H5:
                    html = new HtmlElementSectionH5(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.H6:
                    html = new HtmlElementSectionH6(text)
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Span:
                    html = new HtmlElementTextSemanticsSpan(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Small:
                    html = new HtmlElementTextSemanticsSmall(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Strong:
                    html = new HtmlElementTextSemanticsStrong(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Center:
                    html = new HtmlElementTextContentDiv(new HtmlText(text))
                    {
                        Id = Id,
                        Class = Css.Concatenate("text-center", GetClasses()),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Code:
                    html = new HtmlElementTextSemanticsCode(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Output:
                    html = new HtmlElementTextSemanticsSamp(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Time:
                    html = new HtmlElementTextSemanticsTime(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Mark:
                    html = new HtmlElementTextSemanticsMark(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Highlight:
                    html = new HtmlElementTextSemanticsEm(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Definition:
                    html = new HtmlElementTextSemanticsDfn(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Abbreviation:
                    html = new HtmlElementTextSemanticsAbbr(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Input:
                    html = new HtmlElementTextSemanticsKdb(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Blockquote:
                    html = new HtmlElementTextContentBlockquote(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Figcaption:
                    html = new HtmlElementTextContentFigcaption(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Preformatted:
                    html = new HtmlElementTextContentPre(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
                case TypeFormatText.Markdown:
                    return new HtmlRaw(Markdig.Markdown.ToHtml(text));
                default:
                    html = new HtmlElementTextContentDiv(new HtmlText(text))
                    {
                        Id = Id,
                        Class = GetClasses(),
                        Style = GetStyles(),
                        Role = Role
                    };
                    break;
            }

            if (!string.IsNullOrWhiteSpace(Title))
            {
                html.AddUserAttribute("data-toggle", "tooltip");
                html.AddUserAttribute("title", Title);
            }

            return html;
        }
    }
}
