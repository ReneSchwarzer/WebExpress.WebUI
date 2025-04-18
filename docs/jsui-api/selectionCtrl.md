![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# SelectionCtrl
The `SelectionCtrl` control is a selection box that allows one or multiple options to be chosen from a dropdown list. It supports filtering options and displaying additional information for each option. The control triggers events to signal changes in the filter and selected values.

## Settings
The configuration of the control is managed through a `settings` object that includes the following attributes:

|Setting          |Type      |Description
|-----------------|----------|---------------------------------------------------
| id              | string   | The ID of the control.
| name            | string   | The name of the hidden input field.
| css             | string   | The CSS classes for styling the control.
| placeholder     | string   | The placeholder text for the filter input field.
| hidedescription | boolean  | Disables the description of the options.
| multiselect     | boolean  | Enables the selection of multiple options.

## Example Code
The following code demonstrates how to create a selection box with various settings:

```javascript
const settings = {
    id: "selectionField",
    name: "selection",
    placeholder: "Wähle eine Option...",
    hidedescription: false,
    multiselect: true
};

const selectionCtrl = new webexpress.webui.selectionCtrl(settings);

selectionCtrl.options = [
    { id: 1, label: "Option 1", description: "Beschreibung von Option 1", image: "path/to/image1.jpg", color: "text-danger" },
    { id: 2, label: "Option 2", description: "Beschreibung von Option 2", image: "path/to/image2.jpg", color: "text-success" },
    { id: 3, label: "Option 3", description: "Beschreibung von Option 3", image: "path/to/image3.jpg", color: "text-warning" }
];

$("body").append(selectionCtrl.getCtrl);
```

In this example, a selection box is created with a placeholder text and multiple choices. The user can select multiple options and clear the selection box by clicking the "X" icon.

##Events
The control triggers the following events:

- webexpress.webui.change.filter: This event is triggered when the search filter changes. The parameter filter contains the new search term.
     Parameter filter: The new search term entered into the search field.