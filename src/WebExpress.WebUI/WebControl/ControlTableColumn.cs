using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a table column control.
    /// </summary>
    public class ControlTableColumn : Control
    {
        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypesLayoutTableRow Layout { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTableColumn(string id = null)
            : base(id)
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
            var classes = Classes.ToList();

            switch (Layout)
            {
                case TypesLayoutTableRow.Primary:
                    classes.Add("table-primary");
                    break;
                case TypesLayoutTableRow.Secondary:
                    classes.Add("table-secondary");
                    break;
                case TypesLayoutTableRow.Success:
                    classes.Add("table-success");
                    break;
                case TypesLayoutTableRow.Info:
                    classes.Add("table-info");
                    break;
                case TypesLayoutTableRow.Warning:
                    classes.Add("table-warning");
                    break;
                case TypesLayoutTableRow.Danger:
                    classes.Add("table-danger");
                    break;
                case TypesLayoutTableRow.Light:
                    classes.Add("table-light");
                    break;
                case TypesLayoutTableRow.Dark:
                    classes.Add("table-dark");
                    break;
            }

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
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
                html.Add(new HtmlText(I18N.Translate(renderContext.Request?.Culture, Text)));
            }

            return new HtmlElementTableTh(html)
            {
                Id = Id,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
