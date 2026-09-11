/** Shared engine regressions run against the DOM stub and real browsers. */
export function editorCases(test, assert, loadEditor) {

    test("formatting works in editable table cells inside a non-editable frame", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<div contenteditable="false"><table contenteditable="true"><tbody><tr><td>one</td><td>two</td></tr></tbody></table></div>';
        const cells = root.querySelectorAll("td");
        select(firstText(cells[0]), 1, firstText(cells[1]), 2);
        wx.EditorFormat.exec(editorMock(), "bold");
        assert.equal(cells[0].innerHTML, 'o<strong>ne</strong>');
        assert.equal(cells[1].innerHTML, '<strong>tw</strong>o');
    });

    test("headings inside list items preserve nested lists and the selected text", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<ul><li>alpha<ul><li>child</li></ul></li></ul>';
        const t = firstText(root);
        select(t, 1, t, 4);
        wx.EditorBlocks.exec(editorMock(), "formatblock", "h2");
        assert.equal(root.innerHTML, '<ul><li><h2>alpha</h2><ul><li>child</li></ul></li></ul>');
        assert.equal(selection.getRangeAt(0).toString(), 'lph');
    });
    for (const [command, tag] of [["bold", "strong"], ["italic", "em"], ["underline", "u"],
        ["strikethrough", "s"], ["superscript", "sup"], ["subscript", "sub"]]) {
        test(`${command} removes only the selected part of nested formatting`, () => {
            const { wx, root, el, select, selection, editorMock } = loadEditor();
            const text = el("span", "abcdef");
            root.appendChild(el("p", el(tag, el(tag, text))));
            select(firstText(text), 2, firstText(text), 4);

            wx.EditorFormat.exec(editorMock(), command);

            assert.equal(root.textContent, "abcdef");
            assert.equal(selection.getRangeAt(0).toString(), "cd");
            assert.equal(wx.EditorFormat.queryState(editorMock(), command), false);
            assert.equal(Array.from(root.querySelectorAll(tag)).some(n => n.textContent.includes("cd")), false);
        });
    }

    test("clear format splits all enclosing inline wrappers and preserves surrounding text", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p><strong><em><span style="color: red">abcdef</span></em></strong></p>';
        const t = firstText(root);
        select(t, 2, t, 4);
        wx.EditorFormat.exec(editorMock(), "removeformat");
        assert.equal(root.innerHTML, '<p><strong><em><span style="color: red;">ab</span></em></strong>cd<strong><em><span style="color: red;">ef</span></em></strong></p>');
        assert.equal(selection.getRangeAt(0).toString(), "cd");
    });

    test("changing superscript to subscript removes an enclosing opposite format", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p><sup>abcdef</sup></p>';
        const t = firstText(root);
        select(t, 2, t, 4);
        wx.EditorFormat.exec(editorMock(), "subscript");
        assert.equal(root.innerHTML, '<p><sup>ab</sup><sub>cd</sub><sup>ef</sup></p>');
        assert.equal(selection.getRangeAt(0).toString(), "cd");
    });

    test("inline toolbar state represents the whole selection", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p><strong>bold</strong>plain</p>';
        select(firstText(root), 0, root.firstChild.lastChild, 5);
        assert.equal(wx.EditorFormat.queryState(editorMock(), "bold"), false);
    });

    test("a selection ending at the next text start does not format that block", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p>one</p><p>two</p>';
        select(firstText(root.firstChild), 0, firstText(root.lastChild), 0);
        wx.EditorBlocks.exec(editorMock(), "justifycenter");
        assert.equal(root.innerHTML, '<p style="text-align: center;">one</p><p>two</p>');
    });

    test("block formatting preserves partial selection and paragraph attributes", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p id="intro" dir="rtl">alpha</p><p>beta</p>';
        select(firstText(root.firstChild), 2, firstText(root.lastChild), 2);
        wx.EditorBlocks.exec(editorMock(), "formatblock", "h2");
        assert.equal(root.innerHTML, '<h2 id="intro" dir="rtl">alpha</h2><h2>beta</h2>');
        assert.equal(selection.getRangeAt(0).toString(), "phabe");
    });

    test("clear format leaves the descendants of non-editable content intact", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p><b>one</b><span contenteditable="false"><strong>widget</strong></span><b>two</b></p>';
        select(firstText(root.firstChild.firstChild), 0, firstText(root.firstChild.lastChild), 3);
        wx.EditorFormat.exec(editorMock(), "removeformat");
        assert.equal(root.innerHTML, '<p>one<span contenteditable="false"><strong>widget</strong></span>two</p>');
    });

    test("clear format on a partial link preserves its destination", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p><strong><a href="/page"><em>abcdef</em></a></strong></p>';
        const t = firstText(root);
        select(t, 2, t, 4);
        wx.EditorFormat.exec(editorMock(), "removeformat");
        assert.equal(selection.getRangeAt(0).toString(), "cd");
        const links = Array.from(root.querySelectorAll("a"));
        assert.equal(links.find(a => a.textContent === "cd")?.getAttribute("href"), "/page");
        assert.equal(wx.EditorFormat.queryState(editorMock(), "bold"), false);
        assert.equal(wx.EditorFormat.queryState(editorMock(), "italic"), false);
    });

    test("a no-op history notification preserves the redo branch", () => {
        const { wx, root, editorMock } = loadEditor();
        root.innerHTML = '<p>one</p>';
        const editor = editorMock();
        const history = new wx.EditorHistory(editor);
        root.innerHTML = '<p>two</p>';
        history.notify(false);
        history.undo();
        history.notify(false);
        assert.equal(history.canRedo(), true);
        history.redo();
        assert.equal(root.innerHTML, '<p>two</p>');
    });

    for (const [command, tag] of [["bold", "strong"], ["italic", "em"], ["underline", "u"],
        ["strikethrough", "s"], ["superscript", "sup"], ["subscript", "sub"]]) {
        test(`${command} can be switched off while typing inside that format`, () => {
            const { wx, root, el, select, selection, editorMock } = loadEditor();
            const text = el(tag, "old");
            root.appendChild(el("p", text));
            const editor = editorMock();
            editor._pendingFormat = new wx.EditorPendingFormat(editor);
            select(firstText(text), 3, firstText(text), 3);
            wx.EditorFormat.exec(editor, command);
            assert.equal(wx.EditorFormat.queryState(editor, command), false);
            firstText(text).textContent = "oldx";
            select(firstText(text), 4, firstText(text), 4);
            editor._pendingFormat._onInput({ inputType: "insertText", data: "x" });
            assert.equal(root.innerHTML, `<p><${tag}>old</${tag}>x</p>`);
            assert.equal(selection.getRangeAt(0).collapsed, true);
        });
    }

    test("clear format at the caret applies to the next typed text", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p><strong><em>old</em></strong></p>';
        const editor = editorMock();
        editor._pendingFormat = new wx.EditorPendingFormat(editor);
        const t = firstText(root);
        select(t, 3, t, 3);
        wx.EditorFormat.exec(editor, "removeformat");
        t.textContent = "old ";
        select(t, 4, t, 4);
        editor._pendingFormat._onInput({ inputType: "insertText", data: " " });
        assert.equal(root.innerHTML, '<p><strong><em>old</em></strong> </p>');
    });

    test("pending subscript replaces superscript before typing", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p>x</p>';
        const editor = editorMock();
        editor._pendingFormat = new wx.EditorPendingFormat(editor);
        const t = firstText(root);
        select(t, 1, t, 1);
        wx.EditorFormat.exec(editor, "superscript");
        wx.EditorFormat.exec(editor, "subscript");
        assert.equal(wx.EditorFormat.queryState(editor, "superscript"), false);
        t.textContent = "xy";
        select(t, 2, t, 2);
        editor._pendingFormat._onInput({ inputType: "insertText", data: "y" });
        assert.equal(root.innerHTML, '<p>x<sub>y</sub></p>');
    });

    test("formatting after typing creates a separate undo step with the original selection", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p>a</p>';
        const editor = editorMock();
        const history = new wx.EditorHistory(editor);
        editor._history = history;
        editor._syncValue = () => history.notify(false);
        root.innerHTML = '<p>abc</p>';
        history.notify(true);
        select(firstText(root), 1, firstText(root), 3);
        wx.EditorFormat.exec(editor, "bold");
        history.undo();
        assert.equal(root.innerHTML, '<p>abc</p>');
        assert.equal(selection.getRangeAt(0).toString(), "bc");
        history.undo();
        assert.equal(root.innerHTML, '<p>a</p>');
        history.redo();
        history.redo();
        assert.equal(root.innerHTML, '<p>a<strong>bc</strong></p>');
    });

    test("removing underline keeps strikethrough and color on the same wrapper", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p><u style="color: red; text-decoration-line: underline line-through">abcdef</u></p>';
        const t = firstText(root);
        select(t, 2, t, 4);
        wx.EditorFormat.exec(editorMock(), "underline");
        const text = wx.EditorFormat._textNodesInRange(wx.EditorSelection.getRange(root), root, false)[0];
        assert.equal(text.parentElement.style.color, "red");
        assert.equal(text.parentElement.style.textDecorationLine, "line-through");
    });

    test("a link across paragraphs preserves the block structure and existing emphasis", () => {
        const { wx, root, select, selection, editorMock } = loadEditor();
        root.innerHTML = '<p><em>one</em></p><p>two</p>';
        select(firstText(root.firstChild), 1, firstText(root.lastChild), 2);
        wx.EditorBlocks.exec(editorMock(), "createlink", "/target");
        assert.equal(root.children.length, 2);
        assert.equal(root.querySelectorAll("p").length, 2);
        assert.equal(root.querySelectorAll("a").length, 2);
        assert.equal(selection.getRangeAt(0).toString(), "netw");
        assert.equal(root.firstChild.textContent, "one");
        assert.equal(root.lastChild.textContent, "two");
        assert.equal(Array.from(root.querySelectorAll("a")).some(a => a.querySelector("p")), false);
    });

    test("updating part of an existing link never nests anchors", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p><a href="/old">abcdef</a></p>';
        const t = firstText(root);
        select(t, 2, t, 4);
        wx.EditorBlocks.exec(editorMock(), "createlink", "/new");
        assert.equal(root.innerHTML, '<p><a href="/old">ab</a><a href="/new">cd</a><a href="/old">ef</a></p>');
    });

    test("list commands exclude the next item when the selection ends at its start", () => {
        const { wx, root, select, editorMock } = loadEditor();
        root.innerHTML = '<p>one</p><p>two</p>';
        select(firstText(root.firstChild), 0, firstText(root.lastChild), 0);
        wx.EditorList.exec(editorMock(), "insertunorderedlist");
        assert.equal(root.innerHTML, '<ul><li>one</li></ul><p>two</p>');
    });

    /**
     * Returns the first text node under node, in document order.
     * @param {object} node - The subtree root.
     * @returns {object} The text node.
     */
    function firstText(node) {
        if (node.nodeType === 3) {
            return node;
        }
        for (const child of node.childNodes) {
            const found = firstText(child);
            if (found) {
                return found;
            }
        }
        return null;
    }

    // ---------------------------------------------------------------------------
    // EditorSelection.markRange / restoreRange
    // ---------------------------------------------------------------------------

    test("markRange/restoreRange restores a text selection and removes all markers", () => {
        const { wx, document, selection, root, el } = loadEditor();
        const p = el("p", "hello");
        root.appendChild(p);
        const t = firstText(p);

        const range = document.createRange();
        range.setStart(t, 1);
        range.setEnd(t, 4);

        assert.equal(wx.EditorSelection.markRange(range), true);
        assert.equal(root.querySelectorAll("[data-wx-caret]").length, 2, "a start and an end marker exist");

        assert.equal(wx.EditorSelection.restoreRange(root), true);
        assert.equal(selection.rangeCount, 1);
        assert.equal(selection.getRangeAt(0).toString(), "ell", "the selection is restored");
        assert.equal(root.querySelectorAll("[data-wx-caret]").length, 0, "all markers are removed");
    });

    test("markRange/restoreRange restores a collapsed caret at its position", () => {
        const { wx, document, selection, root, el } = loadEditor();
        const p = el("p", "hello");
        root.appendChild(p);
        const t = firstText(p);

        const range = document.createRange();
        range.setStart(t, 2);
        range.collapse(true);

        wx.EditorSelection.markRange(range);
        wx.EditorSelection.restoreRange(root);

        const caret = selection.getRangeAt(0);
        assert.equal(caret.collapsed, true, "the caret stays collapsed");

        // the caret sits before "llo"
        const probe = document.createRange();
        probe.setStart(caret.startContainer, caret.startOffset);
        probe.setEnd(p, p.childNodes.length);
        assert.equal(probe.toString(), "llo");
    });

    test("markRange sinks root-level markers into the adjacent blocks", () => {
        const { wx, document, selection, root, el } = loadEditor();
        const ul = el("ul", el("li", "one"), el("li", "two"));
        root.appendChild(ul);

        // select-all style boundaries at the root, spanning the whole list
        const range = document.createRange();
        range.setStart(root, 0);
        range.setEnd(root, 1);

        wx.EditorSelection.markRange(range);

        const start = root.querySelector("[data-wx-caret='start']");
        const end = root.querySelector("[data-wx-caret='end']");
        assert.equal(start.parentElement.tagName, "LI", "the start marker sank into the first item");
        assert.equal(end.parentElement.tagName, "LI", "the end marker sank into the last item");
        assert.equal(ul.children.length, 2, "no marker separates the list items");

        wx.EditorSelection.restoreRange(root);
        assert.equal(selection.getRangeAt(0).toString(), "onetwo");
    });

    // ---------------------------------------------------------------------------
    // EditorList: selection preservation around restructuring
    // ---------------------------------------------------------------------------

    test("toggling a list keeps the text selection", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const p1 = el("p", "one");
        const p2 = el("p", "two");
        root.appendChild(p1);
        root.appendChild(p2);

        select(firstText(p1), 1, firstText(p2), 2);
        wx.EditorList.exec(editorMock(), "insertunorderedlist");

        assert.equal(root.innerHTML, "<ul><li>one</li><li>two</li></ul>");
        assert.equal(selection.getRangeAt(0).toString(), "netw", "the selection survives the restructuring");
    });

    test("removing a list (same type toggle) keeps the text selection", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", "alpha");
        const li2 = el("li", "beta");
        root.appendChild(el("ul", li1, li2));

        select(firstText(li1), 0, firstText(li2), 4);
        wx.EditorList.exec(editorMock(), "insertunorderedlist");

        assert.equal(root.innerHTML, "<p>alpha</p><p>beta</p>");
        assert.equal(selection.getRangeAt(0).toString(), "alphabeta");
    });

    test("switching the list type keeps the text selection", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", "alpha");
        const li2 = el("li", "beta");
        root.appendChild(el("ul", li1, li2));

        select(firstText(li1), 0, firstText(li2), 4);
        wx.EditorList.exec(editorMock(), "insertorderedlist");

        assert.equal(root.innerHTML, "<ol><li>alpha</li><li>beta</li></ol>");
        assert.equal(selection.getRangeAt(0).toString(), "alphabeta");
    });

    test("indent and outdent keep the multi-item selection", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", "one");
        const li2 = el("li", "two");
        const li3 = el("li", "three");
        root.appendChild(el("ul", li1, li2, li3));
        const editor = editorMock();

        select(firstText(li2), 0, firstText(li3), 5);
        wx.EditorList.exec(editor, "indent");

        assert.equal(root.innerHTML, "<ul><li>one<ul><li>two</li><li>three</li></ul></li></ul>");
        assert.equal(selection.getRangeAt(0).toString(), "twothree", "the selection survives the indent");

        wx.EditorList.exec(editor, "outdent");

        assert.equal(root.innerHTML, "<ul><li>one</li><li>two</li><li>three</li></ul>");
        assert.equal(selection.getRangeAt(0).toString(), "twothree", "the selection survives the outdent");
    });

    // ---------------------------------------------------------------------------
    // EditorFormat: per-block transform across list items
    // ---------------------------------------------------------------------------

    test("clear format on a selected list strips the formatting without creating empty items", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", el("b", "foo"));
        const li2 = el("li", el("i", "bar"));
        root.appendChild(el("ul", li1, li2));

        select(firstText(li1), 0, firstText(li2), 3);
        wx.EditorFormat.exec(editorMock(), "removeformat");

        assert.equal(root.innerHTML, "<ul><li>foo</li><li>bar</li></ul>", "the formatting is stripped in place");
        assert.equal(root.querySelectorAll("li").length, 2, "no empty list items appear");
        assert.equal(root.querySelectorAll("ul").length, 1, "the list is not duplicated or nested");
        assert.equal(selection.getRangeAt(0).toString(), "foobar", "the selection survives");
    });

    test("bold across list items wraps each item's text without touching the structure", () => {
        const { wx, selection, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", "foo");
        const li2 = el("li", "bar");
        root.appendChild(el("ul", li1, li2));

        select(firstText(li1), 0, firstText(li2), 3);
        wx.EditorFormat.exec(editorMock(), "bold");

        assert.equal(root.innerHTML, "<ul><li><strong>foo</strong></li><li><strong>bar</strong></li></ul>");
        assert.equal(selection.getRangeAt(0).toString(), "foobar");
    });

    test("bold on a fully bold list selection removes the formatting", () => {
        const { wx, root, el, select, editorMock } = loadEditor();
        const li1 = el("li", el("strong", "foo"));
        const li2 = el("li", el("strong", "bar"));
        root.appendChild(el("ul", li1, li2));

        select(firstText(li1), 0, firstText(li2), 3);
        wx.EditorFormat.exec(editorMock(), "bold");

        assert.equal(root.innerHTML, "<ul><li>foo</li><li>bar</li></ul>");
    });

    test("a color across two paragraphs styles each block's text separately", () => {
        const { wx, root, el, select, editorMock } = loadEditor();
        const p1 = el("p", "one");
        const p2 = el("p", "two");
        root.appendChild(p1);
        root.appendChild(p2);

        select(firstText(p1), 0, firstText(p2), 3);
        wx.EditorFormat.exec(editorMock(), "forecolor", "#ff0000");

        assert.equal(root.innerHTML,
            '<p><span style="color: #ff0000;">one</span></p>' +
            '<p><span style="color: #ff0000;">two</span></p>');
    });

    // ---------------------------------------------------------------------------
    // EditorPainter: capture and apply
    // ---------------------------------------------------------------------------

    test("the painter captures the inline wrapper chain at the selection", () => {
        const { wx, root, el, select, editorMock } = loadEditor();
        const span = el("span", "x");
        span.style.color = "red";
        const p = el("p", el("strong", span));
        root.appendChild(p);

        const t = firstText(p);
        select(t, 0, t, 1);

        const painter = new wx.EditorPainter(editorMock());
        assert.equal(painter.capture(), true);
        assert.equal(painter.isActive(), true);
        assert.deepEqual(painter._chain, [
            { tag: "strong", style: "" },
            { tag: "span", style: "color: red;" }
        ], "the chain is captured outermost first");
        assert.equal(root.classList.contains("wx-editor-painting"), true);

        painter.cancel();
        assert.equal(painter.isActive(), false);
        assert.equal(root.classList.contains("wx-editor-painting"), false);
    });

    test("the painter transfers the captured formatting to the next selection", () => {
        const { wx, root, el, select, editorMock } = loadEditor();
        const p1 = el("p", el("strong", "src"));
        const p2 = el("p", "plain");
        root.appendChild(p1);
        root.appendChild(p2);

        const painter = new wx.EditorPainter(editorMock());
        const src = firstText(p1);
        select(src, 0, src, 3);
        painter.capture();

        const target = firstText(p2);
        select(target, 0, target, 5);
        painter._applyToCurrentSelection();

        assert.equal(p2.innerHTML, "<strong>plain</strong>", "the formatting is transferred");
        assert.equal(painter.isActive(), false, "the painter disarms after one application");
    });

    test("a plain captured chain acts like clear format", () => {
        const { wx, root, el, select, editorMock } = loadEditor();
        const p = el("p", el("b", "hello"));
        root.appendChild(p);

        const t = firstText(p);
        select(t, 0, t, 5);
        wx.EditorFormat.applyChain(editorMock(), t.ownerDocument.getSelection().getRangeAt(0), []);

        assert.equal(p.innerHTML, "hello", "the existing formatting is stripped");
    });
}
