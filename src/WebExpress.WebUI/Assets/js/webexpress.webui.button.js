/**
 * A simple button.
 * The following events are triggered:
 * - webexpress.webui.click
 */
webexpress.webui.buttonCtrl = class extends webexpress.webui.events {
    _button = $("<button class='btn'/>");

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - label The text.
     *        - icon The Icon class of the control.
     *        - color The color of the control text.
     *        - disabled Indicates whether the control is disabled.
     *        - url The URL the button points to.
     *        - onclick The click event handler for the button.
     */
    constructor(settings) {
        super();
        
        const id = settings.id;
        const css = settings.css;
        const label = settings.label || "";
        const icon = settings.icon;
        const color = settings.color;
        const disabled = settings.disabled ?? false;
        const url = settings.url;
        const onclick = settings.onclick;
        
        // Create the button icon and text
        const buttonIcon = $("<i class='me-2'>").addClass(icon);
        const buttonText = $("<span>").text(label);

        let buttonContent;
        
        if (icon) {
            buttonContent = $("<div>").append(buttonIcon).append(buttonText);
        }
        else {
            buttonContent = $("<div>").append(buttonText);
        }
                
        if (url) {
            buttonContent = $("<a class='link'>").attr("href", url).append(buttonContent);
        }

        this._button.append(buttonContent);
        this._button.attr("id", id || "");

        if (css) {
            this._button.addClass(css);
        }

        if (color) {
            this._button.addClass(color);
        }

        if (disabled) {
            this._button.attr("disabled", "disabled");
        }

        if (onclick) {
            const func = Function("sender", onclick);
            this._button.click((e) => { func(this._button); });
        }

        // Trigger click event
        this._button.click(() => {
            this.trigger('webexpress.webui.click');
        });
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._button;
    }
}