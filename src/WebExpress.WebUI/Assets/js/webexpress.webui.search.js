/**
 * Ein Feld, inden Suchbefehle eingegeben werden können.
 * Folgende Events werden ausgelöst:
 * - webexpress.webui.change.filter mit Parameter filter
 */
webexpress.webui.searchCtrl = class extends webexpress.webui.events {
    _container = $("<span class='search form-control'>");

    /**
     * Constructor
     * @param settings Optionen zur Gestaltung des Steuerelementes
     *        - id Returns or sets the id. des Steuerelements
     *        - css CSS-Klasse zur Gestaltung des Steuerelementes
     *        - placeholder Der Platzhaltertext
     *        - icon Die Icon-Klasse des Suchsymbols
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
     * Gibt das Steuerelement zurück
     */
    get getCtrl() {
        return this._container;
    }
}