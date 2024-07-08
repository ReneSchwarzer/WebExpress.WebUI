using System.Globalization;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the list control.
    /// </summary>
    public class UnitTestControlList
    {
        /// <summary>
        /// Tests a empty list.
        /// </summary>
        [Fact]
        public void EmptyList()
        {
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlList();

            Assert.Equal("<ul></ul>", control.Render(context).Trim());
        }

        /// <summary>
        /// Tests a empty list.
        /// </summary>
        [Fact]
        public void EmptyListGroup()
        {
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlList() { Layout = TypeLayoutList.Group };

            Assert.Equal("<ul class=\"list-group\"></ul>", control.Render(context).Trim());
        }

        /// <summary>
        /// Tests a list.
        /// </summary>
        [Fact]
        public void SimpleList()
        {
            var context = new WebCore.WebPage.RenderContext() { Culture = CultureInfo.CurrentCulture };
            var item = new ControlListItem(new ControlText() { Text = "abc" });
            var control = new ControlList(item);

            Assert.Equal("<ul><li><div>abc</div></li></ul>", control.Render(context).Trim());
        }
    }
}
