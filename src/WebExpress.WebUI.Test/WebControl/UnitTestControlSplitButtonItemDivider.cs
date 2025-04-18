﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlSplitButtonItemDivider(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
