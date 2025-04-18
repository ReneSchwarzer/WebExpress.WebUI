/**
 * A modular window/dialog.
 * The following events are triggered:
 * - webexpress.webui.close
 */
webexpress.webui.modalPageCtrl = class extends webexpress.webui.events {
    _uri = null;
    _container = $("<div class='modal modalpage fade' data-bs-backdrop='static' data-bs-keyboard='false' tabindex='-1' aria-hidden='true'></div>");
    
    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - close The name of the close button.
     */
    constructor(settings) {
        super();
        
        let id = settings.id;
        let close = settings.close ?? "Close";
        let uri = settings.uri ?? "";
        let dialog = $("<div class='modal-dialog modal-xl modal-dialog-scrollable'></div>");
        
        this._container.attr("id", id ?? "");
        this._uri = uri;
        
        this._container.append(dialog);

        let update = function (response) {
            let parser = new DOMParser();
            let doc = parser.parseFromString(response, 'text/html');
           
            let title = $("title", doc).text();
            let header = $("<div class='modal-header'><h5 class='modal-title'>" + title + "</h5><button type='button' class='btn-close' data-bs-dismiss='modal' aria-label='" + close + "'></button></div>");
            let body = $("<div class='modal-body'></div>");
            let footer = $("<div class='modal-footer'></div>");
            let content = $("<div class='modal-content'></div>");
            
            let main = $("#webexpress\\.webapp\\.content\\.main\\.primary", doc);
            
            body.append(main);
                        
            content.append(header);
            content.append(body);
            content.append(footer);
            dialog.append(content);
        }.bind(this);

        $(document).ready(function () {
            $.get(this._uri, function (response) {
                update(response);
            }.bind(this));
        }.bind(this));

        let modal = new bootstrap.Modal(this.getCtrl, {});

        modal.show();
    }

    /**
     * Display of the modal dialog.
     */
    show() {
        
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}