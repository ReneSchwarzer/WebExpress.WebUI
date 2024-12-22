using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form item group column mix control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemGroupColumnMix
    {
        /// <summary>
        /// Tests the id property of the form item group column mix control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""form-group-column-mix""></div>")]
        [InlineData("id", @"<div id=""id"" class=""form-group-column-mix""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemGroupColumnMix(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form item group column mix control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""form-group-column-mix""></div>")]
        [InlineData("abc", @"<div class=""form-group-column-mix""></div>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemGroupColumnMix()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
