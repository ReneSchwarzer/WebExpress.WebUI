/**
 * A tree control.
 * The following events are triggered:
 * - webexpress.webui.change.visibility 
 */
webexpress.webui.treeCtrl = class extends webexpress.webui.events {
    _container = $("<ul class='wx-tree'/>");
    _nodes = [];

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The CSS classes used to design the control.
     */
    constructor(settings) {
        super();

        const id = settings.id ?? "";
        const css = settings.css;

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
        // Clear existing children
        container.children().remove();
        
        nodes.forEach((node) => {
            const children = node.children;
            const color = node.color ?? "";
            const li = $("<li class='wx-tree-node'></li>");
            const expand = $("<span class='" + color + "'/>");
            const icon = $("<i class='" + (node.icon ?? "") + "'/>");
            li.append(expand);
                        
            if (children != null) {
                const ul = $("<ul/>");
                const indicator = $("<a class='wx-tree-indicator-angle' href='#'/>");
                if (node.expand) {
                    this.update(ul, children);
                    indicator.addClass("wx-tree-expand");
                }
                expand.append(indicator);
                li.append(ul);
                
                expand.click(() => {
                    this.trigger('webexpress.webui.change.visibility', li, node);      
                    if (!node.expand) {
                        indicator.addClass("wx-tree-expand");
                        this.update(ul, children);
                    } else {
                        indicator.removeClass("wx-tree-expand");
                        ul.children().remove();
                    }
                    node.expand = !node.expand;
                });
            } else {
                const indicator = $("<a class='wx-tree-indicator-dot' href='#'/>");
                expand.append(indicator);
            }
            
            if (node.icon != null) {
                expand.append(icon);
            }
            
            if (typeof node.render === 'string' || node.render instanceof String) {
                const render = new Function("node", node.render);
                const renderResult = render(node);
                if (renderResult != null) {
                    expand.append(renderResult);
                }
            } else {
                expand.append($("<span>" + node.label + "</span>"));
            }
            
            container.append(li);
        });
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