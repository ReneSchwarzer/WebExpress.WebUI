﻿using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Grouping of controls with mixed form items.
    /// </summary>
    public class ControlFormItemGroupMix : ControlFormItemGroup
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        ///<param name="items">The form controls.</param> 
        public ControlFormItemGroupMix(string id = null, params ControlFormItem[] items)
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
                Class = Css.Concatenate("form-group-mix", GetClasses()),
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

                    label.Initialize(renderGroupContext);
                    help.Initialize(renderGroupContext);

                    label.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Label);
                    label.FormItem = item;
                    label.Classes.Add("me-2");
                    help.Text = I18N.Translate(renderGroupContext.Request?.Culture, input?.Help);

                    if (icon.Icon != null)
                    {
                        icon.Classes.Add("me-2 pt-1");

                        row.Add(new HtmlElementTextContentDiv(icon.Render(renderGroupContext), label.Render(renderGroupContext)));
                    }
                    else
                    {
                        row.Add(new HtmlElementTextContentDiv(label.Render(renderGroupContext)));
                    }

                    if (!string.IsNullOrWhiteSpace(input?.Help))
                    {
                        row.Add(new HtmlElementTextContentDiv(item.Render(renderGroupContext), help.Render(renderGroupContext)));
                    }
                    else
                    {
                        row.Add(new HtmlElementTextContentDiv(item.Render(renderGroupContext)));
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
