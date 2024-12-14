using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the text control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlText
    {
        /// <summary>
        /// Tests the id property of the text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlText(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the text control.
        /// </summary>
        [Theory]
        [InlineData(null, TypeFormatText.Paragraph, @"<p></p>")]
        [InlineData("abc", TypeFormatText.Paragraph, @"<p>abc</p>")]
        [InlineData("abc", TypeFormatText.Default, @"<div>abc</div>")]
        [InlineData("webexpress.webui:plugin.name", TypeFormatText.H1, @"<h1>WebExpress.WebUI</h1>")]
        public void Text(string text, TypeFormatText format, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlText()
            {
                Text = text,
                Format = format
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
