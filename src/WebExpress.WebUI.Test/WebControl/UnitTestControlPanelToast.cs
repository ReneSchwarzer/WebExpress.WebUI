﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the toast control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelToast
    {
        /// <summary>
        /// Tests the id property of the toast control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelToast(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the toast control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div></div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""bg-primary""></div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""bg-secondary""></div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""bg-warning""></div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""bg-danger""></div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""bg-dark""></div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""bg-light""></div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""bg-transparent""></div>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelToast()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the direction property of the toast control.
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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelToast()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the fluid property of the toast control.
        /// </summary>
        [Theory]
        [InlineData(TypePanelContainer.None, @"<div></div>")]
        [InlineData(TypePanelContainer.Default, @"<div class=""container""></div>")]
        [InlineData(TypePanelContainer.Fluid, @"<div class=""container-fluid""></div>")]
        public void Fluid(TypePanelContainer fluid, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelToast()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the toast control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div><div></div></div>")]
        [InlineData(typeof(ControlLink), @"<div><a class=""link""></a></div>")]
        [InlineData(typeof(ControlImage), @"<div><img></div>")]
        public void Add(Type child, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var childInstance = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlPanelToast();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
