using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebUri;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Two panels that can be resized by a variable splitter.
    /// </summary>
    public class ControlPanelSplit : Control
    {
        /// <summary>
        /// Returns or sets whether the splitter is horziontal or vertically oriented.
        /// </summary>
        public TypeOrientationSplit Orientation { get; set; }

        /// <summary>
        /// Returns or sets the color of the splitter.
        /// </summary>
        public PropertyColorBackground SplitterColor { get; set; } = new PropertyColorBackground(TypeColorBackground.Light);

        /// <summary>
        /// Returns or sets the width of the splitter.
        /// </summary>
        public int SplitterSize { get; set; } = 6;

        /// <summary>
        /// Returns the left or top panel in the ControlPanelSplit.
        /// </summary>
        public List<IControl> Panel1 { get; } = new List<IControl>();

        /// <summary>
        /// Returns or sets the minimum size of the left or top area in the ControlPanelSplit.
        /// </summary>
        public int Panel1MinSize { get; set; }

        /// <summary>
        /// Returns or sets the initial size of the left or top area in the ControlPanelSplit in %.
        /// </summary>
        public int Panel1InitialSize { get; set; } = -1;

        /// <summary>
        /// Returns the right or bottom pane in the ControlPanelSplit.
        /// </summary>
        public List<IControl> Panel2 { get; } = new List<IControl>();

        /// <summary>
        /// Returns or sets the minimum size of the right or bottom area in the ControlPanelSplit.
        /// </summary>
        public int Panel2MinSize { get; set; }

        /// <summary>
        /// Returns or sets the initial size of the right or bottom area in the ControlPanelSplit in %.
        /// </summary>
        public int Panel2InitialSize { get; set; } = -1;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlPanelSplit(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        /// <param name="panel1">Left or top panel controls.</param>
        /// <param name="panel2">Right or bottom panel controls.</param>
        public ControlPanelSplit(string id, Control[] panel1, Control[] panel2)
            : base(id)
        {
            Panel1.AddRange(panel1);
            Panel2.AddRange(panel2);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="panel1">Left or top panel controls.</param>
        /// <param name="panel2">Right or bottom panel controls.</param>
        public ControlPanelSplit(Control[] panel1, Control[] panel2)
            : this(null, panel1, panel2)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        public void Initialize(RenderContext context)
        {
            var module = ComponentManager.ModuleManager.GetModule(context.ApplicationContext, typeof(Module));
            if (module != null)
            {
                context.VisualTree.HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "/assets/js/split.min.js"));
            }

            Border = new PropertyBorder(true);

            var init1 = 0;
            var init2 = 0;

            if (Panel1InitialSize < 0 && Panel2InitialSize < 0)
            {
                init1 = init2 = 50;
            }
            else if (Panel1InitialSize < 0)
            {
                init1 = 100 - Panel2InitialSize;
                init2 = Panel2InitialSize;
            }
            else if (Panel2InitialSize < 0)
            {
                init1 = Panel1InitialSize;
                init2 = 100 - Panel1InitialSize;
            }

            context.VisualTree.AddScript
            (
                Id, @"Split(['#" + Id + "-p1', '#" + Id + @"-p2'], {
                    sizes: [" + init1 + "," + init2 + @"],
                    minSize: [" + Panel1MinSize + "," + Panel2MinSize + @"],
                    direction: '" + Orientation.ToString().ToLower() + @"',
                    gutter: function (index, direction) 
                    {
                        var gutter = document.createElement('div');
                        gutter.className = 'splitter splitter-' + direction + ' " + SplitterColor.ToClass() + @"';
                        gutter.style = '" + SplitterColor.ToStyle() + @"';
                        return gutter;
                    },
                    gutterSize: " + SplitterSize + @",
                });"
            );
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Initialize(context);

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Class = Css.Concatenate(Orientation == TypeOrientationSplit.Horizontal ? "d-flex split" : "split", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };

            html.Elements.Add(new HtmlElementTextContentDiv(Panel1.Select(x => x.Render(context))) { Id = $"{Id}-p1" });
            html.Elements.Add(new HtmlElementTextContentDiv(Panel2.Select(x => x.Render(context))) { Id = $"{Id}-p2" });

            return html;
        }
    }
}
