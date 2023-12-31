﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Zeile der Tabelle
    /// </summary>
    public class ControlTableRow : Control
    {
        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypesLayoutTableRow Layout { get; set; }

        /// <summary>
        /// Returns or set the cells.
        /// </summary>
        public List<Control> Cells { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlTableRow(string id = null)
            : base(id)
        {
            Cells = new List<Control>();
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
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

            return new HtmlElementTableTr(from c in Cells select new HtmlElementTableTd(c.Render(context)))
            {
                Id = Id,
                Class = string.Join(" ", Classes.Where(x => !string.IsNullOrWhiteSpace(x))),
                Style = string.Join("; ", Styles.Where(x => !string.IsNullOrWhiteSpace(x))),
                Role = Role
            };
        }
    }
}
