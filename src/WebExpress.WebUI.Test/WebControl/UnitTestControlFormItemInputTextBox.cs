using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form text control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemInputTextBox
    {
        /// <summary>
        /// Tests the id property of the form label control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("id", @"<input id=""id"" name=""id"" type=""text"" class=""form-control"">")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("abc", @"<input name=""abc"" type=""text"" class=""form-control"">")]
        public void Name(string name, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the format property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(TypesEditTextFormat.Default, @"<input type=""text"" class=""form-control"">")]
        [InlineData(TypesEditTextFormat.Multiline, @"<textarea class=""form-control""></textarea>")]
        [InlineData(TypesEditTextFormat.Wysiwyg, @"<textarea id=""*"" class=""form-control""></textarea>")]
        public void Format(TypesEditTextFormat format, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Format = format
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the description property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("abc", @"<input type=""text"" class=""form-control"">")]
        public void Description(string description, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Description = description
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the placeholder property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("abc", @"<input type=""text"" class=""form-control"" placeholder=""abc"">")]
        public void Placeholder(string placeholder, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Placeholder = placeholder
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the min length property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData(0u, @"<input minlength=""0"" type=""text"" class=""form-control"">")]
        [InlineData(10u, @"<input minlength=""10"" type=""text"" class=""form-control"">")]
        public void MinLength(uint? minLength, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                MinLength = minLength
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the max length property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData(0u, @"<input maxlength=""0"" type=""text"" class=""form-control"">")]
        [InlineData(10u, @"<input maxlength=""10"" type=""text"" class=""form-control"">")]
        public void MaxLength(uint? maxLength, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                MaxLength = maxLength
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the required property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<input type=""text"" class=""form-control"">")]
        [InlineData(true, @"<input required type=""text"" class=""form-control"">")]
        public void Required(bool required, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Required = required
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the pattern property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("abc.*", @"<input pattern=""abc.*"" type=""text"" class=""form-control"">")]
        public void Pattern(string pattern, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Pattern = pattern
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the rows property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<textarea class=""form-control""></textarea>")]
        [InlineData(0u, @"<textarea class=""form-control"" rows=""0""></textarea>")]
        [InlineData(10u, @"<textarea class=""form-control"" rows=""10""></textarea>")]
        public void Rows(uint? rows, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Rows = rows,
                Format = TypesEditTextFormat.Multiline
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the value property of the form text control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<input type=""text"" class=""form-control"">")]
        [InlineData("abc", @"<input value=""abc"" type=""text"" class=""form-control"">")]
        public void Value(string value, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemInputTextBox()
            {
                Value = value
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
