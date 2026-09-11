/**
 * Shared browser and headless regressions for cell boundaries and rectangular table operations.
 */
export function tableCases(test, assert, loadEditor) {
    const fixture = (html = "<tr><td>A</td><td>B</td><td>C</td></tr><tr><td>D</td><td>E</td><td>F</td></tr>") => {
        const rt = loadEditor();
        rt.root.innerHTML = `<div class="wx-addon-frame" contenteditable="false"><div class="wx-addon-body-container"><table contenteditable="true"><tbody>${html}</tbody></table></div></div>`;
        const editor = rt.editorMock();
        editor.restoreSavedRange = () => {};
        const table = rt.root.querySelector("table");
        return { ...rt, editor, table, plugin: rt.plugins.get("table"), cells: Array.from(table.querySelectorAll("td,th")) };
    };

    for (const [command, tag] of [["insertUnorderedList", "ul"], ["insertOrderedList", "ol"]]) {
        test(`${command} on bare cell text preserves the table and other cells`, () => {
            const { wx, root, select, selection, editor, cells, table } = fixture();
            select(cells[1].firstChild, 0, cells[1].firstChild, 1);
            wx.EditorList.exec(editor, command);
            assert.equal(root.querySelector("table"), table);
            assert.equal(cells[1].innerHTML, `<${tag}><li>B</li></${tag}>`);
            assert.equal(cells[0].innerHTML, "A");
            assert.equal(cells[2].innerHTML, "C");
            assert.equal(selection.getRangeAt(0).toString(), "B");
            wx.EditorList.exec(editor, command);
            assert.equal(cells[1].innerHTML, "<p>B</p>");
        });
    }

    test("a list at an empty cell caret stays inside that cell", () => {
        const { wx, select, selection, editor, cells } = fixture("<tr><td><br></td><td>next</td></tr>");
        select(cells[0], 0, cells[0], 0);
        wx.EditorList.exec(editor, "insertUnorderedList");
        assert.equal(cells[0].innerHTML, "<ul><li><br></li></ul>");
        assert.equal(cells[0].contains(selection.getRangeAt(0).startContainer), true);
        assert.equal(cells[1].innerHTML, "next");
    });

    test("list formatting preserves a table nested in an outer list item", () => {
        const { wx, root, select, editor, table, cells, document } = fixture();
        const list = document.createElement("ul"), item = document.createElement("li");
        item.appendChild(root.firstChild);
        list.appendChild(item);
        root.appendChild(list);
        select(cells[0].firstChild, 0, cells[0].firstChild, 1);
        assert.equal(wx.EditorList.queryState(editor, "insertUnorderedList"), false);
        wx.EditorList.exec(editor, "insertUnorderedList");
        assert.equal(root.firstChild, list);
        assert.equal(item.contains(table), true);
        assert.equal(cells[0].innerHTML, "<ul><li>A</li></ul>");
    });

    test("a selected paragraph inside a cell leaves its other paragraphs intact", () => {
        const { wx, select, editor, cells } = fixture("<tr><td><p>one</p><p>two</p></td><td>next</td></tr>");
        const text = cells[0].lastChild.firstChild;
        select(text, 0, text, 3);
        wx.EditorList.exec(editor, "insertUnorderedList");
        assert.equal(cells[0].innerHTML, "<p>one</p><ul><li>two</li></ul>");
    });

    test("indent on bare cell text changes its paragraph rather than its frame", () => {
        const { wx, root, select, editor, cells } = fixture();
        select(cells[0].firstChild, 0, cells[0].firstChild, 1);
        wx.EditorList.exec(editor, "indent");
        assert.equal(cells[0].firstChild.style.marginLeft, "40px");
        assert.equal(root.firstChild.style.marginLeft, "");
    });

    test("list formatting of a rectangle excludes intervening cells and includes empty cells", () => {
        const { wx, plugin, editor, cells } = fixture("<tr><td>A</td><td></td><td>C</td></tr><tr><td>D</td><td>E</td><td>F</td></tr>");
        plugin._selectCellRectangle(editor, cells[0], cells[4]);
        wx.EditorList.exec(editor, "insertUnorderedList");
        for (const i of [0, 1, 3, 4]) assert.equal(cells[i].firstChild.tagName, "UL");
        assert.equal(cells[2].innerHTML, "C");
        assert.equal(cells[5].innerHTML, "F");
    });

    test("list formatting at a cell boundary uses the existing paragraph", () => {
        const { wx, select, editor, cells } = fixture("<tr><td><p>A</p></td><td>B</td></tr>");
        select(cells[0], 0, cells[0], 0);
        wx.EditorList.exec(editor, "insertUnorderedList");
        assert.equal(cells[0].innerHTML, "<ul><li>A</li></ul>");
    });

    test("context actions preserve a two-by-two selection and merge only those cells", () => {
        const { plugin, table, editor, cells, select, selection } = fixture();
        select(cells[0].firstChild, 0, cells[4].firstChild, 1);
        const items = plugin.getContextMenuItems(editor, cells[4]);
        assert.equal(selection.getRangeAt(0).collapsed, false);
        items.find(item => item.label?.endsWith("merge.cells")).action();
        assert.equal(table.rows.length, 2);
        assert.equal(table.rows[0].cells.length, 2);
        assert.equal(table.rows[1].cells.length, 1);
        assert.equal(cells[0].getAttribute("rowspan"), "2");
        assert.equal(cells[0].getAttribute("colspan"), "2");
        assert.equal(cells[0].innerHTML, "A<br>B<br>D<br>E");
        assert.equal(cells[2].textContent, "C");
        assert.equal(cells[5].textContent, "F");
    });

    test("merge with only a caret never consumes an unselected neighbor", () => {
        const { plugin, table, editor, cells, select } = fixture();
        const html = table.innerHTML;
        select(cells[0], 0, cells[0], 0);
        plugin._modifyTable(editor, "mergeCells");
        assert.equal(table.innerHTML, html);
    });

    test("reverse rectangular selections merge an entire selected column", () => {
        const { plugin, table, editor, cells } = fixture();
        plugin._selectCellRectangle(editor, cells[4], cells[1]);
        plugin._modifyTable(editor, "mergeCells");
        assert.equal(cells[1].getAttribute("rowspan"), "2");
        assert.equal(cells[1].innerHTML, "B<br>E");
        assert.equal(table.rows[0].cells.length, 3);
        assert.equal(table.rows[1].cells.length, 2);
    });

    test("splitting a two-dimensional merge restores logical positions before unaffected cells", () => {
        const { plugin, table, editor, cells } = fixture();
        plugin._selectCellRectangle(editor, cells[0], cells[4]);
        plugin._modifyTable(editor, "mergeCells");
        plugin._modifyTable(editor, "splitCell");
        assert.equal(table.rows[0].cells.length, 3);
        assert.equal(table.rows[1].cells.length, 3);
        assert.equal(table.rows[0].cells[2], cells[2]);
        assert.equal(table.rows[1].cells[2], cells[5]);
        assert.equal(cells[0].hasAttribute("rowspan"), false);
        assert.equal(cells[0].hasAttribute("colspan"), false);
    });

    test("existing row spans expand the rectangle without shifting later columns", () => {
        const { plugin, editor, cells, table } = fixture('<tr><td rowspan="2">A</td><td>B</td><td>C</td></tr><tr><td>D</td><td>E</td></tr>');
        plugin._selectCellRectangle(editor, cells[3], cells[0]);
        assert.deepEqual(Array.from(plugin._getSelectedCells(editor), c => c.textContent), ["A", "B", "D"]);
        plugin._modifyTable(editor, "mergeCells");
        assert.equal(cells[0].getAttribute("rowspan"), "2");
        assert.equal(cells[0].getAttribute("colspan"), "2");
        assert.equal(table.rows[1].cells[0], cells[4]);
    });

    test("a merged cell spanning the full height can be split with empty covered rows", () => {
        const { plugin, editor, cells, table, select } = fixture('<tr><td rowspan="0" colspan="2">A</td></tr><tr></tr><tr></tr>');
        select(cells[0], 0, cells[0], 0);
        plugin._modifyTable(editor, "splitCell");
        assert.deepEqual(Array.from(table.rows, row => row.cells.length), [2, 2, 2]);
    });

    test("merge refuses selections across the header and body row groups", () => {
        const { plugin, editor, table, document } = fixture();
        const head = document.createElement("thead");
        head.innerHTML = "<tr><th>header</th><th>other</th><th>last</th></tr>";
        table.insertBefore(head, table.firstChild);
        const cells = Array.from(table.querySelectorAll("td,th"));
        plugin._selectCellRectangle(editor, cells[0], cells[3]);
        const html = table.innerHTML;
        plugin._modifyTable(editor, "mergeCells");
        assert.equal(table.innerHTML, html);
    });

    test("merging keeps live descendants and their inline formatting", () => {
        const { plugin, editor, cells } = fixture('<tr><td><strong>A</strong></td><td><a href="/target">B</a></td><td>C</td></tr>');
        const link = cells[1].firstChild;
        plugin._selectCellRectangle(editor, cells[0], cells[1]);
        plugin._modifyTable(editor, "mergeCells");
        assert.equal(cells[0].querySelector("a"), link);
        assert.equal(cells[0].querySelector("strong").textContent, "A");
    });

    test("cell colors affect the whole rectangle and publish one change", () => {
        const { plugin, editor, cells } = fixture();
        let changes = 0;
        editor._syncValue = () => changes++;
        plugin._selectCellRectangle(editor, cells[0], cells[4]);
        plugin._setCellBackground(editor, "red");
        assert.equal(changes, 1);
        for (const i of [0, 1, 3, 4]) assert.equal(cells[i].style.backgroundColor, "red");
        assert.equal(cells[2].style.backgroundColor, "");
    });

    test("selection decoration never enters form values or undo snapshots", () => {
        const { plugin, editor, cells, wx, root } = fixture();
        const html = root.innerHTML;
        const history = new wx.EditorHistory(editor);
        editor._history = history;
        editor._syncValue = () => history.notify(false);
        editor._notifyPluginsContentChanged = () => plugin._clearCellSelection(editor);
        plugin._selectCellRectangle(editor, cells[0], cells[4]);
        assert.equal(wx.EditorSelection.contentHtml(root), html);
        plugin._modifyTable(editor, "mergeCells");
        const merged = root.innerHTML;
        history.undo();
        assert.equal(root.innerHTML, html);
        history.redo();
        assert.equal(root.innerHTML, merged);
        history.destroy();
    });

    test("cell selection state is isolated between editor instances", () => {
        const first = fixture(), second = fixture();
        first.plugin._selectCellRectangle(first.editor, first.cells[0], first.cells[4]);
        const count = first.plugin._getSelectedCells(first.editor).length;
        first.plugin.getContextMenuItems(second.editor, second.cells[1]);
        assert.equal(first.plugin._getSelectedCells(first.editor).length, count);
        assert.equal(second.cells[0].hasAttribute("data-wx-table-selected"), false);
    });

    test("drag listeners preserve ordinary text selection and release their state on teardown", () => {
        const { plugin, editor, cells, root, document } = fixture();
        const cleanup = plugin._enableCellSelection(editor);
        const mouse = (type, cell, options = {}) => {
            const event = typeof MouseEvent === "function"
                ? new MouseEvent(type, { bubbles: true, cancelable: true, button: 0, buttons: 1, ...options })
                : { type, target: cell, button: 0, buttons: 1, ...options,
                    preventDefault() { this.defaultPrevented = true; } };
            if (typeof MouseEvent === "function") cell.dispatchEvent(event);
            else (type === "mousedown" ? root : document).dispatchEvent(event);
            return event;
        };
        mouse("mousedown", cells[0]);
        assert.equal(!!mouse("mousemove", cells[0]).defaultPrevented, false);
        assert.equal(!!mouse("mousemove", cells[4]).defaultPrevented, true);
        mouse("mouseup", document, { buttons: 0 });
        assert.deepEqual(Array.from(plugin._getSelectedCells(editor), cell => cell.textContent), ["A", "B", "D", "E"]);
        cleanup();
        assert.equal(root.querySelectorAll("[data-wx-table-selected]").length, 0);
        mouse("mousedown", cells[2]);
        mouse("mousemove", cells[5]);
        assert.equal(root.querySelectorAll("[data-wx-table-selected]").length, 0);
    });

    test("Shift-click extends a cell selection without losing the first cell", () => {
        const { plugin, editor, cells, select, root } = fixture();
        select(cells[0], 0, cells[0], 0);
        const cleanup = plugin._enableCellSelection(editor);
        if (typeof MouseEvent === "function") {
            cells[4].dispatchEvent(new MouseEvent("mousedown", { bubbles: true, cancelable: true, button: 0, shiftKey: true }));
        } else {
            root.dispatchEvent({ type: "mousedown", target: cells[4], button: 0, shiftKey: true, preventDefault() {} });
        }
        assert.deepEqual(Array.from(plugin._getSelectedCells(editor), cell => cell.textContent), ["A", "B", "D", "E"]);
        cleanup();
    });
}
