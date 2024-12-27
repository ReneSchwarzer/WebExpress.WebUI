using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the tool panel control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelTool
    {
        /// <summary>
        /// Tests the id property of the tool panel control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""toolpanel border""><div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div><div></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""toolpanel border""><div class=""dropdown"">*</div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelTool(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the direction property of the tool panel control.
        /// </summary>
        [Theory]
        [InlineData(TypeDirection.Default, @"<div class=""toolpanel border""><div class=""dropdown"">*</div>")]
        [InlineData(TypeDirection.Vertical, @"<div class=""toolpanel border flex-column"">*</div>")]
        [InlineData(TypeDirection.VerticalReverse, @"<div class=""toolpanel border flex-column-reverse"">*</div>")]
        [InlineData(TypeDirection.Horizontal, @"<div class=""toolpanel border flex-row"">*</div>")]
        [InlineData(TypeDirection.HorizontalReverse, @"<div class=""toolpanel border flex-row-reverse"">*</div>")]
        public void Direction(TypeDirection direction, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelTool()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the fluid property of the tool panel control.
        /// </summary>
        [Theory]
        [InlineData(TypePanelContainer.None, @"<div class=""toolpanel border""><div class=""dropdown"">*</div>")]
        [InlineData(TypePanelContainer.Default, @"<div class=""toolpanel border container"">*</div>")]
        [InlineData(TypePanelContainer.Fluid, @"<div class=""toolpanel border container-fluid"">*</div>")]
        public void Fluid(TypePanelContainer fluid, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelTool()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the tools property of the tool panel control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""toolpanel border""><div class=""dropdown"">*</div>")]
        [InlineData("abc", @"<div class=""toolpanel border""><div class=""dropdown"">*<a class=""link"">abc</a>*</div>")]
        [InlineData("webexpress.webui:plugin.name", @"<div class=""toolpanel border""><div class=""dropdown"">*<a class=""link"">WebExpress.WebUI</a>*</div>")]
        public void Tools(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var childInstance = new ControlDropdownItemLink() { Text = text };
            var control = new ControlPanelTool()
            {
            };

            // test execution
            control.Tools.Add(childInstance);
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the tool panel control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div class=""toolpanel border""><div class=""dropdown"">*</div>")]
        [InlineData(typeof(ControlLink), @"<div class=""toolpanel border""><div class=""dropdown"">*<a class=""link""></a>*</div>")]
        [InlineData(typeof(ControlImage), @"<div class=""toolpanel border""><div class=""dropdown"">*<img>*</div>")]
        public void Add(Type child, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var childInstance = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlPanelTool();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
