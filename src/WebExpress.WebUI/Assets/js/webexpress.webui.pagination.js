/**
 * Page navigation control.
 * The following events are triggered:
 * - webexpress.webui.change.page with parameter page.
 */
webexpress.webui.paginationCtrl = class extends webexpress.webui.events {
    _container = $("<ul class='pagination'/>");
    _currentpage = 0;
    _pagecount = 0;
    _css = "";

    /**
     * Constructor
     * @param settings Options for styling the control:
     *                - id Sets the id of the control.
     *                - css The CSS classes used to design the control.
     */
    constructor(settings) {
        super();
        
        let id = settings.id;
        this._css = settings.css;

        this._container.attr("id", id ?? "");
    }

    /**
     * Sets the page.
     * @param currentpage The page number of the current page.
     * @param pagecount The number of pages.
     */
    page(currentpage, pagecount) {
        this._currentpage = currentpage;
        this._pagecount = pagecount;
        
        let predecessor = $("<li class='page-item'><a class='page-link' href='#'><span class='fas fa-angle-left'/></a></li>");
        let successor = $("<li class='page-item'><a class='page-link' href='#'><span class='fas fa-angle-right'/></a></li>");
        function onclick(page) { 
            this.trigger('webexpress.webui.change.page', page);
        };

        this._container.addClass(this._css);
        predecessor.click(function () { this.trigger('webexpress.webui.change.page', Math.max(currentpage - 1, 0)); }.bind(this));
        successor.click(function () { this.trigger('webexpress.webui.change.page', Math.min(currentpage + 1, pagecount - 1)); }.bind(this));

        this._container.children().remove();

        if (pagecount <= 0) {
            return;
        }

        this._container.append(predecessor);

        if (pagecount < 10) {
            for (let i = 0; i < pagecount; i++) {
                let page = $("<li class='page-item'><a class='page-link' href='#'>" + (i + 1) + "</a></li>");
                page.click(function () { this.trigger('webexpress.webui.change.page', i); }.bind(this));

                if (i == currentpage) {
                    page.toggleClass("active");
                }

                this._container.append(page);
            }
        } else {
            if (currentpage <= 3) {
                for (let i = 0; i < 7; i++) {
                    let page = $("<li class='page-item'><a class='page-link' href='#'>" + (i + 1) + "</a></li>");
                    page.click(function () { this.trigger('webexpress.webui.change.page', i); }.bind(this));

                    if (i == currentpage) {
                        page.toggleClass("active");
                    }

                    this._container.append(page);
                }

                let placeholder = $("<li class='page-item disabled'><a class='page-link' href='#'>..</a></li>");
                this._container.append(placeholder);

                let lastpage = $("<li class='page-item'><a class='page-link' href='#'>" + pagecount + "</a></li>");
                lastpage.click(function () { this.trigger('webexpress.webui.change.page', pagecount - 1); }.bind(this));
                this._container.append(lastpage);

            } else if (pagecount - currentpage < 6) {
                let firstpage = $("<li class='page-item'><a class='page-link' href='#'>1</a></li>");
                firstpage.click(function () { this.trigger('webexpress.webui.change.page', 0); }.bind(this));
                this._container.append(firstpage);

                let placeholder = $("<li class='page-item disabled'><a class='page-link' href='#'>..</a></li>");
                this._container.append(placeholder);

                for (let i = pagecount - 7; i < pagecount; i++) {
                    let page = $("<li class='page-item'><a class='page-link' href='#'>" + (i + 1) + "</a></li>");
                    page.click(function () { this.trigger('webexpress.webui.change.page', i); }.bind(this));

                    if (i == currentpage) {
                        page.toggleClass("active");
                    }

                    this._container.append(page);
                }

            } else {
                let firstpage = $("<li class='page-item'><a class='page-link' href='#'>1</a></li>");
                firstpage.click(function () { this.trigger('webexpress.webui.change.page', 0); }.bind(this));
                this._container.append(firstpage);

                let placeholder = $("<li class='page-item disabled'><a class='page-link' href='#'>..</a></li>");
                this._container.append(placeholder);

                for (let i = Math.max(currentpage - 2, 0); i < Math.min(currentpage + 3, pagecount); i++) {
                    let page = $("<li class='page-item'><a class='page-link' href='#'>" + (i + 1) + "</a></li>");
                    page.click(function () { this.trigger('webexpress.webui.change.page', i); }.bind(this));

                    if (i == currentpage) {
                        page.toggleClass("active");
                    }

                    this._container.append(page);
                }

                placeholder = $("<li class='page-item disabled'><a class='page-link' href='#'>..</a></li>");
                this._container.append(placeholder);

                let lastpage = $("<li class='page-item'><a class='page-link' href='#'>" + pagecount + "</a></li>");
                lastpage.click(function () { this.trigger('webexpress.webui.change.page', pagecount - 1); }.bind(this));
                this._container.append(lastpage);
            }
        }
        
        this._container.append(successor);
    }

    /**
     * Returns the page number of the current page.
     */
    get currentpage() {
        return this._currentpage;
    }

    /**
     * Returns the number of pages.
     */
    get pagecount() {
        return this._pagecount;
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}