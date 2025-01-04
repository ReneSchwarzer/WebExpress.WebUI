using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the chart control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlChart
    {
        /// <summary>
        /// Tests the id property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""chart-container""><canvas></div>")]
        [InlineData("id", @"<div class=""chart-container""><canvas id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text color property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorText.Default, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(TypeColorText.Primary, @"<div class=""chart-container""><canvas class=""text-primary""></div>")]
        [InlineData(TypeColorText.Secondary, @"<div class=""chart-container""><canvas class=""text-secondary""></div>")]
        [InlineData(TypeColorText.Info, @"<div class=""chart-container""><canvas class=""text-info""></div>")]
        [InlineData(TypeColorText.Success, @"<div class=""chart-container""><canvas class=""text-success""></div>")]
        [InlineData(TypeColorText.Warning, @"<div class=""chart-container""><canvas class=""text-warning""></div>")]
        [InlineData(TypeColorText.Danger, @"<div class=""chart-container""><canvas class=""text-danger""></div>")]
        [InlineData(TypeColorText.Light, @"<div class=""chart-container""><canvas class=""text-light""></div>")]
        [InlineData(TypeColorText.Dark, @"<div class=""chart-container""><canvas class=""text-dark""></div>")]
        [InlineData(TypeColorText.Muted, @"<div class=""chart-container""><canvas class=""text-muted""></div>")]
        public void TextColor(TypeColorText color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                TextColor = new PropertyColorText(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""chart-container""><canvas class=""bg-primary""></div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""chart-container""><canvas class=""bg-secondary""></div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""chart-container""><canvas class=""bg-warning""></div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""chart-container""><canvas class=""bg-danger""></div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""chart-container""><canvas class=""bg-dark""></div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""chart-container""><canvas class=""bg-light""></div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""chart-container""><canvas class=""bg-transparent""></div>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the type property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(TypeChart.Bar, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(TypeChart.Line, @"<div class=""chart-container""><canvas></div>")]
        public void Type(TypeChart type, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Type = type
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the title property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""chart-container""><canvas></div>")]
        [InlineData("Chart Title", @"<div class=""chart-container""><canvas></div>")]
        public void Title(string title, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Title = title
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the title of the x-axis property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""chart-container""><canvas></div>")]
        [InlineData("X-Axis Title", @"<div class=""chart-container""><canvas></div>")]
        public void TitleX(string titleX, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                TitleX = titleX
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the title of the y-axis property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""chart-container""><canvas></div>")]
        [InlineData("Y-Axis Title", @"<div class=""chart-container""><canvas></div>")]
        public void TitleY(string titleY, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                TitleY = titleY
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the width property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(0, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(500, @"<div class=""chart-container""><canvas width=""500"" style=""width: 500px;""></div>")]
        public void Width(int width, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Width = width
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the height property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(0, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(300, @"<div class=""chart-container""><canvas height=""300"" style=""height: 300px;""></div>")]
        public void Height(int height, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Height = height
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the minimum property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(float.MinValue, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(0f, @"<div class=""chart-container""><canvas></div>")]
        public void Minimum(float minimum, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Minimum = minimum
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the maximum property of the chart control.
        /// </summary>
        [Theory]
        [InlineData(float.MaxValue, @"<div class=""chart-container""><canvas></div>")]
        [InlineData(100f, @"<div class=""chart-container""><canvas></div>")]
        public void Maximum(float maximum, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlChart()
            {
                Maximum = maximum
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
