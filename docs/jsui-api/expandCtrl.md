![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress.Doc/main/assets/banner.png)

# ExpandCtrl
The `ExpandCtrl` control is a container used for showing and hiding content. It allows the creation of expandable sections that can be toggled by clicking on a header or icon. The control triggers events to indicate visibility changes.

```
   ┌---------------┐
   ¦ ▼ Header Text ¦
   └---------------┘
   ┌--------------------------------┐
   ¦  Hidden Content                ¦
   └--------------------------------┘
```

## Settings
The control is configured using a `settings` object that supports the following properties:

|Setting    |Type      |Description
|-----------|----------|-----------------------------------------------------
| id        | string   | The ID of the control.
| css       | string   | The CSS classes for styling the control.
| header    | string   | The text for the header.
| headerCss | string   | The CSS classes for styling the header.

## Example Code
The following code demonstrates how to create an expandable container with various settings:

```javascript
<div class="container" id="container">
    ...
</div>
...

const ctrl1 = new webexpress.webui.expandCtrl({
    id: "c174f5ab-bba0-480e-a29c-2f8b7b87a2da",
    header: "More Options",
    css: ""
});
            
ctrl1.content = $("#container").children();

ctrl1.on('webexpress.webui.change.visibility', function (key) {
    console.log("Expand: " + key);
});

parent.append(ctrl1.getCtrl);
```

In this example, an expandable container with a header is created. The container can be toggled to show or hide its content by clicking the header or icon. 

## Events
The control triggers the following events:

- webexpress.webui.change.visibility: This event is triggered when the visibility of the content changes. The following parameters are passed:
     - Parameter isVisible: A boolean value indicating whether the content is visible (true) or not (false).