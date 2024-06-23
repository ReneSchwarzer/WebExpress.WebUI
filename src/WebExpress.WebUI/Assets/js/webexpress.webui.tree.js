/**
 * A tree control.
 * The following events are triggered:
 * - webexpress.webui.change.visibility 
 */
webexpress.webui.treeCtrl = class extends webexpress.webui.events {
    _container = $("<ul class='tree'/>");
    _nodes = [];

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     */
    constructor(settings) {
        super();

        let id = settings.id ?? "";
        let css = settings.css;

        this._container.attr("id", id);
        this._container.addClass(css);
    }
    
    /**
     * Update of the control.
     * This function works recursively.
     * @param container The control.
     * @param nodes The nodes to be inserted.
     */
    update(container, nodes) {
        container.children().remove();
        
        nodes.forEach(function (node) {
            let children = node.children;
            let color = node.color ?? "";
            let li = $("<li class='tree-node'></li>");
            let expand = $("<span class='" + color + "'/>");
            let icon = $("<i class='" + (node.icon ?? "") + "'/>");
            li.append(expand);
                        
            if (children != null) {
                let ul = $("<ul/>");
                let indicator = $("<a class='tree-indicator-angle' href='#'/>");
                if (node.expand) {
                    this.update(ul, children);
                    indicator.addClass("tree-expand");
                }
                expand.append(indicator);
                li.append(ul);
                
                expand.click(function () {
                    this.trigger('webexpress.webui.change.visibility', li, node);      
                    if (!node.expand) {
                        indicator.addClass("tree-expand");
                        this.update(ul, children);
                    } else {
                        indicator.removeClass("tree-expand");
                        ul.children().remove();
                    }
                    node.expand = !node.expand;
                }.bind(this));
            } else {
                let indicator = $("<a class='tree-indicator-dot' href='#'/>");
                expand.append(indicator);
            }
            
            if (node.icon != null) {
                expand.append(icon);
            }
            
            if (node.render != null && (typeof node.render === 'string' || node.render instanceof String)) {
                let render = Function("node", node.render);
                let renderResult = render(node);
                if (renderResult != null && renderResult != null) {
                    expand.append(renderResult);
                }
            } else {
                
                expand.append($("<span>" + node.label + "</span>"));
            }
            
            container.append(li);
            
        }.bind(this));
    }
    
    /**
     * Returns the tree nodes.
     */
    get nodes() {
        return this._nodes;
    }
    
    /**
     * Set the nodes of the tree.
     * @param nodes An array with object ids {id, label, description, image, color, expand}.
     */
    set nodes(nodes) {
        this._nodes = nodes;
          
        this.update(this._container, this._nodes);
    }

    /**
     * Deletes all entries from the tree.
     */
    clear() {
        this._container.children().remove();
    }

    /**
     * Returns the control.
     */
    get getCtrl() {
        return this._container;
    }
}