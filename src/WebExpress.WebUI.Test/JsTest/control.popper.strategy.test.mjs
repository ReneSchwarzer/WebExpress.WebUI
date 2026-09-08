/**
 * The menu a PopperCtrl opens is a child of the control, so it is painted inside whatever
 * scroll box the control sits in. In a bootstrap "modal-dialog-scrollable" the body carries
 * overflow-y:auto, which clips an absolutely positioned menu at the dialog edge - the menu
 * opens but is cut off instead of overlaying the dialog. Only a fixed menu is laid out
 * against the viewport and escapes that clip.
 *
 * The DOM stub reports every dimension as zero and paints nothing, so the clipping itself
 * cannot be observed here; the positioning strategy handed to popper is the part of that
 * behaviour a layout-free DOM can be held to.
 */
import { test } from "node:test";
import assert from "node:assert";
import { loadWebUi } from "./harness.mjs";

/**
 * Builds a selection control inside a scrollable modal body and returns the options its
 * menu was positioned with.
 * @param {object} rt - The loaded runtime.
 * @returns {object} The options passed to Popper.createPopper for the menu.
 */
function popperOptionsForSelection(rt) {
    const body = rt.createElement("div");
    body.classList.add("modal-body");
    rt.document.body.appendChild(body);

    const element = rt.createElement("div");
    element.classList.add("wx-webui-input-selection");
    body.appendChild(element);

    new rt.wx.InputSelectionCtrl(element);

    const call = rt.sandbox.Popper.calls.at(-1);
    assert.ok(call, "the control positions its menu through popper");

    return call.options;
}

test("a menu opened inside a scrollable modal is not clipped by the dialog", () => {
    const rt = loadWebUi({ browser: true, extraFiles: ["webexpress.webui.input.selection.js"] });

    const options = popperOptionsForSelection(rt);

    assert.equal(options.strategy, "fixed", "an absolute menu is cut off by the modal body's overflow");
});

test("the menu still hangs under the control it belongs to", () => {
    const rt = loadWebUi({ browser: true, extraFiles: ["webexpress.webui.input.selection.js"] });

    const options = popperOptionsForSelection(rt);

    assert.equal(options.placement, "bottom-start", "escaping the clip must not move the menu off its control");

    const overflow = options.modifiers.find(m => m.name === "preventOverflow");
    assert.equal(overflow?.options?.boundary, "viewport", "a fixed menu is only kept on screen by the viewport boundary");
});
