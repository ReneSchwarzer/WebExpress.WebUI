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
            var rowClass = Layout switch
            {
                TypesLayoutTableRow.Primary => "table-primary",
                TypesLayoutTableRow.Secondary => "table-secondary",
                TypesLayoutTableRow.Success => "table-success",
                TypesLayoutTableRow.Info => "table-info",
                TypesLayoutTableRow.Warning => "table-warning",
                TypesLayoutTableRow.Danger => "table-danger",
                TypesLayoutTableRow.Light => "table-light",
                TypesLayoutTableRow.Dark => "table-dark",
                _ => ""
            };

            return new HtmlElementTableTr(_cells.Select(c => new HtmlElementTableTd(c.Render(renderContext, visualTree))).ToArray())
            {
                Id = Id,
                Class = Css.Concatenate(rowClass, GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
