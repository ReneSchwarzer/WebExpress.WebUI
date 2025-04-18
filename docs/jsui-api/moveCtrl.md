![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# MoveCtrl
The `MoveCtrl` control provides a selection box to choose and move options between two lists. It triggers events to signal changes in the selected values.

## Settings
The control is configured using a `settings` object that supports the following properties:

|Setting |Type   |Description
|--------|-------|------------------------------------------------
|id      |string |The ID of the control.
|name    |string |The name of the hidden input field.
|css     |string |The CSS classes for styling the control.
|header  |object |The headers { selected, available }.
|buttons |object |The button labels { toselectedall, toselected, toavailable, toavailableall }.

## Example Code
The following code demonstrates how to create a moveCtrl control with various settings:

```javascript
const settings = {
    id: "moveCtrl",
    name: "move",
    header: {
        selected: "Selected",
        available: "Available"
    },
    buttons: {
        toselectedall: "Select All",
        toselected: "Select",
        toavailable: "Available",
        toavailableall: "Make All Available"
    }
};

const moveCtrl = new webexpress.webui.moveCtrl(settings);

moveCtrl.options = [
    { Id: 1, label: "Option 1", icon: "fas fa-check", image: "path/to/image1.jpg" },
    { Id: 2, label: "Option 2", icon: "fas fa-check", image: "path/to/image2.jpg" },
    { Id: 3, label: "Option 3", icon: "fas fa-check", image: "path/to/image3.jpg" }
];

$("body").append(moveCtrl.getCtrl);
```

In this example, a selection box is created with an ID and CSS classes. Multiple options are added that can be moved between the "Selected" and "Available" lists. Users can move options via drag-and-drop or by clicking the buttons.

## Events
This control fires these events:

|Event                         |Callback Signature         |Description
|------------------------------|---------------------------|------------------------------------
|webexpress.webui.change.value |function(value: any): void |This event is triggered when the selected values change. The value parameter contains the newly selected values.
