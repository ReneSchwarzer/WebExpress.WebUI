![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# DropDownButtonCtrl
The `DropDownButtonCtrl` control is a button with a dropdown menu that offers advanced features such as links and icons. It enables the creation of dynamic and interactive menu elements. This control can be customized with a variety of settings and options to meet the specific requirements of a web application.

```
   ┌────────────┐
   │ icon label │
   └─┬──────────┘
   ┌─┴──────────┐
   │ header     │
   │ icon label │
   │ icon label │
   ├────────────┤
   │ icon label │
   └────────────┘
```

## Settings
The control is defined through a `settings` object that contains the following properties:

|Setting |Typ    |Description
|--------|-------|-----------------------------------------------		
|id      |string |The ID of the control.
|css     |string |The CSS classes for styling the control.
|menucss |string |A CSS class for styling the popup menu.
|label   |string |The text of the control.
|icon    |string |The icon class of the control.

## Options 
The menu items are defined as an array of `option` objects with the following properties:

|Property    |Type     |Description
|------------|---------|-------------------------------
|css         |string   |The CSS class for the menu item.
|icon        |string   |The icon class for the menu item.
|color       |string   |The color of the menu item.
|label       |string   |The text of the menu item.
|url         |string   |The URL of the menu item.
|disabled    |boolean  |Indicates whether the menu item is disabled.
|onclick     |Function |The click event function for the menu item.

## Example Code
The following code demonstrates how to create a dropdown button with various options and settings:

```javascript
const options = [
    { label: "Settings", css: "dropdown-header", label: "Settings" },
    { label: "Home", url: "#home", icon: "fas fa-home", color: "text-primary", onclick: "console.log('Home clicked')" },
    { label: "Profile", url: "#profile", icon: "fas fa-user", color: "text-success" },
    { css: "dropdown-divider" },
    { label: "Logout", url: "#logout", icon: "fas fa-sign-out-alt", color: "text-danger", disabled: true }
];

const settings = {
    id: "mainDropdown",
    css: "dropdown-container",
    menucss: "menu-style",
    label: "Actions",
    icon: "fas fa-ellipsis-v"
};

const dropDownButtonCtrl = new webexpress.webui.dropDownButtonCtrl(options, settings);

$("body").append(dropDownButtonCtrl.getCtrl);
```

In this example, a `DropDownButtonCtrl` is created containing multiple menu items, including "Home," "Profile," "Logout," and a divider. Each menu item can be configured individually, including assigning icons, colors, and click event functions.

## Events
This control fires these events:

- webexpress.webui.change.value: This event is triggered when the selected value changes. The following parameters are passed:
    - Parameter value: The ID of the selected option.