using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form label control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemLabel
    {
        /// <summary>
        /// Tests the id property of the form label control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<label></label>")]
        [InlineData("id", @"<label id=""id""></label>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemLabel(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form label control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<label></label>")]
        [InlineData("abc", @"<label></label>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemLabel()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the form label control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<label></label>")]
        [InlineData("abc", @"<label>abc</label>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemLabel()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the form item property of the form label control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<label></label>")]
        [InlineData(true, @"<label></label>")]
        public void FormItem(bool formItem, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemLabel()
            {
                FormItem = formItem ? new ControlFormItemInputTextBox() : null
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
