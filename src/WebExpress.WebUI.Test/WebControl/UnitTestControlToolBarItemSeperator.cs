using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the toolbar item divider control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlToolBarItemSeperator
    {
        /// <summary>
        /// Tests the id property of the toolbar item divider control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<hr>")]
        [InlineData("id", @"<hr id=""id"">")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlToolbarItemDivider(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
