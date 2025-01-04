using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Represents a tree control that can display hierarchical data.
    /// </summary>
    public class ControlTree : Control
    {
        private readonly List<ControlTreeItem> _nodes = [];

        /// <summary>
        /// Returns the collection of tree nodes.
        /// </summary>
        public IEnumerable<ControlTreeItem> Nodes => _nodes;

        /// <summary>
        /// Returns or sets the layout.
        /// </summary>
        public TypeLayoutTree Layout
        {
            get => (TypeLayoutTree)GetProperty(TypeLayoutTree.Default);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets a value indicating whether the tree is sorted.
        /// </summary>
        public bool Sorted { get; set; }

        /// <summary>
        /// Returns or sets a value indicating whether the tree should display a border.
        /// </summary>
        public bool ShowBorder { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="items">The tree items to be added to the control.</param>
        public ControlTree(string id = null, params ControlTreeItem[] items)
            : base(id)
        {
            _nodes.AddRange(items);
            ShowBorder = true;
        }

        /// <summary>
        /// Adds the specified tree items to the control.
        /// </summary>
        /// <param name="items">The tree items to be added.</param>
        public void Add(params ControlTreeItem[] items)
        {
            _nodes.AddRange(items);
        }
        /// <summary>
        /// Adds the specified tree items to the control.
        /// </summary>
        /// <param name="items">The tree items to be added.</param>
        public void Add(IEnumerable<ControlTreeItem> items)
        {
            _nodes.AddRange(items);
        }

        /// <summary>
        /// Removes the specified tree item from the control.
        /// </summary>
        /// <param name="item">The tree item to be removed.</param>
        public void Remove(ControlTreeItem item)
        {
            _nodes.Remove(item);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var items = (from x in Nodes select x.Render(renderContext, visualTree)).ToList();

            switch (Layout)
            {
                case TypeLayoutTree.Horizontal:
                case TypeLayoutTree.Flush:
                case TypeLayoutTree.Group:
                    items.ForEach(x => x.AddClass("list-group-item"));
                    break;
            }

            var html = new HtmlElementTextContentUl([.. items])
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            if (Layout == TypeLayoutTree.TreeView)
            {
                visualTree.AddScript("treeview", @"var toggler = document.getElementsByClassName(""tree-treeview-angle"");
                for (var i = 0; i < toggler.length; i++)
                {
                    toggler[i].addEventListener(""click"", function() {
                        this.parentElement.parentElement.querySelector("".tree-treeview-node"").classList.toggle(""tree-node-hide"");
                        this.classList.toggle(""tree-treeview-angle-down"");

                    });
            }
            ");
            }

            return html;
        }
    }
}
