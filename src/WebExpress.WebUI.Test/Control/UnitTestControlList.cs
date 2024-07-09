using System.Globalization;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the list control.
    /// </summary>
    public class UnitTestControlList : IClassFixture<UnitTestControlFixture>
    {
        /// <summary>
        /// Returns the log.
        /// </summary>
        protected ITestOutputHelper Output { get; private set; }

        /// <summary>
        /// Returns the test context.
        /// </summary>
        protected UnitTestControlFixture Fixture { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixture">The log.</param>
        /// <param name="output">The test context.</param>
        public UnitTestControlList(UnitTestControlFixture fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            Output = output;
        }

        /// <summary>
        /// Tests a empty list.
        /// </summary>
        [Fact]
        public void EmptyList()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlList();

            // test execution
            Assert.Equal("<ul></ul>", control.Render(context).Trim());
        }

        /// <summary>
        /// Tests a empty list.
        /// </summary>
        [Fact]
        public void EmptyListGroup()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlList() { Layout = TypeLayoutList.Group };

            // test execution
            Assert.Equal("<ul class=\"list-group\"></ul>", control.Render(context).Trim());
        }

        /// <summary>
        /// Tests a list.
        /// The list elements are added during rendering.
        /// </summary>
        [Fact]
        public void SimpleListAtRender()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext() { Culture = CultureInfo.CurrentCulture };
            var item = new ControlListItem(new ControlText() { Text = "abc" });
            var control = new ControlList();

            // test execution
            Assert.Equal("<ul><li><div>abc</div></li></ul>", control.Render(context, [item]).Trim());
        }

        /// <summary>
        /// Tests a list.
        /// The list elements are added using add.
        /// </summary>
        [Fact]
        public void SimpleListAtInstancing()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext() { Culture = CultureInfo.CurrentCulture };
            var item = new ControlListItem(new ControlText() { Text = "abc" });
            var control = new ControlList(item);

            // test execution
            Assert.Equal("<ul><li><div>abc</div></li></ul>", control.Render(context).Trim());
        }

        /// <summary>
        /// Tests a list.
        /// The list elements are added using add.
        /// </summary>
        [Fact]
        public void SimpleListAtAdd()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext() { Culture = CultureInfo.CurrentCulture };
            var item = new ControlListItem(new ControlText() { Text = "abc" });
            var control = new ControlList();

            control.Add(item);

            // test execution
            Assert.Equal("<ul><li><div>abc</div></li></ul>", control.Render(context).Trim());
        }
    }
}
