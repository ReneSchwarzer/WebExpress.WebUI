/**
 * A container for showing and hiding content.
 * The following events are triggered:
 * - webexpress.webui.change.visibility 
 */
webexpress.webui.expandCtrl = class extends webexpress.webui.events {
    _container = $("<span class='expand'>");
    _content = $("<div/>");
    _expandicon = $("<a class='wx-expand-angle me-2' href='#'/>");
    _expand = true;

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - header The headline text.
     *        - headerCss The CSS classes used to design the header.
     */
    constructor(settings) {
        const id = settings.id;
        const css = settings.css;
        const header = settings.header ?? "";
        const headerCss = settings.headerCss ?? "text-primary";

        const expandheader = $("<span>").addClass(headerCss).attr("aria-label", header).text(header);

        super();

        this._container.attr("id", id || "");

        // Toggle expand state on click of expand icon or header
        this._expandicon.click(() => {
            this.expand = !this.expand;
        });

        expandheader.click(() => {
            this.expand = !this.expand;
        });

        this._container.append(this._expandicon);
        this._container.append(expandheader);
        this._container.append(this._content);

        this.expand = true;
    }

    /**
     * Update of the control.
     */
    update() {
        this._content.toggleClass("hide");
    }

    /**
     * Determines if the control is expanded.
     */
    get expand() {
        return this._expand;
    }

    /**
     * Show or hide the control content. 
     * @param value A value that determines whether the control is expanded or closed.
     */
    set expand(value) {
        if (this._expand !== value) {
            this.trigger('webexpress.webui.change.visibility', value);
            this._expand = value;
        }

        if (this._expand) {
            this._content.removeClass("hide");
            this._expandicon.addClass("wx-expand-angle-down");
        } else {
            this._content.addClass("hide");
            this._expandicon.removeClass("wx-expand-angle-down");
        }
    }

    /**
     * Returns the contents.
     */
    get content() {
        return this._content.children();
    }

    /**
     * Sets the content.
     * @param content An array of contents.
     */
    set content(content) {
        this._content.children().remove();
        this._content.append(content);
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}