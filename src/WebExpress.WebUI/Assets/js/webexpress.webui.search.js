/**
 * A field where search commands can be entered.
 * The following events are triggered:
 * - webexpress.webui.change.filter with parameter filter.
 */
webexpress.webui.searchCtrl = class extends webexpress.webui.events {
    _container = $("<span class='wx-search form-control'>");

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - placeholder The placeholder text.
     *        - icon The icon class of the search icon.
     */
    constructor(settings) {
        super();

        const id = settings.id;
        const css = settings.css;
        const placeholder = settings.placeholder ?? "";
        const icon = settings.icon ?? "fas fa-search";

        const searchIcon = $("<label><i class='" + icon + "'/></label>");
        const searchInput = $("<input type='text' placeholder='" + placeholder + "' aria-label='" + placeholder + "'/>");
        const searchClear = $("<span><i class='fas fa-times'/><span>");

        this._container.attr("id", id || "");
        
        // Trigger filter change event on keyup
        searchInput.keyup(() => { 
            this.trigger('webexpress.webui.change.filter', searchInput.val());
        });
        
        // Clear the input and trigger filter change event on click
        searchClear.click(() => {
            searchInput.val('');
            this.trigger('webexpress.webui.change.filter', '');
        });

        // Add CSS classes if provided
        if (css) {
            this._container.addClass(css);
        }
        
        // Append elements to the container
        this._container.append(searchIcon);
        this._container.append(searchInput);
        this._container.append(searchClear);
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}