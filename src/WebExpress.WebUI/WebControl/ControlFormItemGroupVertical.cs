using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Grouping of controls in a vertical layout.
    /// </summary>
    public class ControlFormItemGroupVertical : ControlFormItemGroup
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        ///<param name="items">The form controls.</param> 
        public ControlFormItemGroupVertical(string id = null, params ControlFormItem[] items)
            : base(id, items)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public override void Initialize(IRenderControlFormContext renderContext)
        {
            var renderGroupContext = new RenderControlFormGroupContext(renderContext, this);

            foreach (var item in Items)
            {
                item.Initialize(renderGroupContext);
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
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
            };

            foreach (var item in Items)
            {
                if (item is ControlFormItemInput input)
                {
                    var icon = new ControlIcon() { Icon = input?.Icon };
                    var label = new ControlFormItemLabel(!string.IsNullOrEmpty(item.Id) ? item.Id + "_label" : string.Empty);
                    var help = new ControlFormItemHelpText(!string.IsNullOrEmpty(item.Id) ? item.Id + "_help" : string.Empty);
                    var fieldset = new HtmlElementFormFieldset() { Class = "form-group" };

                    label.Initialize(renderGroupContext);
                    help.Initialize(renderGroupContext);

                    label.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Label);
                    label.FormItem = item;
                    help.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Help);

                    if (icon.Icon != null)
                    {
                        icon.Classes.Add("me-2 pt-1");
                        fieldset.Add(new HtmlElementTextSemanticsSpan(icon.Render(renderGroupContext), label.Render(renderGroupContext))
                        {
                            Style = "display: flex;"
                        });
                    }
                    else
                    {
                        fieldset.Add(label.Render(renderGroupContext));
                    }

                    fieldset.Add(item.Render(renderGroupContext));

                    if (!string.IsNullOrWhiteSpace(input?.Help))
                    {
                        fieldset.Add(help.Render(renderGroupContext));
                    }

                    html.Add(fieldset);
                }
                else
                {
                    html.Add(item?.Render(renderGroupContext));
                }
            }

            return html;
        }
    }
}
