using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the tag control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTag
    {
        /// <summary>
        /// Tests the id property of the tag control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<span class=""badge badge-pill""></span>")]
        [InlineData("id", @"<span id=""id"" class=""badge badge-pill""></span>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTag(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the tag control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<span class=""badge badge-pill""></span>")]
        [InlineData("abc", @"<span class=""badge badge-pill"">abc</span>")]
        [InlineData("webexpress.webui:plugin.name", @"<span class=""badge badge-pill"">WebExpress.WebUI</span>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTag()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the pill property of the tag control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<span class=""badge""></span>")]
        [InlineData(true, @"<span class=""badge badge-pill""></span>")]
        public void Pill(bool pill, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTag()
            {
                Pill = pill
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the layout property of the tag control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackgroundBadge.Default, @"<span class=""badge badge-pill""></span>")]
        [InlineData(TypeColorBackgroundBadge.Primary, @"<span class=""badge badge-pill bg-primary""></span>")]
        [InlineData(TypeColorBackgroundBadge.Secondary, @"<span class=""badge badge-pill bg-secondary""></span>")]
        [InlineData(TypeColorBackgroundBadge.Info, @"<span class=""badge badge-pill bg-info""></span>")]
        [InlineData(TypeColorBackgroundBadge.Success, @"<span class=""badge badge-pill bg-success""></span>")]
        [InlineData(TypeColorBackgroundBadge.Warning, @"<span class=""badge badge-pill bg-warning""></span>")]
        [InlineData(TypeColorBackgroundBadge.Danger, @"<span class=""badge badge-pill bg-danger""></span>")]
        [InlineData(TypeColorBackgroundBadge.Light, @"<span class=""badge badge-pill bg-light""></span>")]
        [InlineData(TypeColorBackgroundBadge.Dark, @"<span class=""badge badge-pill bg-dark""></span>")]
        public void Layout(TypeColorBackgroundBadge layout, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTag()
            {
                Layout = new PropertyColorBackgroundBadge(layout)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
