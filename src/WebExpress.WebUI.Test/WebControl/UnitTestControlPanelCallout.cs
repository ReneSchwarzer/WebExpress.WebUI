using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the panel callout control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelCallout
    {
        /// <summary>
        /// Tests the id property of the panel callout control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""callout""><div class=""callout-body""></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""callout""><div class=""callout-body""></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCallout(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the direction property of the panel callout control.
        /// </summary>
        [Theory]
        [InlineData(TypeDirection.Default, @"<div class=""callout""><div class=""callout-body""></div></div>")]
        [InlineData(TypeDirection.Vertical, @"<div class=""callout flex-column""><div class=""callout-body""></div></div>")]
        [InlineData(TypeDirection.VerticalReverse, @"<div class=""callout flex-column-reverse""><div class=""callout-body""></div></div>")]
        [InlineData(TypeDirection.Horizontal, @"<div class=""callout flex-row""><div class=""callout-body""></div></div>")]
        [InlineData(TypeDirection.HorizontalReverse, @"<div class=""callout flex-row-reverse""><div class=""callout-body""></div></div>")]
        public void Direction(TypeDirection direction, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCallout()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the fluid property of the panel callout control.
        /// </summary>
        [Theory]
        [InlineData(TypePanelContainer.None, @"<div class=""callout""><div class=""callout-body""></div></div>")]
        [InlineData(TypePanelContainer.Default, @"<div class=""callout container""><div class=""callout-body""></div></div>")]
        [InlineData(TypePanelContainer.Fluid, @"<div class=""callout container-fluid""><div class=""callout-body""></div></div>")]
        public void Fluid(TypePanelContainer fluid, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCallout()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the panel callout control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div class=""callout""><div class=""callout-body""><div></div></div></div>")]
        [InlineData(typeof(ControlLink), @"<div class=""callout""><div class=""callout-body""><a class=""link""></a></div></div>")]
        [InlineData(typeof(ControlImage), @"<div class=""callout""><div class=""callout-body""><img></div></div>")]
        public void Add(Type child, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var childInstance = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlPanelCallout();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
