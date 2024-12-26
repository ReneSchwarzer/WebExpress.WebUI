using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

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
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemDivider(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
