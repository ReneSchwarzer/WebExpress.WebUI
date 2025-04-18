/**
 * A dropdown that offers advanced features (links).
 */
webexpress.webui.moreCtrl = class {
    _container = $("<div class='dropdown'/>");

    /**
     * Constructor
     * @param options The menu items array of { css: "", icon: "", color: "", label: "", url: "", onclick: "", item: null, disabled: false}.
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - menucss A CSS class for designing the pop-up menu.
     *        - label The text.
     *        - icon The Icon class of the control.
     */
    constructor(options, settings) {
        const id = settings.id;
        const css = settings.css;
        const menuCSS = settings.menucss;
        const label = settings.label || "";
        const icon = settings.icon || "fas fa-ellipsis-h";

        const button = $("<button class='btn' type='button' data-bs-toggle='dropdown' aria-expanded='false'><i class='" + icon + " " + (label ? "me-2" : "") + "'></i><span>" + label + "</span></button>");
        const ul = $("<ul class='dropdown-menu'/>");

        if (menuCSS) {
            ul.addClass(menuCSS);
        }

        for (const option of options) {
            const label = option.label;
            const css = option.css || "dropdown-item";
            const icon = option.icon;
            const color = option.color;
            const item = option.item;
            const disabled = option.disabled ?? false;
            const url = option.url || "#";
            const onclick = option.onclick;

            const li = this.createMenuItem(option, css, icon, color, item, disabled, url, onclick);
            ul.append(li);
        }

        this._container.attr("id", id || "");
        if (css) {
            this._container.addClass(css);
        }

        this._container.append(button);
        this._container.append(ul);
    }
    
    /**
     * Creates a menu item.
     * @param {Object} option - The option for the menu item.
     * @param {string} css - The CSS class of the menu item.
     * @param {string} icon - The icon class of the menu item.
     * @param {string} color - The color of the menu item.
     * @param {Object} item - The associated element.
     * @param {boolean} disabled - Indicates whether the menu item is disabled.
     * @param {string} url - The URL of the menu item.
     * @param {Function} onclick - The click event handler.
     * @returns {jQuery} The created menu item.
     */
    createMenuItem(option, css, icon, color, item, disabled, url, onclick) {
        const li = $("<li/>").addClass(css);

        if (css === "dropdown-item") {
            if (!disabled) {
                const a = $("<a class='link " + color + "' href='#'/>");
                if (icon) {
                    a.append($("<span class='me-2 " + icon + "'/>"));
                }
                if (onclick) {
                    const func = Function("option", "item", onclick);
                    a.click((e) => { func(option, item); });
                }
                a.append($("<span href='" + url + "'>" + option.label + "</span>"));
                li.append(a);
            } else {
                const p = $("<span class='text-muted'/>");
                if (icon) {
                    p.append($("<span class='me-2 " + icon + "'/>"));
                }
                p.append(option.label);
                li.append(p).addClass("disabled");
            }
        } else if (css === "dropdown-header") {
            if (icon) {
                li.append($("<span class='me-2 " + icon + "'/>"));
            }
            li.append($("<span>" + option.label + "</span>"));
        } else if (css === "dropdown-divider") {
            // Divider
        }

        return li;
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}