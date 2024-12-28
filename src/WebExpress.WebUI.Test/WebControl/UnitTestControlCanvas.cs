﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the canvas control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlCanvas
    {
        /// <summary>
        /// Tests the id property of the canvas control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<canvas>")]
        [InlineData("id", @"<canvas id=""id"">")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlCanvas(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the canvas control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<canvas>")]
        [InlineData(TypeColorBackground.Primary, @"<canvas class=""bg-primary"">")]
        [InlineData(TypeColorBackground.Secondary, @"<canvas class=""bg-secondary"">")]
        [InlineData(TypeColorBackground.Warning, @"<canvas class=""bg-warning"">")]
        [InlineData(TypeColorBackground.Danger, @"<canvas class=""bg-danger"">")]
        [InlineData(TypeColorBackground.Dark, @"<canvas class=""bg-dark"">")]
        [InlineData(TypeColorBackground.Light, @"<canvas class=""bg-light"">")]
        [InlineData(TypeColorBackground.Transparent, @"<canvas class=""bg-transparent"">")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlCanvas()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the width property of the canvas control.
        /// </summary>
        [Theory]
        [InlineData(TypeWidth.Default, @"<canvas>")]
        [InlineData(TypeWidth.TwentyFive, @"<canvas class=""w-25"">")]
        [InlineData(TypeWidth.Fifty, @"<canvas class=""w-50"">")]
        [InlineData(TypeWidth.SeventyFive, @"<canvas class=""w-75"">")]
        [InlineData(TypeWidth.OneHundred, @"<canvas class=""w-100"">")]
        public void Width(TypeWidth width, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlCanvas()
            {
                Width = width,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the height property of the canvas control.
        /// </summary>
        [Theory]
        [InlineData(TypeHeight.Default, @"<canvas>")]
        [InlineData(TypeHeight.TwentyFive, @"<canvas class=""h-25"">")]
        [InlineData(TypeHeight.Fifty, @"<canvas class=""h-50"">")]
        [InlineData(TypeHeight.SeventyFive, @"<canvas class=""h-75"">")]
        [InlineData(TypeHeight.OneHundred, @"<canvas class=""h-100"">")]
        public void Height(TypeHeight height, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlCanvas()
            {
                Height = height,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
