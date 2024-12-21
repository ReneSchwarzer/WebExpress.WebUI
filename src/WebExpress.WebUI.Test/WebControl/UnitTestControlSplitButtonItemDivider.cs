using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the split button item divider control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlSplitButtonItemDivider
    {
        /// <summary>
        /// Tests the id property of the split button item divider control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""dropdown-divider""></div>")]
        [InlineData("id", @"<div id=""id"" class=""dropdown-divider""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButtonItemDivider(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
