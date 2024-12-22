using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a column group of form items.
    /// </summary>
    public class ControlFormItemGroupColumn : ControlFormItemGroup
    {
        private readonly List<int> _distribution = [];

        /// <summary>
        /// Returns the percentage distribution of the columns.
        /// </summary>
        public IEnumerable<int> Distribution => _distribution;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        ///<param name="items">The form controls.</param> 
        public ControlFormItemGroupColumn(string id = null, params ControlFormItem[] items)
            : base(id, items)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        ///<param name="items">The form controls.</param> 
        public ControlFormItemGroupColumn(params ControlFormItem[] items)
            : base(null, items)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            var grpupContex = new RenderControlFormGroupContext(renderContext, this);

            foreach (var item in Items)
            {
                item.Initialize(grpupContex);
            }
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlFormContext renderContext)
        {
            var renderGroupContext = new RenderControlFormGroupContext(renderContext, this);

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Class = Css.Concatenate("form-group-horizontal", GetClasses()),
                Style = GetStyles(),
            };

            var body = new HtmlElementTextContentDiv() { };

            foreach (var item in Items)
            {
                var row = new HtmlElementTextContentDiv() { };

                if (item is ControlFormItemInput input)
                {
                    var icon = new ControlIcon() { Icon = input?.Icon };
                    var label = new ControlFormItemLabel(!string.IsNullOrEmpty(item.Id) ? item.Id + "_label" : string.Empty);
                    var help = new ControlFormItemHelpText(!string.IsNullOrEmpty(item.Id) ? item.Id + "_help" : string.Empty);

                    label.Initialize(renderContext);
                    help.Initialize(renderContext);

                    label.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Label);
                    label.FormItem = item;
                    label.Classes.Add("me-2");
                    help.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Help);
                    help.Classes.Add("ms-2");

                    if (icon.Icon != null)
                    {
                        icon.Classes.Add("me-2 pt-1");

                        row.Add(new HtmlElementTextContentDiv(icon.Render(renderContext), label.Render(renderContext)) { });
                    }
                    else
                    {
                        row.Add(new HtmlElementTextContentDiv(label.Render(renderContext)));
                    }

                    row.Add(new HtmlElementTextContentDiv(item.Render(renderContext)) { });

                    if (input != null)
                    {
                        row.Add(new HtmlElementTextContentDiv(help.Render(renderContext)));
                    }
                }
                else
                {
                    row.Add(new HtmlElementTextContentDiv());
                    row.Add(item.Render(renderGroupContext));
                    row.Add(new HtmlElementTextContentDiv());
                }

                body.Add(row);
            }

            html.Add(body);

            return html;
        }
    }
}
