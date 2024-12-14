//using System.Collections.Generic;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;

//namespace WebExpress.WebUI.WebControl
//{
//    /// <summary>
//    /// Grouping of controls.
//    /// </summary>
//    public class ControlFormItemGroupColumn : ControlFormItemGroup
//    {
//        /// <summary>
//        /// Returns the percentage distribution of the columns.
//        /// </summary>
//        public ICollection<int> Distribution { get; set; } = new List<int>();

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlFormItemGroupColumn(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        ///<param name="items">The form controls.</param> 
//        public ControlFormItemGroupColumn(string id, params ControlFormItem[] items)
//            : base(id, items)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        ///<param name="items">The form controls.</param> 
//        public ControlFormItemGroupColumn(params ControlFormItem[] items)
//            : base(null, items)
//        {
//        }

//        /// <summary>
//        /// Initializes the form element.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public override void Initialize(RenderContextForm context)
//        {
//            var grpupContex = new RenderContextFormGroup(context, this);

//            foreach (var item in Items)
//            {
//                item.Initialize(grpupContex);
//            }
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContextForm context)
//        {
//            var renderContext = new RenderContextFormGroup(context, this);

//            var html = new HtmlElementTextContentDiv()
//            {
//                Id = Id,
//                Class = Css.Concatenate("form-group-horizontal", GetClasses()),
//                Style = GetStyles(),
//            };

//            var body = new HtmlElementTextContentDiv() { };

//            foreach (var item in Items)
//            {
//                var row = new HtmlElementTextContentDiv() { };

//                if (item is ControlFormItemInput input)
//                {
//                    var icon = new ControlIcon() { Icon = input?.Icon };
//                    var label = new ControlFormItemLabel(!string.IsNullOrEmpty(item.Id) ? item.Id + "_label" : string.Empty);
//                    var help = new ControlFormItemHelpText(!string.IsNullOrEmpty(item.Id) ? item.Id + "_help" : string.Empty);

//                    label.Initialize(renderContext);
//                    help.Initialize(renderContext);

//                    label.Text = I18N.Translate(input?.Label);
//                    label.FormItem = item;
//                    label.Classes.Add("me-2");
//                    help.Text = I18N.Translate(input?.Help);
//                    help.Classes.Add("ms-2");

//                    if (icon.Icon != null)
//                    {
//                        icon.Classes.Add("me-2 pt-1");

//                        row.Elements.Add(new HtmlElementTextContentDiv(icon.Render(renderContext), label.Render(renderContext)) { });
//                    }
//                    else
//                    {
//                        row.Elements.Add(new HtmlElementTextContentDiv(label.Render(renderContext)));
//                    }

//                    row.Elements.Add(new HtmlElementTextContentDiv(item.Render(renderContext)) { });

//                    if (input != null)
//                    {
//                        row.Elements.Add(new HtmlElementTextContentDiv(help.Render(renderContext)));
//                    }
//                }
//                else
//                {
//                    row.Elements.Add(new HtmlElementTextContentDiv());
//                    row.Elements.Add(item.Render(context));
//                    row.Elements.Add(new HtmlElementTextContentDiv());
//                }

//                body.Elements.Add(row);
//            }

//            html.Elements.Add(body);

//            return html;
//        }
//    }
//}
