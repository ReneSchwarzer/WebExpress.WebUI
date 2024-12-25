using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form panel control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemPanel
    {
        /// <summary>
        /// Tests the id property of the form panel control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemPanel(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the direction property of the form panel control.
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
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemPanel()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the fluid property of the form panel control.
        /// </summary>
        [Theory]
        [InlineData(TypePanelContainer.None, @"<div></div>")]
        [InlineData(TypePanelContainer.Default, @"<div class=""container""></div>")]
        [InlineData(TypePanelContainer.Fluid, @"<div class=""container-fluid""></div>")]
        public void Fluid(TypePanelContainer fluid, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemPanel()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add child function of the form panel control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div><div></div></div>")]
        [InlineData(typeof(ControlLink), @"<div><a class=""link""></a></div>")]
        [InlineData(typeof(ControlImage), @"<div><img></div>")]
        public void Add(Type child, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var childInstance = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlFormItemPanel();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
