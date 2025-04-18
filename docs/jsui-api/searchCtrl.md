![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# SearchCtrl
The `SearchCtrl` control is an input field where search commands can be entered. It triggers events to signal changes in the filter and enables easy clearing of the search field using an icon.

```
   ┌──────────────────────────────┐
   │ 🔍  Placeholder Text       ✖ │
   └──────────────────────────────┘
```

## Settings
The control is configured using a `settings` object that supports the following properties:

|Setting      |Type      |Description
|-------------|----------|--------------------------------------------------
| id          | string   | The ID of the control.
| css         | string   | The CSS classes for styling the control.
| placeholder | string   | The placeholder text for the input field.
| icon        | string   | The icon class for the search symbol.

## Example Code
The following code demonstrates how to create a search field with various settings:

```javascript
const settings = {
    id: "searchField",
    css: "search-container",
    placeholder: "Suche...",
    icon: "fas fa-search"
};

const searchCtrl = new webexpress.webui.searchCtrl(settings);

$("body").append(searchCtrl.getCtrl);
```

In this example, a search field is created with a placeholder text and a search icon. The user can clear the search field by clicking on the "X" icon.

## Events
This control fires these events:

|Event                          |Callback Signature             |Description
|-------------------------------|-------------------------------|------------------------------------
|webexpress.webui.change.filter |function(filter: string): void |Triggered on Keyup: Every time the user types into the search field (keyup event), this event is fired with the current value of the input field passed as the filter parameter. This allows developers to update search results or filter data dynamically. <br><br>Triggered on Clear: When the clear button (the "X" icon) is clicked, the search field is reset to an empty string, and the event is fired with an empty filter. This clearly signifies that the search criteria have been cleared.
