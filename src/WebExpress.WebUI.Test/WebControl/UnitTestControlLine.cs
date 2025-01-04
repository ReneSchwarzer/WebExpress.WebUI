﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the image control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlLine
    {
        /// <summary>
        /// Tests the id property of the line control.
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
            var control = new ControlLine(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the color property of the line control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorLine.Default, @"<hr>")]
        [InlineData(TypeColorLine.Primary, @"<hr class=""bg-primary"">")]
        [InlineData(TypeColorLine.Secondary, @"<hr class=""bg-secondary"">")]
        [InlineData(TypeColorLine.Info, @"<hr class=""bg-info"">")]
        [InlineData(TypeColorLine.Warning, @"<hr class=""bg-warning"">")]
        [InlineData(TypeColorLine.Danger, @"<hr class=""bg-danger"">")]
        [InlineData(TypeColorLine.Light, @"<hr class=""bg-light"">")]
        [InlineData(TypeColorLine.Dark, @"<hr class=""bg-dark"">")]
        public void Color(TypeColorLine color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlLine()
            {
                Color = new PropertyColorLine(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }
    }
}
