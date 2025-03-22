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
        
        let id = settings.id;
        let css = settings.css;
        let placeholder = settings.placeholder != null ? settings.placeholder : "";
        let icon = settings.icon != null ? settings.icon : "fas fa-search";

        let searchicon = $("<label><i class='" + icon + "'/></label>");
        let searchinput = $("<input type='text' placeholder='" + placeholder + "' aria-label='" + placeholder + "'/>");
        let searchappend = $("<span><i class='fas fa-times'/><span>");

        this._container.attr("id", id ?? "");
        
        searchinput.keyup(function () { 
            this.trigger('webexpress.webui.change.filter', searchinput.val());
            
        }.bind(this));
        
        searchappend.click(function () {
            searchinput.val('');
            this.trigger('webexpress.webui.change.filter', '');
        }.bind(this));

        this._container.addClass(css);
        
        this._container.append(searchicon);
        this._container.append(searchinput);
        this._container.append(searchappend);
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}