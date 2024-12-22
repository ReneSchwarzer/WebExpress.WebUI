using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form item group horizontal control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemGroupHorizontal
    {
        /// <summary>
        /// Tests the id property of the form item group horizontal control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""form-group-horizontal""><div></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""form-group-horizontal""><div></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemGroupHorizontal(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form item group horizontal control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""form-group-horizontal""><div></div></div>")]
        [InlineData("abc", @"<div class=""form-group-horizontal""><div></div></div>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemGroupHorizontal()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
