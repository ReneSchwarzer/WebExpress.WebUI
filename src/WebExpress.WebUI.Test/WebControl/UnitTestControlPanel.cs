using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the panel control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanel
    {
        /// <summary>
        /// Tests the id property of the panel control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanel(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the direction property of the panel control.
        /// </summary>
        [Theory]
        [InlineData(TypeDirection.Default, @"<div></div>")]
        [InlineData(TypeDirection.Vertical, @"<div class=""flex-column""></div>")]
        [InlineData(TypeDirection.VerticalReverse, @"<div class=""flex-column-reverse""></div>")]
        [InlineData(TypeDirection.Horizontal, @"<div class=""flex-row""></div>")]
        [InlineData(TypeDirection.HorizontalReverse, @"<div class=""flex-row-reverse""></div>")]
        public void Direction(TypeDirection direction, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanel()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the fluid property of the panel control.
        /// </summary>
        [Theory]
        [InlineData(TypePanelContainer.Default, @"<div class=""container""></div>")]
        [InlineData(TypePanelContainer.None, @"<div></div>")]
        [InlineData(TypePanelContainer.Fluid, @"<div class=""container-fluid""></div>")]
        public void Fluid(TypePanelContainer fluid, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanel()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the add child function of the panel control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div><div></div></div>")]
        [InlineData(typeof(ControlLink), @"<div><a class=""link""></a></div>")]
        [InlineData(typeof(ControlImage), @"<div><img></div>")]
        public void AddChildren(Type child, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var childInstance = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlPanel();

            // test execution
            control.AddChild(childInstance);

            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
