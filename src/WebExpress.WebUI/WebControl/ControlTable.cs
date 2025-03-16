using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a table control.
    /// </summary>
    public class ControlTable : Control
    {
        private readonly List<ControlTableColumn> _columns = [];
        private readonly List<ControlTableRow> _rows = [];

        /// <summary>
        /// Returns the columns of the table.
        /// </summary>
        public IEnumerable<ControlTableColumn> Columns => _columns;

        /// <summary>
        /// Returns the rows of the table.
        /// </summary>
        public IEnumerable<ControlTableRow> Rows => _rows;

        /// <summary>
        /// Returns or sets the layout of the column header.
        /// </summary>
        public TypesLayoutTableRow ColumnLayout { get; set; }

        /// <summary>
        /// Returns or sets a value indicating whether the table is responsive.
        /// </summary>
        public bool Responsive { get; set; }

        /// <summary>
        /// Returns or sets a value indicating whether the table is striped.
        /// </summary>
        public bool Striped { get; set; }

        /// <summary>
        /// Returns or sets a value indicating whether the table should reflow.
        /// </summary>
        public bool Reflow { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="columns">The columns to add to the table.</param>
        /// <param name="rows">The rows to add to the table.</param>
        public ControlTable(string id = null, ControlTableColumn[] columns = null, params ControlTableRow[] rows)
            : base(id)
        {
            Striped = true;
            _columns.AddRange(columns ?? []);
            _rows.AddRange(rows);
        }

        /// <summary>
        /// Adds a column to the table.
        /// </summary>
        /// <param name="name">The header of the column.</param>
        /// <param name="icon">The icon of the column.</param>
        /// <param name="layout">The layout of the column.</param>
        public virtual void AddColumn(string name, IIcon icon = null, TypesLayoutTableRow layout = TypesLayoutTableRow.Default)
        {
            _columns.Add(new ControlTableColumn(null)
            {
                Text = name,
                Icon = icon,
                Layout = layout
            });
        }

        /// <summary>
        /// Adds one or more columns to the table.
        /// </summary>
        /// <param name="columns">The columns to add.</param>
        public virtual void AddColumns(params ControlTableColumn[] columns)
        {
            _columns.AddRange(columns);
        }

        /// <summary>
        /// Adds one or more columns to the table.
        /// </summary>
        /// <param name="columns">The columns to add.</param>
        public virtual void AddColumns(IEnumerable<ControlTableColumn> columns)
        {
            _columns.AddRange(columns);
        }

        /// <summary>
        /// Adds a row to the table.
        /// </summary>
        /// <param name="cells">The cells of the row.</param>
        public void AddRow(params IControl[] cells)
        {
            var r = new ControlTableRow(null, cells);

            _rows.Add(r);
        }

        /// <summary>
        /// Adds one or more rows to the table.
        /// </summary>
        /// <param name="rows">The rows to add.</param>
        public void AddRows(params ControlTableRow[] rows)
        {
            _rows.AddRange(rows);
        }

        /// <summary>
        /// Adds one or more rows to the table.
        /// </summary>
        /// <param name="rows">The rows to add.</param>
        public void AddRows(IEnumerable<ControlTableRow> rows)
        {
            _rows.AddRange(rows);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            _columns.ForEach(x => x.Layout = ColumnLayout);
            var classes = Classes.ToList();
            classes.Add("table");

            if (Striped)
            {
                classes.Add("table-striped");
            }

            if (Responsive)
            {
                classes.Add("table-responsive");
            }

            if (Reflow)
            {
                classes.Add("table-reflow");
            }

            var html = new HtmlElementTableTable()
            {
                Id = Id,
                Class = string.Join(" ", classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };

            html.Columns = new HtmlElementTableTr(Columns.Select(x => x.Render(renderContext, visualTree)).ToArray());
            html.Rows.AddRange(from x in Rows select x.Render(renderContext, visualTree) as HtmlElementTableTr);

            return html;
        }
    }
}
