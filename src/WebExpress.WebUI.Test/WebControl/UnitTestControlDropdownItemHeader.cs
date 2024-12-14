using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the dropdown control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlDropdownItemHeader
    {
        /// <summary>
        /// Tests the id property of the dropdown item header control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li class=""dropdown-header""></li>")]
        [InlineData("id", @"<li id=""id"" class=""dropdown-header""></li>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdownItemHeader(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.ToString()));
        }

        /// <summary>
        /// Tests the text property of the dropdown item header control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li class=""dropdown-header""></li>")]
        [InlineData("abc", @"<li class=""dropdown-header"">abc</li>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<li class=""dropdown-header"">WebExpress.WebUI</li>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdownItemHeader()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
