![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# TreeCtrl
The `TreeCtrl` control is a tree component that enables the hierarchical display of data. It supports the dynamic expanding and collapsing of nodes as well as the display of additional information for each node. The control triggers events to signal changes in visibility.

```
    ┌--------------------------------┐
    ¦ ▼  Node 1                      ¦
    ¦   ►  Node 1.1                  ¦
    ¦   ▼  Node 1.2                  ¦
    ¦      ● Node 1.2.1              ¦
    ¦ ● Node 2                       ¦
    └--------------------------------┘
```

## Settings
The control is configured using a `settings` object that supports the following properties:

|Setting  |Type    |Description
|---------|--------|-----------------------------------------------------
| id      | string | The ID of the control.
| css     | string | The CSS classes for styling the control.

## Example Code
The following code demonstrates how to create a tree control with various settings:

```javascript
const settings = {
    id: "treeCtrl"
};

const treeCtrl = new webexpress.webui.treeCtrl(settings);

treeCtrl.nodes = [
    { id: 1, label: "Node 1", children: [
        { id: 2, label: "Node 1.1" },
        { id: 3, label: "Node 1.2", children: [
            { id: 4, label: "Node 1.2.1" }
        ]}
    ]},
    { id: 5, label: "Node 2" }
];

treeCtrl.on('webexpress.webui.change.visibility', function (li, node) {
    console.log("Visibility changed for node:", node.label);
});

$("body").append(treeCtrl.getCtrl);
```

In this example, a tree control is created with an ID and CSS classes. Several nodes are added in a hierarchical structure. The user can expand or collapse nodes to display or hide their child nodes.

## Events
The control triggers the following events:

- webexpress.webui.change.visibility: This event is triggered when the visibility of a node is changed. The following parameters are passed:
    - Parameter li: The list element (li) representing the node.
    - Parameter node: The node object containing the node's data.
