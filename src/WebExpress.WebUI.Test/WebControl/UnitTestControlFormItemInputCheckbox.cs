using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form item input checkbox control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemInputCheckbox
    {
        /// <summary>
        /// Tests the id property of the form item input checkbox control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""checkbox""><label><input type=""checkbox""></label></div>")]
        [InlineData("id", @"<div id=""id"" class=""checkbox""><label><input type=""checkbox""></label></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputCheckbox(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Inline property of the form item input checkbox control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<div class=""checkbox""><label><input type=""checkbox""></label></div>")]
        [InlineData(true, @"<div class=""checkbox""><label><input type=""checkbox""></label></div>")]
        public void Inline(bool inline, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputCheckbox
            {
                Inline = inline
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Description property of the form item input checkbox control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""checkbox""><label><input type=""checkbox""></label></div>")]
        [InlineData("description", @"<div class=""checkbox""><label><input type=""checkbox"">&nbsp;description </label></div>")]
        public void Description(string description, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputCheckbox
            {
                Description = description
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Pattern property of the form item input checkbox control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""checkbox""><label><input type=""checkbox""></label></div>")]
        [InlineData("pattern", @"<div class=""checkbox""><label><input pattern=""pattern"" type=""checkbox""></label></div>")]
        public void Pattern(string pattern, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputCheckbox
            {
                Pattern = pattern
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
