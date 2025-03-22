using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a tree item control that can contain other controls and tree items.
    /// </summary>
    public class ControlTreeItem : Control
    {
        private readonly List<IControl> _content = [];
        private readonly List<ControlTreeItem> _children = [];

        /// <summary>
        /// Returns the content.
        /// </summary>
        public IEnumerable<IControl> Content => _content;

        /// <summary>
        /// Returns the child tree items.
        /// </summary>
        public IEnumerable<ControlTreeItem> Children => _children;

        /// <summary>
        /// Returns a value indicating whether any child tree item is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if any child tree item is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsAnyChildrenActive
        {
            get
            {
                if (Active == TypeActive.Active) return true;

                return Children.Where(x => x.IsAnyChildrenActive).Any();
            }
        }

        /// <summary>
        /// Returns or sets the active state of the tree item.
        /// </summary>
        /// <value>
        /// The active state of the tree item.
        /// </value>
        public TypeActive Active
        {
            get => (TypeActive)GetProperty(TypeActive.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the layout of the tree item.
        /// </summary>
        /// <value>
        /// The layout of the tree item.
        /// </value>
        public TypeLayoutTreeItem Layout
        {
            get => (TypeLayoutTreeItem)GetProperty(TypeLayoutTreeItem.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the expand state of the tree item.
        /// </summary>
        /// <value>
        /// The expand state of the tree item.
        /// </value>
        public TypeExpandTree Expand
        {
            get => (TypeExpandTree)GetProperty(TypeExpandTree.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="content">The content or child of the node.</param>
        public ControlTreeItem(string id = null, params IControl[] content)
            : base(id)
        {
            _content.AddRange(content.Where(x => x is not ControlTreeItem));
            _children.AddRange(content.Where(x => x is ControlTreeItem).Select(x => x as ControlTreeItem));
        }

        /// <summary>
        /// Adds the specified content to the tree item.
        /// </summary>
        /// <param name="content">The content to add.</param>
        public void Add(params IControl[] content)
        {
            _content.AddRange(content);
        }        /// <summary>
        /// Adds the specified content to the tree item.
        /// </summary>
        /// <param name="content">The content to add.</param>
        public void Add(IEnumerable<IControl> content)
        {
            _content.AddRange(content);
        }
        /// <summary>
        /// Adds the specified children to the tree item.
        /// </summary>
        /// <param name="content">The children to add.</param>
        public void Add(params ControlTreeItem[] children)
        {
            _children.AddRange(children);
        }

        /// <summary>
        /// Adds the specified children to the tree item.
        /// </summary>
        /// <param name="content">The children to add.</param>
        public void Add(IEnumerable<ControlTreeItem> children)
        {
            _children.AddRange(children);
        }

        /// <summary>
        /// Removes the specified content or children from the tree item.
        /// </summary>
        /// <param name="control">The content or child to remove.</param>
        public void Remove(IControl control)
        {
            if (control is ControlTreeItem)
            {
                _children.Remove(control as ControlTreeItem);

                return;
            }

            _content.Remove(control);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var content = _content.Select(x => x.Render(renderContext, visualTree)).ToArray();
            var container = default(HtmlElementTextContentDiv);

            if (Layout == TypeLayoutTreeItem.TreeView)
            {
                var expander = new HtmlElementTextSemanticsSpan
                {
                    Class = Css.Concatenate("wx-tree-treeview-expander", _children.Count > 0 ? "wx-tree-treeview-angle" : "wx-tree-treeview-dot")
                };

                if (_children.Count > 0 && Expand != TypeExpandTree.Collapse)
                {
                    expander.Class = Css.Concatenate("wx-tree-treeview-angle-down", expander.Class);
                }

                container = new HtmlElementTextContentDiv(expander, content.Length > 1 ? new HtmlElementTextContentDiv(content) : content.FirstOrDefault())
                {
                    Class = Css.Concatenate("wx-tree-treeview-container")
                };
            }
            else
            {
                container = new HtmlElementTextContentDiv(content.Length > 1 ? new HtmlElementTextContentDiv(content) : content.FirstOrDefault())
                {
                    Class = Css.Concatenate("", GetClasses()),
                };
            }

            var html = new HtmlElementTextContentLi(container)
            {
                Id = Id,
                Class = Css.Concatenate(Active.ToClass()),
                Style = GetStyles(),
                Role = Role
            };

            if (_children.Count > 0)
            {
                var children = _children.Select(x => x.Render(renderContext, visualTree)).ToList();

                switch (Layout)
                {
                    case TypeLayoutTreeItem.Horizontal:
                    case TypeLayoutTreeItem.Flush:
                    case TypeLayoutTreeItem.Group:
                        children.ForEach(x => x.AddClass("list-group-item"));
                        break;
                }

                var ul = new HtmlElementTextContentUl([.. children])
                {
                    Class = Css.Concatenate(Layout switch
                    {
                        TypeLayoutTreeItem.TreeView => "wx-tree-treeview-node",
                        TypeLayoutTreeItem.Simple => "wx-tree-simple-node",
                        _ => Layout.ToClass()
                    }, Expand.ToClass())
                };

                html.Add(ul);
            }

            return html;
        }
    }
}
