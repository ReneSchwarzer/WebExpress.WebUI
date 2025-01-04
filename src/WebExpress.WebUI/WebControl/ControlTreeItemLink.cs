using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a tree item link control that can contain other controls and tree items.
    /// </summary>
    public class ControlTreeItemLink : ControlTreeItem
    {
        /// <summary>
        /// Returns or sets the target uri.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Returns or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Returns or sets the target.
        /// </summary>
        public TypeTarget Target { get; set; }

        /// <summary>
        /// Returns or sets the tooltip.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Returns or sets a tooltip text.
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the parameters for the control.
        /// </summary>
        public List<Parameter> Params { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content of the html element.</param>
        public ControlTreeItemLink(string id = null, params Control[] content)
            : base(id, content)
        {
        }

        /// <summary>
        /// Returns all local and temporary parameters.
        /// </summary>
        /// <returns>The parameters.</returns>
        public string GetParams()
        {
            var dict = new Dictionary<string, Parameter>();

            // Übernahme der Parameter des Link
            if (Params != null)
            {
                foreach (var v in Params)
                {
                    if (string.IsNullOrWhiteSpace(Uri?.ToString()))
                    {
                        if (!dict.ContainsKey(v.Key.ToLower()))
                        {
                            dict.Add(v.Key.ToLower(), v);
                        }
                        else
                        {
                            dict[v.Key.ToLower()] = v;
                        }
                    }
                }
            }

            return string.Join("&amp;", dict.Where(x => !string.IsNullOrWhiteSpace(x.Value.Value)).Select(x => x.Value.ToString()));
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var param = GetParams();

            var link = new HtmlElementTextSemanticsA(Content.Select(x => x.Render(renderContext, visualTree)).ToArray())
            {
                Id = Id,
                Class = Css.Concatenate("link tree-link", Active == TypeActive.Active ? "tree-link-active" : ""),
                Role = Role,
                Href = Uri?.ToString() + (param.Length > 0 ? "?" + param : string.Empty),
                Target = Target,
                Title = Title,
                OnClick = OnClick?.ToString()
            };

            if (Icon != null && Icon.HasIcon)
            {
                link.Add(new ControlIcon()
                {
                    Icon = Icon,
                    Margin = !string.IsNullOrWhiteSpace(Text) ? new PropertySpacingMargin
                    (
                        PropertySpacing.Space.None,
                        PropertySpacing.Space.Two,
                        PropertySpacing.Space.None,
                        PropertySpacing.Space.None
                    ) : new PropertySpacingMargin(PropertySpacing.Space.None),
                    VerticalAlignment = Icon.IsUserIcon ? TypeVerticalAlignment.TextBottom : TypeVerticalAlignment.Default
                }.Render(renderContext, visualTree));
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                link.Add(new HtmlText(Text));
            }

            if (!string.IsNullOrWhiteSpace(Tooltip))
            {
                link.AddUserAttribute("data-toggle", "tooltip");
            }

            var expander = new HtmlElementTextSemanticsSpan
            {
                Class = Css.Concatenate("tree-treeview-expander", Children.Count() > 0 ? "tree-treeview-angle" : "tree-treeview-dot")
            };

            if (Children.Count() > 0 && Expand != TypeExpandTree.Collapse)
            {
                expander.Class = Css.Concatenate("tree-treeview-angle-down", expander.Class);
            }
            var container = new HtmlElementTextContentDiv(expander, link)
            {
                Class = Css.Concatenate("tree-treeview-container")
            };

            var html = new HtmlElementTextContentLi(Layout == TypeLayoutTreeItem.TreeView ? container : link)
            {
                Id = Id,
                Class = Css.Concatenate(Layout switch
                {
                    TypeLayoutTreeItem.Group => "list-group-item-action",
                    TypeLayoutTreeItem.Flush => "list-group-item-action",
                    TypeLayoutTreeItem.Horizontal => "list-group-item-action",
                    TypeLayoutTreeItem.TreeView => "tree-item",
                    _ => ""
                }, Active.ToClass()),
                Style = GetStyles(),
                Role = Role
            };

            if (Children.Count() > 0)
            {
                var items = (from x in Children select x.Render(renderContext, visualTree)).ToList();
                var ul = new HtmlElementTextContentUl(items.ToArray())
                {
                    Class = Css.Concatenate(Layout switch
                    {
                        TypeLayoutTreeItem.TreeView => "tree-treeview-node",
                        TypeLayoutTreeItem.Simple => "tree-simple-node",
                        _ => Layout.ToClass()
                    }, Expand.ToClass())
                };

                switch (Layout)
                {
                    case TypeLayoutTreeItem.Horizontal:
                    case TypeLayoutTreeItem.Flush:
                    case TypeLayoutTreeItem.Group:
                        items.ForEach(x => x.AddClass("list-group-item"));
                        break;
                }

                html.Add(ul);
            }

            return html;
        }
    }
}
