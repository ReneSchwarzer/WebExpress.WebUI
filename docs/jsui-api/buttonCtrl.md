![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# ButtonCtrl
The `ButtonCtrl` control is a simple button that offers advanced features like icons and text. It allows the creation of dynamic and interactive buttons. This control can be configured with a variety of settings to meet the specific requirements of a web application.

```
   ┌────────────┐
   │ icon label │
   └────────────┘
```

## Settings 
The control is configured using a `settings` object that supports the following properties:

|Setting  |Type     |Description
|---------|---------|-----------------------------------------------		
|id       |string   |The ID of the control. 
|css      |string   |The CSS classes for styling the control.
|label    |string   |The text of the control.
|icon     |string   |The icon class of the control.
|color    |string   |The color of the control.
|disabled |boolean  |Specifies whether the control is disabled.
|url      |string   |The URL the control links to.
|onclick  |function |The click event function for the control.

## Example Code
The following code demonstrates how to create a simple button with various settings:

javascript
```javascript
const settings = {
    id: "simpleButton",
    label: "Click Me",
    color: "btn-warning",   
    icon: "fas fa-hand-pointer"
};

const buttonCtrl = new webexpress.webui.buttonCtrl(settings);

$("body").append(buttonCtrl.getCtrl);
```

In this example, a button is created that includes an icon (`fas fa-hand-pointer`) and the text "Click Me". The control itself is configured using the `settings` object, which defines the ID, CSS classes, and text for the control.

## Events
The control triggers the following event:

- webexpress.webui.click: This event is triggered when the button is clicked.