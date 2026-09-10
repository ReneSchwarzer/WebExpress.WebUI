import { test } from "node:test";
import assert from "node:assert/strict";
import { loadWebUi } from "./harness.mjs";
import { bootstrapStub, deferred, settle } from "./modal.harness.mjs";

function setup() {
    const bootstrap = bootstrapStub();
    const rt = loadWebUi({ browser: true, globals: { bootstrap }, extraFiles: [
        "i18n/en.js", "webexpress.webui.modal.js", "webexpress.webui.modal.confirm.js"
    ] });
    return { ...rt, bootstrap, modal: new rt.wx.ModalConfirm() };
}

function confirm(modal) {
    return modal._confirmButton.onclick();
}

test("confirmation treats titles and messages as text and preserves the modal header controls", () => {
    const { modal } = setup();
    const value = '<img src=x onerror="bad()"> & <b>Tab</b>';
    modal.confirmation(value, value, () => {});
    assert.equal(modal._titleH1.textContent, value);
    assert.equal(modal._titleH1.parentNode, modal._headerDiv);
    assert.equal(modal._bodyDiv.querySelector("p").textContent, value);
    assert.equal(modal._headerDiv.querySelectorAll("button").length, 2);
    assert.equal(modal._element.getAttribute("aria-labelledby"), modal._titleH1.id);
});

test("confirmation waits for async success and ignores duplicate clicks and dismissal while pending", async () => {
    const { modal, bootstrap } = setup();
    const request = deferred();
    let calls = 0;
    modal.confirmation("Delete?", "Tab A", () => { calls++; return request.promise; });
    modal.show();
    const first = confirm(modal);
    const second = confirm(modal);
    bootstrap.Modal.getInstance(modal._element).hide();
    assert.equal(calls, 1);
    assert.equal(modal._confirmButton.disabled, true);
    assert.equal(bootstrap.Modal.getInstance(modal._element).visible, true);
    request.resolve(true);
    await Promise.all([first, second]);
    assert.equal(bootstrap.Modal.getInstance(modal._element).visible, false);
});

test("a failed confirmation stays open with an accessible error and permits retry", async () => {
    const { modal, bootstrap } = setup();
    let success = false;
    modal.confirmation("Delete?", "Tab A", () => success, { errorMessage: "Deletion failed." });
    modal.show();
    await confirm(modal);
    assert.equal(bootstrap.Modal.getInstance(modal._element).visible, true);
    assert.equal(modal._bodyDiv.querySelector('[role="alert"]').textContent, "Deletion failed.");
    assert.equal(modal._confirmButton.disabled, false);
    success = true;
    await confirm(modal);
    assert.equal(bootstrap.Modal.getInstance(modal._element).visible, false);
});

test("a rejected action releases the confirmation lock and shows the configured error", async () => {
    const { modal } = setup();
    modal.confirmation("Delete?", "Tab A", async () => { throw new Error("network"); }, { errorMessage: "Try again." });
    modal.show();
    await confirm(modal);
    assert.equal(modal._confirmButton.disabled, false);
    assert.equal(modal._bodyDiv.querySelector('[role="alert"]').textContent, "Try again.");
});

test("reusing a modal retains one Bootstrap instance and emits one hide event per dismissal", () => {
    const { modal, bootstrap, wx } = setup();
    let hidden = 0;
    modal._element.addEventListener(wx.Event.MODAL_HIDE_EVENT, () => hidden++);
    for (let i = 0; i < 3; i++) {
        modal.confirmation("Delete?", "Tab A", () => {});
        modal.show();
        modal._cancelButton.click();
    }
    assert.equal(bootstrap.created.length, 1);
    assert.equal(hidden, 3);
    modal.show();
    bootstrap.Modal.getInstance(modal._element).hide();
    assert.equal(hidden, 4, "Escape also emits the framework hide event");
});

test("destroying an open confirmation disposes its dialog even during an outstanding action", async () => {
    const { modal, bootstrap } = setup();
    const request = deferred();
    modal.confirmation("Delete?", "Tab A", () => request.promise);
    modal.show();
    const action = confirm(modal);
    const instance = bootstrap.Modal.getInstance(modal._element);
    modal.destroy();
    assert.equal(instance.disposed, true);
    assert.equal(modal._element.parentNode, null);
    request.resolve(true);
    await action;
    await settle();
    assert.equal(bootstrap.created.length, 1);
});

test("opening transitions prevent premature confirmation and allow deferred teardown", async () => {
    const { modal, bootstrap } = setup();
    bootstrap.Modal.prototype.show = function () {
        this.element.dispatchEvent({ type: "show.bs.modal" });
        this.element.classList.add("show");
        this.visible = true;
    };
    let calls = 0;
    modal.confirmation("Delete?", "Tab A", () => calls++);
    modal.show();
    await confirm(modal);
    assert.equal(calls, 0);
    assert.equal(modal._confirmButton.disabled, true);
    const instance = bootstrap.Modal.getInstance(modal._element);
    modal.destroy();
    assert.equal(instance.disposed, false, "Bootstrap still owns an opening transition");
    modal._element.dispatchEvent({ type: "shown.bs.modal" });
    assert.equal(instance.disposed, true);
    assert.equal(modal._element.parentNode, null);
});

test("an open confirmation cannot be retargeted to a different destructive action", async () => {
    const { modal } = setup();
    const calls = [];
    modal.confirmation("Delete?", "Tab A", () => calls.push("a"));
    modal.show();
    assert.equal(modal.confirmation("Delete?", "Tab B", () => calls.push("b")), false);
    await confirm(modal);
    assert.deepEqual(calls, ["a"]);
});

test("confirmation restores focus to the caller or its surviving fallback", async () => {
    const { modal, document, createElement } = setup();
    const trigger = createElement("button");
    const fallback = createElement("button");
    document.body.appendChild(trigger);
    document.body.appendChild(fallback);
    const focused = [];
    trigger.focus = options => focused.push(["trigger", options.preventScroll]);
    fallback.focus = options => focused.push(["fallback", options.preventScroll]);
    document.activeElement = trigger;
    modal.confirmation("Delete?", "Tab A", () => {}, { fallbackFocus: () => fallback });
    modal.show();
    modal.hide();
    assert.deepEqual(focused, [["trigger", true]]);
    modal.confirmation("Delete?", "Tab A", () => trigger.remove(), { fallbackFocus: () => fallback });
    modal.show();
    await confirm(modal);
    assert.deepEqual(focused, [["trigger", true], ["fallback", true]]);
});

test("leaving fullscreen preserves Bootstrap's scroll lock and handles an unspecified modal size", () => {
    const { modal, document } = setup();
    document.body.classList.add("modal-open");
    modal.toggleFullscreen();
    modal.toggleFullscreen();
    assert.equal(modal._dialogDiv.classList.contains("modal-fullscreen"), false);
    assert.equal(modal._dialogDiv.classList.contains(""), false);
    assert.equal(document.body.classList.contains("modal-open"), true);
    assert.equal(modal._fullscreenButton.getAttribute("aria-pressed"), "false");
});
