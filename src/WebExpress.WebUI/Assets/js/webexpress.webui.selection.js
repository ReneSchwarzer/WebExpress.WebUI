/**
 * A selection box.
 * The following events are triggered:
 * - webexpress.webui.change.filter with parameter filter.
 * - webexpress.webui.change.value with parameter value.
 */
webexpress.webui.selectionCtrl = class extends webexpress.webui.events {
    _container = $("<span class='wx-selection form-control' />");
    _selection = $("<ul/>");
    _hidden = $("<input type='hidden'/>");
    _dropdownmenu = $("<div class='dropdown-menu'/>");
    _dropdownoptions = $("<ul/>");
    _filter = $("<input type='text'/>");
    _options = [];
    _values = []; // array with selected ids from _options.
    _placeholder = null;
    _hidedescription = false;
    _multiselect = false;
    _optionfilter = (x, y) => x?.toLowerCase().startsWith(y?.toLowerCase());

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     *        - placeholder The placeholder text.
     *        - hidedescription Disabled the description.
     *        - multiselect Allows you to select multiple items.
     */
    constructor(settings) {
        super();

        const id = settings.id;
        const name = settings.name;
        const css = settings.css;
        const hidedescription = settings.hidedescription;
        const multiselect = settings.multiselect;
        const placeholder = settings.placeholder !== undefined ? settings.placeholder : null;

        const dropdown = $("<span data-bs-toggle='dropdown' aria-expanded='false'/>");
        const expand = $("<a class='fas fa-angle-down' href='#'/>");

        this._container.attr("id", id ?? "");

        if (css != null) {
            this._container.addClass(css);
        }

        if (name != null) {
            this._hidden.attr("name", name);
        }

        if (hidedescription != null) {
            this._hidedescription = hidedescription;
        }

        if (multiselect != null) {
            this._multiselect = multiselect;
        }

        this._container.on('show.bs.dropdown', () => {
            const width = this._container.width();
            this._dropdownmenu.width(width);
        });

        this._container.on('shown.bs.dropdown', () => {
            this._filter.focus();
            this.update();
        });

        this._filter.keyup((e) => {
            const filter = this._filter.val();
            e.stopPropagation();
            this.trigger('webexpress.webui.change.filter', filter !== undefined || filter != null ? filter : "");
            this.update();
            if (this._dropdownmenu.is(":hidden")) {
                dropdown.dropdown('toggle');
            }
        });

        this._placeholder = placeholder;

        this._dropdownmenu.append(this._filter);
        this._dropdownmenu.append(this._dropdownoptions);

        dropdown.append(this._selection);
        dropdown.append(expand);

        this._container.append(dropdown);
        this._container.append(this._dropdownmenu);
        this._container.append(this._hidden);

        this.value = [];
    }

    /**
     * Update of the control.
     */
    update() {
        this._dropdownoptions.children().remove();

        this._options.forEach((option) => {
            const id = option.id ?? null;
            const label = option.label ?? null;
            if (!this._values.includes(id)) {
                if (id == null && (label == null || label == '-')) {
                    const li = $("<li class='dropdown-divider'/>");
                    this._dropdownoptions.append(li);
                } else if (id == null && label != null) {
                    const li = $("<li class='dropdown-header'>" + label + "</li>");
                    this._dropdownoptions.append(li);
                } else {
                    const description = option.description != null && option.description.length > 0 ? option.description : null;
                    const image = option.image ?? null;
                    const color = option.color ?? 'text-dark';
                    const instruction = option.instruction != null ? "<small>(" + option.instruction + ")</small>": "";
                    const li = $("<li class='dropdown-item'/>");
                    const a = $("<a class='link " + color + "' href='javascript:void(0)'>" + option.label + "</a>" + instruction);
                    const p = $("<p class='small text-muted'>" + description + "</p>");

                    if (image != null) {
                        const box = $("<span/>");
                        const span = $("<span/>");
                        const img = $("<img src='" + image + "' alt=''/>");

                        box.append(img);
                        box.append(a);
                        span.append(box);
                        if (!this._hidedescription && description != null) {
                            span.append(p);
                        }
                        li.append(span);
                    } else {
                        li.append(a);
                        if (!this._hidedescription && description != null) {
                            li.append(p);
                        }
                    }

                    li.click(() => {
                        if (!this._multiselect) {
                            this.value = [];
                        }

                        if (!this._values.includes(option.id)) {
                            const value = this.value.slice();
                            value.push(option.id);
                            this.value = value;
                            this._filter.val("");
                        }
                        this.update();
                    });

                    if (this._optionfilter(option.label, this._filter.val())) {
                        this._dropdownoptions.append(li);
                    }
                }
            }
        });

        this._selection.children("li").remove();
        this._values.forEach((value) => {
            const option = this._options.find(elem => elem.id == value);
            if (option != null) {
                const label = option.label ?? null;
                const image = option.image ?? null;
                const color = option.color ?? 'text-dark';
                const a = $("<a class='link " + color + "' href='javascript:void(0)'>" + option.label + "</a>");
                const close = $("<a class='fas fa-times' href='#'/>");
                const li = $("<li/>");

                close.click(() => {
                    this.value = this._values.filter(item => item !== value);
                });

                if (image != null) {
                    const img = $("<img src='" + image + "' alt=''/>");
                    li.append(img);
                    li.append(a);
                    li.append(close);
                    this._selection.append(li);
                } else {
                    li.append($("<span>" + label + "</span>"));
                    li.append(close);
                    this._selection.append(li);
                }
            }
        });
    }

    /**
     * Returns the options.
     */
    get options() {
        return this._options;
    }

    /**
     * Sets the options.
     * @param data An array with object ids {id, label, description, image, color, instruction}.
     */
    set options(options) {
        if (options != null) {
            // determine selected options
            let selectedOptions = this.selectedOptions;
            // remove the selected options if they are included in the new options
            selectedOptions = selectedOptions.filter(elem => !options.some(o => o.id === elem.id));
            // join the selected and the new options
            this._options = [...new Set([...options, ...selectedOptions])];
        } else {
            this._options = [];
        }
        this.update();
    }

    /**
     * Returns the selected options.
     */
    get selectedOptions() {
        return this._options.filter(elem => this.value.includes(elem.id));
    }

    /**
     * Returns the selected options.
     */
    get value() {
        return this._values;
    }

    /**
     * Sets the selected options.
     * @param values Sets the id of the selected option.
     */
    set value(values) {
        if (this._values != values) {
            this._values = values;
            this.update();
            this._hidden.val(this._values.join(';'));
            this.trigger('webexpress.webui.change.value', values);
        }
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}