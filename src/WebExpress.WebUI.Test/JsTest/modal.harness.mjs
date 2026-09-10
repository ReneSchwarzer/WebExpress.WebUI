/**
 * Models Bootstrap's cancellable lifecycle without depending on layout or timers.
 */
export function bootstrapStub() {
    const instances = new Map();
    const created = [];
    class Modal {
        constructor(element) {
            this.element = element;
            this.visible = false;
            this.disposed = false;
            instances.set(element, this);
            created.push(this);
        }
        static getInstance(element) { return instances.get(element) || null; }
        show() {
            if (this.visible) { return; }
            this.element.dispatchEvent({ type: "show.bs.modal" });
            this.visible = true;
            this.element.classList.add("show");
            this.element.dispatchEvent({ type: "shown.bs.modal" });
        }
        hide() {
            if (!this.visible) { return; }
            const event = { type: "hide.bs.modal" };
            this.element.dispatchEvent(event);
            if (event.defaultPrevented) { return; }
            this.visible = false;
            this.element.classList.remove("show");
            this.element.dispatchEvent({ type: "hidden.bs.modal" });
        }
        dispose() {
            this.disposed = true;
            instances.delete(this.element);
        }
    }
    return { Modal, created };
}

/**
 * Allows a test to inspect the UI while a service response is still outstanding.
 */
export function deferred() {
    let resolve;
    let reject;
    const promise = new Promise((done, fail) => { resolve = done; reject = fail; });
    return { promise, resolve, reject };
}

export async function settle() {
    await new Promise(resolve => setImmediate(resolve));
}
