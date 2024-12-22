using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.WebControl
{
    /// <summary>
    /// Abstract base class for form items.
    /// </summary>
    /// <remarks>
    /// This class provides the base functionality for form items, including properties for the name of the input field,
    /// initialization, and rendering to HTML.
    /// </remarks>
    public abstract class ControlFormItem : Control
    {
        /// <summary>
        /// Returns or sets the name of the input field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the control.</param>
        public ControlFormItem(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initializes the form element.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        public abstract void Initialize(IRenderControlFormContext renderContext);

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public abstract IHtmlNode Render(IRenderControlFormContext renderContext);

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            if (renderContext is IRenderControlFormContext formContext)
            {
                return Render(formContext);
            }

            return null;
        }
    }
}
