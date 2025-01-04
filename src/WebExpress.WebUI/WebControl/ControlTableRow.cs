using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a table row control.
    /// </summary>
    public class ControlTableRow : Control
    {
        private readonly List<IControl> _cells = [];

        /// <summary>
        /// Returns or set the cells.
        /// </summary>
        public IEnumerable<IControl> Cells { get; private set; }

        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypesLayoutTableRow Layout { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="cells">The cells to be added to the row.</param>
        public ControlTableRow(string id = null, params IControl[] cells)
            : base(id)
        {
            _cells.AddRange(cells);
        }        /// <summary>
        /// Adds the specified cells to the row.
        /// </summary>
        /// <param name="cells">The cells to be added to the row.</param>
        public void Add(params IControl[] cells)
        {
            _cells.AddRange(cells);
        }

        /// <summary>
        /// Removes the specified cell from the row.
        /// </summary>
        /// <param name="cell">The cell to be removed from the row.</param>
        public void Remove(IControl cell)
        {
            _cells.Remove(cell);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            switch (Layout)
            {
                case TypesLayoutTableRow.Primary:
                    Classes.Add("table-primary");
                    break;
                case TypesLayoutTableRow.Secondary:
                    Classes.Add("table-secondary");
                    break;
                case TypesLayoutTableRow.Success:
                    Classes.Add("table-success");
                    break;
                case TypesLayoutTableRow.Info:
                    Classes.Add("table-info");
                    break;
                case TypesLayoutTableRow.Warning:
                    Classes.Add("table-warning");
                    break;
                case TypesLayoutTableRow.Danger:
                    Classes.Add("table-danger");
                    break;
                case TypesLayoutTableRow.Light:
                    Classes.Add("table-light");
                    break;
                case TypesLayoutTableRow.Dark:
                    Classes.Add("table-dark");
                    break;
            }

            return new HtmlElementTableTr(_cells.Select(c => new HtmlElementTableTd(c.Render(renderContext, visualTree))).ToArray())
            {
                Id = Id,
                Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
