﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the multiple progress bar control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlMultipleProgressBar
    {
        /// <summary>
        /// Tests the id property of the multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<progress min=""0"" max=""100"" value=""0"">0%</progress>")]
        [InlineData("id", @"<progress id=""id"" min=""0"" max=""100"" value=""0"">0%</progress>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlMultipleProgressBar(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the format property of the multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(TypeFormatProgress.Default, @"<progress min=""0"" max=""100"" value=""0"">0%</progress>")]
        [InlineData(TypeFormatProgress.Colored, @"<div class=""progress""></div>")]
        [InlineData(TypeFormatProgress.Striped, @"<div class=""progress""></div>")]
        [InlineData(TypeFormatProgress.Animated, @"<div class=""progress""></div>")]
        public void Format(TypeFormatProgress format, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlMultipleProgressBar()
            {
                Format = format
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""progress""><div class=""progress-bar"" style=""width: 0%;""></div></div>")]
        [InlineData("abc", @"<div class=""progress""><div class=""progress-bar"" style=""width: 0%;"">abc</div></div>")]
        [InlineData("webexpress.webui:plugin.name", @"<div class=""progress""><div class=""progress-bar"" style=""width: 0%;"">WebExpress.WebUI</div></div>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var item = new ControlMultipleProgressBarItem() { Text = text };
            var control = new ControlMultipleProgressBar(null, item)
            {
                Format = TypeFormatProgress.Colored
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the color property of the multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorText.Default, @"<div class=""progress"">*</div>")]
        [InlineData(TypeColorText.Primary, @"<div class=""progress""><div class=""progress-bar text-primary"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.Secondary, @"<div class=""progress""><div class=""progress-bar text-secondary"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.Info, @"<div class=""progress""><div class=""progress-bar text-info"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.Warning, @"<div class=""progress""><div class=""progress-bar text-warning"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.Danger, @"<div class=""progress""><div class=""progress-bar text-danger"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.Light, @"<div class=""progress""><div class=""progress-bar text-light"" style=""width: 0%;""></div></div>")]
        [InlineData(TypeColorText.White, @"<div class=""progress""><div class=""progress-bar text-white"" style=""width: 0%;""></div></div>")]
        public void Color(TypeColorText color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var item = new ControlMultipleProgressBarItem() { Color = new PropertyColorText(color) };
            var control = new ControlMultipleProgressBar(null, item)
            {
                Format = TypeFormatProgress.Colored
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text color property of the multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorText.Default, @"<div class=""progress""></div>")]
        [InlineData(TypeColorText.Primary, @"<div class=""progress text-primary""></div>")]
        [InlineData(TypeColorText.Secondary, @"<div class=""progress text-secondary""></div>")]
        [InlineData(TypeColorText.Info, @"<div class=""progress text-info""></div>")]
        [InlineData(TypeColorText.Warning, @"<div class=""progress text-warning""></div>")]
        [InlineData(TypeColorText.Danger, @"<div class=""progress text-danger""></div>")]
        [InlineData(TypeColorText.Light, @"<div class=""progress text-light""></div>")]
        [InlineData(TypeColorText.White, @"<div class=""progress text-white""></div>")]
        [InlineData(TypeColorText.Muted, @"<div class=""progress text-muted""></div>")]
        public void TextColor(TypeColorText textColor, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlMultipleProgressBar()
            {
                TextColor = new PropertyColorText(textColor),
                Format = TypeFormatProgress.Colored
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the value property of the form multiple progress bar control.
        /// </summary>
        [Theory]
        [InlineData(0u, @"<progress min=""0"" max=""100"" value=""0"">0%</progress>")]
        [InlineData(100u, @"<progress min=""0"" max=""100"" value=""100"">100%</progress>")]
        public void Value(uint value, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var item = new ControlMultipleProgressBarItem() { Value = value };
            var control = new ControlMultipleProgressBar(null, item)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
