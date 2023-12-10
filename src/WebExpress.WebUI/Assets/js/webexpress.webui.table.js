/**
 * A table control.
 */
webexpress.webui.tableCtrl = class extends webexpress.webui.events {
    _table = $("<table class='table table-hover mb-2'/>");
    _col = $("<colgroup/>");
    _head = $("<thead/>");
    _body = $("<tbody>");
    _columns = [];
    _optionSetting = null;
    _optionItems = [];

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - optionsettings Options for displaying the options.
     *        - optionitems The options.
     */
    constructor(settings) {
        super();

        let id = settings.id;
        let css = settings.css;

        this._optionSetting = settings.optionsettings;
        this._optionItems = settings.optionitems ?? [];
        this._table.attr("id", id ?? "");
        this._table.addClass(css);
        this._table.append(this._col);
        this._table.append(this._head);
        this._table.append(this._body);
    }

    /**
     * Deletes all rows from the table.
     */
    clear() {
        this._body.children().remove();
    }

    /**
     * Inserts a row.
     * @param row An object with the values of the columns.
     */
    add(row) {
        let th = $("<tr/>");

        this._columns.forEach(function (column) {
            if (column.render != null) {
                let cell = $("<td/>");
                cell.append(column.render(cell, row));
                th.append(cell);
            }
        });

        this._body.append(th);
    }

    /**
     * Inserts multiple rows.
     * @param data An array of objects of the cells.
     */
    addRange(data) {
        let columns = this._columns;
        let rows = [];

        data.forEach(function (row) {
            let th = $("<tr/>");

            columns.forEach(function (column) {
                if (column.render != null && (typeof column.render === 'string' || column.render instanceof String)) {
                    let cell = $("<td/>");
                    let render = Function("cell", "item", column.render);
                    let renderResult = render(cell, row);
                    if (renderResult != null && renderResult != null) {
                        cell.append(renderResult);
                    }
                    th.append(cell);
                } else if (column.render != null) {
                    let cell = $("<td/>");
                    let renderResult = render(cell, row);
                    if (renderResult != null && renderResult != null) {
                        cell.append(renderResult);
                    }
                    th.append(cell);
                }
            });

            if (this._optionItems.length > 0) {
                let optionItems = this._optionItems.map(function (x) {
                    return {
                        label: x.label,
                        icon: x.icon,
                        color: x.color,
                        css: x.css,
                        url: x.url,
                        disabled: x.disabled,
                        onclick: x.onclick,
                        item: row
                    }
                });
                let cell = $("<td style='text-align:right;'/>");
                let more = new webexpress.webui.moreCtrl(optionItems, this._optionSetting);

                cell.append(more.getCtrl);
                th.append(cell);
            }

            rows.push(th);
        }.bind(this));
        this._body.append(rows);
    }

    /**
     * Sets the column definitions.
     * @param columns The columns array of objects { Label, Icon, Width}.
     */
    set columns(columns) {
        this._columns = columns;

        let head_col = [];
        let head_row = $("<tr/>");
                
        this._columns.forEach(function (column) {
            let label = column.label;
            let icon = column.icon;
            let width = column.width != null ? column.width + "%" : "auto";

            let col = $("<col span='1' style='width: " + width + ";'>");
            let th = $("<th/>");

            if (icon != null && (typeof icon === 'string' || icon instanceof String)) {

                th.append($("<i class='" + icon + " me-2'/>"));
                th.append(label);
            } else if (icon != null) {
                icon.addClass("me-2");
                th.append(icon);
                th.append(label);
            } else {
                th.append(label);
            }

            head_col.push(col);
            head_row.append(th)
        });

        if (this._optionItems.length > 0) {
            let col = $("<col/>");
            let th = $("<th/>");
            head_col.push(col);
            head_row.append(th)
        }

        this._col.children().remove();
        this._col.append(head_col);
        this._head.children().remove();
        this._head.append(head_row);

        this.trigger('webexpress.webui.change.columns');
    }

    /**
     * Returns column definitions.
     */
    get columns() {
        return this._columns;
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._table;
    }
}