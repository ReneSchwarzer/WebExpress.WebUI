using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form item help text control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemHelpText
    {
        /// <summary>
        /// Tests the id property of the form item help text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<small></small>")]
        [InlineData("id", @"<small id=""id""></small>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemHelpText(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the form item help text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<small></small>")]
        [InlineData("abc", @"<small>abc</small>")]
        [InlineData("webexpress.webui:plugin.name", @"<small>WebExpress.WebUI</small>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemHelpText()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the form item help text control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeText.Default, @"<small></small>")]
        [InlineData(TypeSizeText.ExtraSmall, @"<small style=""font-size:0.55rem;""></small>")]
        [InlineData(TypeSizeText.Small, @"<small style=""font-size:0.75rem;""></small>")]
        [InlineData(TypeSizeText.Large, @"<small style=""font-size:1.5rem;""></small>")]
        [InlineData(TypeSizeText.ExtraLarge, @"<small style=""font-size:2rem;""></small>")]
        public void Size(TypeSizeText size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemHelpText()
            {
                Size = new PropertySizeText(size)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
