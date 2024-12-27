using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the alert control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlAlert
    {
        /// <summary>
        /// Tests the id property of the alert control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""alert"" role=""alert""><button class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""close""></button></div>")]
        [InlineData("id", @"<div id=""id"" class=""alert"" role=""alert""><button class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""close""></button></div>")]
        [InlineData("03C6031F-04A9-451F-B817-EBD6D32F8B0C", @"<div id=""03C6031F-04A9-451F-B817-EBD6D32F8B0C"" class=""alert"" role=""alert""><button class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""close""></button></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAlert(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the alert control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""alert"" role=""alert""><button class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""close""></button></div>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAlert()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
