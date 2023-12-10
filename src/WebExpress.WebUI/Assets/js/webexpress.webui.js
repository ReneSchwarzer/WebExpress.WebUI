var webexpress = webexpress || {}
webexpress.webui = {}

webexpress.webui.events = class {
    _listeners = new Map();
    
    /**
     * Constructor
     */
    constructor() {
    }
    
    /**
     * Registers an event handler for an event.
     * @param label The event label.
     * @param callback The callback function when the event is fired.
     */
    on(label, callback) {
        this._listeners.has(label) || this._listeners.set(label, []);
        this._listeners.get(label).push(callback);
    }

    /**
     * Fire an event.
     * @param label The event label.
     * @param args The arguments.
     */
    trigger(label, ...args) {
        let res = false;

        let _trigger = (inListener, label, ...args) => {
            let listeners = inListener.get(label);
            if (listeners && listeners.length) {
                listeners.forEach((listener) => {
                    listener(...args);
                });
                res = true;
            }
        };
        _trigger(this._listeners, label, ...args);

        return res;
    }
}