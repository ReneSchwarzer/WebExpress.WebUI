//using System.Linq;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;

//namespace WebExpress.WebUI.WebControl
//{
//    public class ControlDropdownItemLink : ControlLink, IControlDropdownItem
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id of the control.</param>
//        public ControlDropdownItemLink(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(IRenderContext context)
//        {
//            var param = ""; // GetParams(context?.Page);

//            var html = new HtmlElementTextSemanticsA(from x in Content select x.Render(context))
//            {
//                Id = Id,
//                Class = Css.Concatenate("link", GetClasses()),
//                Style = GetStyles(),
//                Role = Role,
//                Href = Uri?.ToString() + (param.Length > 0 ? "?" + param : string.Empty),
//                Target = Target,
//                Title = I18N.Translate(Title),
//                OnClick = OnClick?.ToString()
//            };

//            if (Icon != null && Icon.HasIcon)
//            {
//                html.Elements.Add(new ControlIcon()
//                {
//                    Icon = Icon,
//                    Margin = !string.IsNullOrWhiteSpace(Text) ? new PropertySpacingMargin
//                    (
//                        PropertySpacing.Space.None,
//                        PropertySpacing.Space.Two,
//                        PropertySpacing.Space.None,
//                        PropertySpacing.Space.None
//                    ) : new PropertySpacingMargin(PropertySpacing.Space.None)
//                }.Render(context));
//            }

//            if (!string.IsNullOrWhiteSpace(Text))
//            {
//                html.Elements.Add(new HtmlText(I18N.Translate(context.Culture, Text)));
//            }

//            if (Modal == null || Modal.Type == TypeModal.None)
//            {

//            }
//            else if (Modal.Type == TypeModal.Form)
//            {
//                html.OnClick = $"new webexpress.webui.modalFormCtrl({{ close: '{I18N.Translate(context.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
//                html.Href = "#";
//            }
//            else if (Modal.Type == TypeModal.Brwoser)
//            {
//                html.OnClick = $"new webexpress.webui.modalPageCtrl({{ close: '{I18N.Translate(context.Culture, "webexpress.webui:form.cancel.label")}', uri: '{Modal.Uri?.ToString() ?? html.Href}', size: '{Modal.Size.ToString().ToLower()}', redirect: '{Modal.RedirectUri}'}});";
//                html.Href = "#";
//            }
//            else if (Modal.Type == TypeModal.Modal)
//            {
//                html.AddUserAttribute("data-bs-toggle", "modal");
//                html.AddUserAttribute("data-bs-target", "#" + Modal.Modal.Id);
//            }

//            if (!string.IsNullOrWhiteSpace(Tooltip))
//            {
//                html.AddUserAttribute("data-bs-toggle", "tooltip");
//            }

//            return html;
//        }
//    }
//}
