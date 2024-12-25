using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a form item input control for selection.
    /// </summary>
    /// <remarks>
    /// This control allows users to select one or more options from a predefined list.
    /// </remarks>
    public class ControlFormItemInputSelection : ControlFormItemInput
    {
        private readonly List<ControlFormItemInputSelectionItem> _options = [];

        /// <summary>
        /// Returns the entries.
        /// </summary>
        public IEnumerable<ControlFormItemInputSelectionItem> Options => _options;

        /// <summary>
        /// Returns or sets the label of the selected options.
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Returns or sets whether to display the description of the option or hide it.
        /// </summary>
        public bool HideDescription { get; set; }

        /// <summary>
        /// Allows you to select multiple items.
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// Returns or sets the OnChange attribute.
        /// </summary>
        public PropertyOnChange OnChange { get; set; }

        /// <summary>
        /// Returns or sets the value.
        /// </summary>
        public virtual IEnumerable<string> Values => base.Value != null ? base.Value.Split(';', System.StringSplitOptions.RemoveEmptyEntries) : [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The entries.</param>
        public ControlFormItemInputSelection(string id = null, params ControlFormItemInputSelectionItem[] items)
            : base(id)
        {
            _options.AddRange(items);
        }

        /// <summary>
        /// Adds one or more items to the selection options.
        /// </summary>
        /// <param name="items">The items to add to the selection options.</param>
        public void Add(params ControlFormItemInputSelectionItem[] items)
        {
            _options.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the selection options.
        /// </summary>
        /// <param name="item">The item to remove from the selection options.</param>
        public void Remove(ControlFormItemInputSelectionItem item)
        {
            _options.Remove(item);
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            if (renderContext.Request.HasParameter(Name))
            {
                Value = renderContext?.Request.GetParameter(Name)?.Value;
            }
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            var classes = Classes.ToList();

            if (Disabled)
            {
                classes.Add("disabled");
            }

            switch (ValidationResult)
            {
                case TypesInputValidity.Warning:
                    classes.Add("input-warning");
                    break;
                case TypesInputValidity.Error:
                    classes.Add("input-error");
                    break;
            }

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Style = GetStyles()
            };

            renderContext.AddScript(Id, GetScript(Id, string.Join(" ", classes)));

            return html;
        }

        /// <summary>
        /// Checks the input element for correctness of the data.
        /// </summary>
        /// <param name="renderContext">The context in which the inputs are validated.</param>
        public override void Validate(IRenderControlFormContext renderContext)
        {
            base.Validate(renderContext);
        }

        /// <summary>
        /// Generates the javascript to control the control.
        /// </summary>
        /// <param name="id">The ID of the control.</param>
        /// <param name="css">The CSS classes that are assigned to the control.</param>
        /// <returns>The javascript code.</returns>
        protected virtual string GetScript(string id, string css)
        {
            var settings = new
            {
                id = id,
                name = Id,
                css = css,
                placeholder = Placeholder,
                hidedescription = HideDescription,
                multiselect = MultiSelect
            };

            var jsonOptions = new JsonSerializerOptions { WriteIndented = false };
            var settingsJson = JsonSerializer.Serialize(settings, jsonOptions);
            var optionsJson = JsonSerializer.Serialize(Options, jsonOptions);
            var builder = new StringBuilder();

            builder.AppendLine($"let options = {optionsJson};");
            builder.AppendLine($"let settings = {settingsJson};");
            builder.AppendLine($"let container = $('#{id}');");
            builder.AppendLine($"let obj = new webexpress.webui.selectionCtrl(settings);");
            builder.AppendLine($"obj.options = options;");
            builder.AppendLine($"obj.value = [{string.Join(",", Values.Select(x => $"'{x}'"))}];");

            if (OnChange != null)
            {
                builder.AppendLine($"obj.on('webexpress.webui.change.value', {OnChange});");
            }

            builder.AppendLine($"container.replaceWith(obj.getCtrl);");

            return builder.ToString();
        }
    }
}

