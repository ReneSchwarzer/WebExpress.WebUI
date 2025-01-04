﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the panel flexbox control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelFlexbox
    {
        /// <summary>
        /// Tests the id property of the panel flexbox control.
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
            var control = new ControlPanelFlexbox(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the direction property of the panel flexbox control.
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
            var control = new ControlPanelFlexbox()
            {
                Direction = direction,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the fluid property of the panel flexbox control.
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
            var control = new ControlPanelFlexbox()
            {
                Fluid = fluid,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the layout property of the panel flexbox control.
        /// </summary>
        [Theory]
        [InlineData(TypeLayoutFlexbox.None, @"<div></div>")]
        [InlineData(TypeLayoutFlexbox.Default, @"<div class=""d-flex""></div>")]
        [InlineData(TypeLayoutFlexbox.Inline, @"<div class=""d-inline-flex""></div>")]
        public void Layout(TypeLayoutFlexbox layout, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelFlexbox()
            {
                Layout = layout,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the justify property of the panel flexbox control.
        /// </summary>
        [Theory]
        [InlineData(TypeJustifiedFlexbox.None, @"<div></div>")]
        [InlineData(TypeJustifiedFlexbox.Start, @"<div class=""justify-content-start""></div>")]
        [InlineData(TypeJustifiedFlexbox.Around, @"<div class=""justify-content-around""></div>")]
        [InlineData(TypeJustifiedFlexbox.Between, @"<div class=""justify-content-between""></div>")]
        [InlineData(TypeJustifiedFlexbox.End, @"<div class=""justify-content-end""></div>")]
        public void Justify(TypeJustifiedFlexbox justify, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelFlexbox()
            {
                Justify = justify,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the align property of the panel flexbox control.
        /// </summary>
        [Theory]
        [InlineData(TypeAlignFlexbox.None, @"<div></div>")]
        [InlineData(TypeAlignFlexbox.Start, @"<div class=""align-items-start""></div>")]
        [InlineData(TypeAlignFlexbox.Stretch, @"<div class=""align-items-stretch""></div>")]
        [InlineData(TypeAlignFlexbox.Baseline, @"<div class=""align-items-baseline""></div>")]
        [InlineData(TypeAlignFlexbox.End, @"<div class=""align-items-end""></div>")]
        public void Align(TypeAlignFlexbox align, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelFlexbox()
            {
                Align = align,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the wrap property of the panel flexbox control.
        /// </summary>
        [Theory]
        [InlineData(TypeWrap.None, @"<div></div>")]
        [InlineData(TypeWrap.Wrap, @"<div class=""flex-wrap""></div>")]
        [InlineData(TypeWrap.Nowrap, @"<div class=""flex-nowrap""></div>")]
        [InlineData(TypeWrap.Reverse, @"<div class=""flex-wrap-reverse""></div>")]
        public void Wrap(TypeWrap wrap, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelFlexbox()
            {
                Wrap = wrap,
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the add function of the panel flexbox control.
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
            var control = new ControlPanelFlexbox();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }
    }
}
