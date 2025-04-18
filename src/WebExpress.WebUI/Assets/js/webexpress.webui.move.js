/**
 * A selection box to enable options.
 * The following events are triggered:
 * - webexpress.webui.change.value with parameter value.
 */
webexpress.webui.moveCtrl = class extends webexpress.webui.events {
    _container = $("<div class='wx-move'/>");
    _selectedList = $("<ul class='list-group list-group-flush'/>");
    _availableList = $("<ul class='list-group list-group-flush'/>");
    _buttonToSelectedAll = $("<button class='btn btn-primary btn-block' type='button'/>");
    _buttonToSelected = $("<button class='btn btn-primary btn-block' type='button'/>");
    _buttonToAvailable = $("<button class='btn btn-primary btn-block' type='button'/>");
    _buttonToAvailableAll = $("<button class='btn btn-primary btn-block' type='button'/>");
    _hidden = $("<input type='hidden'/>");
    _options = [];
    _values = [];
    _selectedoptions = new Map(); // Key=Ctrl, Value=options
    _availableoptions = new Map(); // Key=Ctrl, Value=options
    
    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - name The control name.
     *        - css The CSS classes used to design the control.
     *        - header The heading { selected, available }.
     *        - buttons The button label { toselectedall, toselected, toavailable, toavailableall }.
     */
    constructor(settings) {
        super();

        const { id, name, css, header, buttons } = settings;
        const selectedContainer = $("<div class='wx-move-list'/>");
        const selectedHeader = $("<span class='text-muted'>" + header.selected + "</span>");
        const availableContainer = $("<div class='wx-move-list'/>");
        const availableHeader = $("<span class='text-muted'>" + header.available + "</span>");
        const buttonContainer = $("<div class='wx-move-button d-grid gap-2'/>");
        
        this._container.attr("id", id ?? "");

        if (css) {
            this._container.addClass(css);
        }

        if (name) {
            this._hidden.attr("name", name);
        }
        
        this._buttonToSelectedAll.html(buttons.toselectedall);
        this._buttonToSelected.html(buttons.toselected);
        this._buttonToAvailable.html(buttons.toavailable);
        this._buttonToAvailableAll.html(buttons.toavailableall);
        
        selectedContainer.append(selectedHeader);
        selectedContainer.append(this._selectedList);
        availableContainer.append(availableHeader);
        availableContainer.append(this._availableList);
        buttonContainer.append(this._buttonToSelectedAll);
        buttonContainer.append(this._buttonToSelected);
        buttonContainer.append(this._buttonToAvailable);
        buttonContainer.append(this._buttonToAvailableAll);

        // Event listeners for drag and drop functionality
        selectedContainer.on('dragenter', (e) => {
            e.preventDefault();
            this._selectedList.addClass('drag-over');
        });
        
        selectedContainer.on('dragover', (e) => {
            e.preventDefault();
            this._selectedList.addClass('drag-over');
        });
        
        selectedContainer.on('dragleave', () => {
            this._selectedList.removeClass('drag-over');
        });
        
        selectedContainer.on('drop', (e) => {
            this._selectedList.removeClass('drag-over');
            this.moveToSelected();
            e.preventDefault(); 
        });
        
        availableContainer.on('dragenter', (e) => {
            e.preventDefault();
            this._availableList.addClass('drag-over');
        });
        
        availableContainer.on('dragover', (e) => {
            e.preventDefault();
            this._availableList.addClass('drag-over');
        });
        
        availableContainer.on('dragleave', () => {
            this._availableList.removeClass('drag-over');
        });
        
        availableContainer.on('drop', (e) => {
            this._availableList.removeClass('drag-over');
            this.moveToAvailable();
            e.preventDefault();
        });
        
        this._buttonToSelectedAll.click(() => {    
            this.moveToSelectedAll();
        });

        this._buttonToSelected.click(() => {
            this.moveToSelected();
        });
        
        this._buttonToAvailableAll.click(() => {
            this.moveToAvailableAll();
        });

        this._buttonToAvailable.click(() => {  
            this.moveToAvailable();
        });
        
        this._container.append(selectedContainer);
        this._container.append(buttonContainer);
        this._container.append(availableContainer);

        if (name) {
            this._container.append(this._hidden);
        }
        
        this.update();
    }
    
    /**
     * Move all entries to the left (selected).
     */
    moveToSelectedAll() {
        this.value = this._options.map(element => element.Id);
        this.update();
    }
    
    /**
     * Moves selected entries to the left (selected).
     */
    moveToSelected() {
        this.value = this._values.concat(Array.from(this._availableoptions.entries()).filter(([key, value]) => value != null).map(([key, value]) => value.Id));
        this.update();
    }

    /**
     * Move all entries to the right (available).
     */
    moveToAvailableAll() {
        this.value = [];
        this.update();
    }

    /**
     * Moves selected entries to the right (available).
     */
    moveToAvailable() {
        this.value = this._values.filter(b => !Array.from(this._selectedoptions.entries()).filter(([key, value]) => value != null).map(([key, value]) => value.Id).includes(b));
        this.update();
    }
   
    /**
     * Update of the control.
     */
    update() {
        const values = this._values != null ? this._values : [];
        const comparison = (a, b) => a === b.Id;
        const relativeComplement = this._options.filter(b => values.every(a => !comparison(a, b)));
        const intersection = this._options.filter(b => values.includes(b.Id));
        
        this._selectedList.children().remove();
        this._availableList.children().remove();
        this._selectedoptions.clear();
        this._availableoptions.clear();

        const updateselection = () => {
            this._selectedoptions.forEach((value, key) => {
                if (value != null) {
                    key.addClass("bg-primary");
                    key.children().addClass("text-white");
                } else {
                    key.removeClass("bg-primary");
                    key.children().removeClass("text-white");
                }
            });
            this._availableoptions.forEach((value, key) => {
                if (value != null) {
                    key.addClass("bg-primary");
                    key.children().addClass("text-white");
                } else {
                    key.removeClass("bg-primary");
                    key.children().removeClass("text-white");
                }
            });
            
            if (Array.from(this._availableoptions.values()).filter(elem => elem != null).length === 0) {
                this._buttonToSelected.addClass("disabled");
                this._buttonToSelected.prop("disabled", true);
            } else {
                this._buttonToSelected.removeClass("disabled");
                this._buttonToSelected.prop("disabled", false);
            }
            
            if (Array.from(this._selectedoptions.values()).filter(elem => elem != null).length === 0) {
                this._buttonToAvailable.addClass("disabled");
                this._buttonToAvailable.prop("disabled", true);
            } else {
                this._buttonToAvailable.removeClass("disabled");
                this._buttonToAvailable.prop("disabled", false);
            }
        };

        intersection.forEach((currentValue) => {   
            const li = $("<li class='list-group-item' draggable='true'/>");
            const img = $("<img title='' src='" + currentValue.image + "' draggable='false'/>");
            const icon = $("<i class='text-primary " + currentValue.icon + "' draggable='false'/>");
            const a = $("<a class='link' href='javascript:void(0)' draggable='false'>" + currentValue.label + "</a>");
            if (currentValue.icon != null) {
                li.append(icon);
            }
            if (currentValue.image != null) {
                li.append(img);
            }
            li.append(a);
            this._selectedoptions.set(li, null);
                        
            li.click((event) => {   
                if (event.ctrlKey) {
                    if (!Array.from(this._selectedoptions.values()).some(elem => elem === currentValue)) {
                        this._selectedoptions.set(li, currentValue);
                    } else {
                        this._selectedoptions.set(li, null);
                    }
                    this._availableoptions.forEach((value, key, map) => map.set(key, null));
                } else {
                    this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                    this._selectedoptions.set(li, currentValue);
                    this._availableoptions.forEach((value, key, map) => map.set(key, null));
                }
                updateselection();
            }).dblclick(() => {  
                this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                this._selectedoptions.set(li, currentValue);
                this._availableoptions.forEach((value, key, map) => map.set(key, null));

                this.moveToAvailable();
            }).keyup((event) => { 
                if (event.keyCode === 32) {
                    if (!Array.from(this._selectedoptions.keys()).some(elem => elem === currentValue)) {
                        this._selectedoptions.set(li, currentValue);
                    } else {
                        this._selectedoptions.set(li, null);
                    }
                    this._availableoptions.forEach((value, key, map) => map.set(key, null));
                    updateselection();
                }
            });
            
            li.on('dragstart', (e) => {
                this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                this._selectedoptions.set(li, currentValue);
                this._availableoptions.forEach((value, key, map) => map.set(key, null));    
                updateselection();             
            });

            this._selectedList.append(li);
        });

        relativeComplement.forEach((currentValue) => { 
            const li = $("<li class='list-group-item' draggable='true'/>");
            const img = $("<img title='' src='" + currentValue.image + "' draggable='false'/>");
            const icon = $("<i class='text-primary " + currentValue.icon + "' draggable='false'/>");
            const a = $("<a class='link' href='javascript:void(0)' draggable='false'>" + currentValue.label + "</a>");
            if (currentValue.icon != null) {
                li.append(icon);
            }
            if (currentValue.image != null) {
                li.append(img);
            }
            li.append(a);
            this._availableoptions.set(li, null);
            
            li.click((event) => {   
                if (event.ctrlKey) {
                    if (!Array.from(this._availableoptions.values()).some(elem => elem === currentValue)) {
                        this._availableoptions.set(li, currentValue);
                    } else {
                        this._availableoptions.set(li, null);
                    }
                    this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                } else {
                    this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                    this._availableoptions.forEach((value, key, map) => map.set(key, null));
                    this._availableoptions.set(li, currentValue);
                }
                                
                updateselection();
            }).dblclick(() => {  
                this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                this._availableoptions.forEach((value, key, map) => map.set(key, null));
                this._availableoptions.set(li, currentValue);

                this.moveToSelected();
            }).keyup((event) => { 
                if (event.keyCode === 32) {
                    if (!Array.from(this._availableoptions.keys()).some(elem => elem === currentValue)) {
                        this._availableoptions.set(li, currentValue);
                    } else {
                        this._availableoptions.set(li, null);
                    }
                    this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                    updateselection();
                }
            });
            
            li.on('dragstart', (e) => {
                this._selectedoptions.forEach((value, key, map) => map.set(key, null));
                this._availableoptions.forEach((value, key, map) => map.set(key, null));
                this._availableoptions.set(li, currentValue);
                updateselection();
            });

            this._availableList.append(li);
        });
        
        if (relativeComplement.length === 0) {
            this._buttonToSelectedAll.addClass("disabled");
            this._buttonToSelectedAll.prop("disabled", true);
        } else {
            this._buttonToSelectedAll.removeClass("disabled");
            this._buttonToSelectedAll.prop("disabled", false);
        }

        if (values.length === 0) {
            this._buttonToAvailableAll.addClass("disabled");
            this._buttonToAvailableAll.prop("disabled", true);
        } else {
            this._buttonToAvailableAll.removeClass("disabled");
            this._buttonToAvailableAll.prop("disabled", false);
        }
        
        updateselection();
    }

    /**
     * Returns all options.
     */
    get options() {
        return this._options;
    }

    /**
     * Sets the options.
     * @param options An array of options { Id, Label, Icon, Image }.
     */
    set options(options) {
        this._options = options;
        this.update();
    }
    
    /**
     * Returns the selected options.
     */
    get value() {
        return this._values;
    }
    
    /**
     * Sets the selected options.
     * @param values An array with object ids.
     */
    set value(values) {
        if (this._values !== values) {
            this._values = values;
            this._hidden.val(this._values.join(';'));
            this.update();
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