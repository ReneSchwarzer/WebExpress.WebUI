using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    public class ControlTable : Control
    {
        /// <summary>
        /// Returns or sets the layout. der Spaltenüberschrift
        /// </summary>
        public TypesLayoutTableRow ColumnLayout { get; set; }

        /// <summary>
        /// Returns or sets the columns.
        /// </summary>
        public List<ControlTableColumn> Columns { get; private set; }

        /// <summary>
        /// Returns or sets the rows.
        /// </summary>
        public List<ControlTableRow> Rows { get; private set; }

        /// <summary>
        /// Returns or sets the responsive property.
        /// </summary>
        public bool Responsive { get; set; }

        /// <summary>
        /// Returns or sets the striped property.
        /// </summary>
        public bool Striped { get; set; }

        /// <summary>
        /// Returns or sets the table to be rotated.
        /// </summary>
        public bool Reflow { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTable(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Striped = true;
            Columns = new List<ControlTableColumn>();
            Rows = new List<ControlTableRow>();
        }

        /// <summary>
        /// Adds a column.
        /// </summary>
        /// <param name="name">The header of the column.</param>
        public virtual void AddColumn(string name)
        {
            Columns.Add(new ControlTableColumn(null)
            {
                Text = name
            });
        }

        /// <summary>
        /// Adds a column.
        /// </summary>
        /// <param name="name">The header of the column.</param>
        /// <param name="icon">The icon of the column.</param>
        public virtual void AddColumn(string name, PropertyIcon icon)
        {
            Columns.Add(new ControlTableColumn(null)
            {
                Text = name,
                Icon = icon
            });
        }

        /// <summary>
        /// Adds a column.
        /// </summary>
        /// <param name="name">The header of the column.</param>
        /// <param name="icon">The icon of the column.</param>
        /// <param name="layout">The layout of the column.</param>
        public virtual void AddColumn(string name, PropertyIcon icon, TypesLayoutTableRow layout)
        {
            Columns.Add(new ControlTableColumn(null)
            {
                Text = name,
                Icon = icon,
                Layout = layout
            });
        }

        /// <summary>
        /// Adds a row.
        /// </summary>
        /// <param name="cells">The cells of the row.</param>
        public void AddRow(params Control[] cells)
        {
            var r = new ControlTableRow(null);
            r.Cells.AddRange(cells);

            Rows.Add(r);
        }

        /// <summary>
        /// Adds a row.
        /// </summary>
        /// <param name="cells">The cells of the row.</param>
        /// <param name="cssClass">The css class.</param>
        public void AddRow(Control[] cells, string cssClass = null)
        {
            var r = new ControlTableRow(null) { Classes = new List<string>(new[] { cssClass }) };
            r.Cells.AddRange(cells);

            Rows.Add(r);
        }

        /// <summary>
        /// Adds a row.
        /// </summary>
        /// <param name="cells">The cells of the row.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="cssClass">The css class.</param>
        public void AddRow(Control[] cells, TypesLayoutTableRow layout, string cssClass = null)
        {
            var r = new ControlTableRow(null) { Classes = new List<string>(new[] { cssClass }), Layout = layout };
            r.Cells.AddRange(cells);

            Rows.Add(r);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Columns.ForEach(x => x.Layout = ColumnLayout);
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

            html.Columns = new HtmlElementTableTr(Columns.Select(x => x.Render(context)));
            html.Rows.AddRange(from x in Rows select x.Render(context) as HtmlElementTableTr);

            return html;
        }
    }
}
