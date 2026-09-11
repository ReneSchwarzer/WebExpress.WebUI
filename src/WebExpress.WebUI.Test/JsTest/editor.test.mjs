/**
 * Headless unit tests for the editor engine classes in
 * webexpress.webui.editor.js: selection preservation around list and indent
 * restructuring (EditorSelection.markRange/restoreRange, EditorList), the
 * per-block transform of the inline formatting engine (EditorFormat) - in
 * particular the clear-format-on-list regression that used to leave empty
 * list items behind - and the format painter (EditorPainter).
 *
 * The engines run against the rich DOM stub in dom-stub.editor.mjs, which
 * models live ranges and the standard extractContents semantics.
 *
 * Run with Node 18 or newer from the JsTest folder:
 *   node --test
 */

import { test } from "node:test";
import assert from "node:assert";
import vm from "node:vm";
import fs from "node:fs";
import path from "node:path";
import { fileURLToPath } from "node:url";
import { editorCases } from "./editor.cases.mjs";
import { imageCases } from "./editor.image.cases.mjs";
import { tableCases } from "./editor.table.cases.mjs";
import { createEditorDocument } from "./dom-stub.editor.mjs";

const here = path.dirname(fileURLToPath(import.meta.url));
const editorJs = path.resolve(here, "..", "..", "WebExpress.WebUI", "Assets", "js", "webexpress.webui.editor.js");

/**
 * Loads the editor sources into a fresh vm context backed by the rich DOM
 * stub. Only the namespace surface the file touches at load time is stubbed;
 * the engine classes under test are the real, shipped implementations.
 * @returns {object} The webui namespace, document, selection and helpers.
 */
function loadEditor() {
    const { document, window, selection, globals } = createEditorDocument();
    const plugins = new Map();
    const panels = new Map();

    const sandbox = {
        console,
        setTimeout,
        clearTimeout,
        ...globals,
        webexpress: {
            webui: {
                Ctrl: class { constructor(element) { this._element = element; } destroy() { } },
                Controller: { registerClass() { } },
                Event: { CHANGE_VALUE_EVENT: "wx-change-value" },
                I18N: { translate: (key) => key },
                IconSet: { resolve: (icon) => icon }
            }
        }
    };
    vm.createContext(sandbox);
    vm.runInContext(fs.readFileSync(editorJs, "utf8"), sandbox, { filename: editorJs });
    sandbox.webexpress.webui.EditorPlugins = { register(name, order, plugin) { plugins.set(name, plugin); } };
    sandbox.webexpress.webui.DialogPanels = { register(key, panel) { panels.set(panel.id, panel); } };
    sandbox.webexpress.webui.ModalSidebarPanelCtrl = class {
        show() { this.shown = true; }
        selectPage(id) { this.page = id; }
    };
    for (const asset of ["editor/media.js", "editor/table.js", "panels/webexpress.webui.panel.editor.image.js"]) {
        const filename = path.join(path.dirname(editorJs), asset);
        vm.runInContext(fs.readFileSync(filename, "utf8"), sandbox, { filename });
    }

    const root = document.createElement("div");
    document.body.appendChild(root);

    return {
        wx: sandbox.webexpress.webui,
        plugins,
        panels,
        document,
        selection,
        root,
        /** Creates an element with the given children (strings become text). */
        el(tag, ...children) {
            const node = document.createElement(tag);
            children.forEach((c) => {
                node.appendChild(typeof c === "string" ? document.createTextNode(c) : c);
            });
            return node;
        },
        /** Sets the live selection to the given boundary points. */
        select(startNode, startOffset, endNode, endOffset) {
            const range = document.createRange();
            range.setStart(startNode, startOffset);
            range.setEnd(endNode, endOffset);
            selection.removeAllRanges();
            selection.addRange(range);
            return range;
        },
        /** Minimal editor instance for the static engine entry points. */
        editorMock() {
            return {
                getEditorElement: () => root,
                _saveCurrentSelection() { },
                _syncValue() { },
                _updateUndoRedoStates() { },
                _pendingFormat: null,
                _uiContainer: null
            };
        }
    };
}

editorCases(test, assert, loadEditor);
imageCases(test, assert, loadEditor);
tableCases(test, assert, loadEditor);

test("table context icons have shipped drawings and mask rules", () => {
    const { root, plugins, editorMock } = loadEditor();
    root.innerHTML = "<table><tbody><tr><td>cell</td></tr></tbody></table>";
    const editor = editorMock();
    const css = fs.readFileSync(path.join(path.dirname(editorJs), "../css/webexpress.webui.icon.css"), "utf8");
    const items = plugins.get("table").getContextMenuItems(editor, root.querySelector("td"));
    for (const { icon } of items.filter(item => item.icon)) {
        assert.ok(fs.existsSync(path.join(path.dirname(editorJs), "../icons", icon + ".svg")), icon);
        assert.ok(css.includes(`.wx-icon-light-${icon} {`), icon);
    }
});
