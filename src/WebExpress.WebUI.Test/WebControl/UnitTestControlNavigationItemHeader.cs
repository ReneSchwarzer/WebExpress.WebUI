﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the navigation item header control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlNavigationItemHeader
    {
        /// <summary>
        /// Tests the id property of the navigation item header control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li class=""dropdown-header""></li>")]
        [InlineData("id", @"<li id=""id"" class=""dropdown-header""></li>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemHeader(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the navigation item header control.
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
            var control = new ControlNavigationItemHeader()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
