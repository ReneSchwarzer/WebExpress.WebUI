using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the dropdown control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlDropdownItemDivider
    {
        /// <summary>
        /// Tests the id property of the dropdown item divider control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""dropdown-divider""></div>")]
        [InlineData("id", @"<div id=""id"" class=""dropdown-divider""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdownItemDivider(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.ToString()));
        }
    }
}
