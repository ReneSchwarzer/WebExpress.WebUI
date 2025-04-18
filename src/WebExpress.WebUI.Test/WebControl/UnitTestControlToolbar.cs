﻿
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the toolbar control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlToolbar
    {
        /// <summary>
        /// Tests the id property of the toolbar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<nav class=""px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData("id", @"<nav id=""id"" class=""px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData("03C6031F-04A9-451F-B817-EBD6D32F8B0C", @"<nav id=""03C6031F-04A9-451F-B817-EBD6D32F8B0C"" class=""px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlToolbar(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the toolbar control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<nav class=""px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Primary, @"<nav class=""bg-primary px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Secondary, @"<nav class=""bg-secondary px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Warning, @"<nav class=""bg-warning px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Danger, @"<nav class=""bg-danger px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Dark, @"<nav class=""bg-dark px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Light, @"<nav class=""bg-light px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        [InlineData(TypeColorBackground.Transparent, @"<nav class=""bg-transparent px-2 navbar-expand-sm""><ul class=""navbar-nav""></ul></nav>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlToolbar()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the toolbar control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlToolbar(null, new ControlToolbarItemButton() { Text = "abc" });

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(@"<nav class=""px-2 navbar-expand-sm""><ul class=""navbar-nav""><li class=""nav-item""><a class=""link nav-link"">abc</a></li></ul></nav>", html);
        }
    }
}
