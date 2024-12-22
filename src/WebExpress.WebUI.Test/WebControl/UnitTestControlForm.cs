using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlForm
    {
        /// <summary>
        /// Tests the id property of the form control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData("id", @"<form id=""id"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the backgroundcolor property of the form control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Primary, @"<form class=""bg-primary"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Secondary, @"<form class=""bg-secondary"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Warning, @"<form class=""bg-warning"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Danger, @"<form class=""bg-danger"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Dark, @"<form class=""bg-dark"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Light, @"<form class=""bg-light"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeColorBackground.Transparent, @"<form class=""bg-transparent"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        public void BackgroundColor(TypeColorBackground color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlForm()
            {
                BackgroundColor = new PropertyColorBackground(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData("abc", @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the form layout property of the form control.
        /// </summary>
        [Theory]
        [InlineData(TypeLayoutForm.Default, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeLayoutForm.Inline, @"<form class=""form-inline"" action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        public void FormLayout(TypeLayoutForm formLayout, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm()
            {
                FormLayout = formLayout
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the item layout property of the form control.
        /// </summary>
        [Theory]
        [InlineData(TypeLayoutFormItem.Horizontal, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeLayoutFormItem.Vertical, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        [InlineData(TypeLayoutFormItem.Mix, @"<form action=""http://localhost:8080/"" method=""POST"" enctype=""multipart/form-data"">*</form>")]
        public void ItemLayout(TypeLayoutFormItem itemLayout, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm()
            {
                ItemLayout = itemLayout
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyForm()
        {
            // preconditions
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm();

            var html = control.Render(context);

            // test execution
            AssertExtensions.EqualWithPlaceholders(@"<form action=*", html.Trim());
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyFormChangeSubmitText()
        {
            // preconditions
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlForm();
            control.AddPrimaryButton(new ControlFormItemButtonSubmit("") { Text = "sendbutton" });

            var html = control.Render(context);

            // test execution
            Assert.Contains(@"sendbutton", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with id.
        /// </summary>
        [Fact]
        public void EmptyFormWithId()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlForm("form");

            //var html = control.Render(context);

            //// test execution
            //Assert.StartsWith(@"<form id=""form""", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added during rendering.
        /// </summary>
        [Fact]
        public void SimpleFormAtRender()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlForm();
            //var item = new ControlFormItemInputTextBox() { };

            //// test execution
            //var html = control.Render(context, [item]);

            //Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added when instantiating.
        /// </summary>
        [Fact]
        public void SimpleFormAtInstancing()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var item = new ControlFormItemInputTextBox() { };
            //var control = new ControlForm("form", item);

            //// test execution
            //var html = control.Render(context);

            //Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added using add.
        /// </summary>
        [Fact]
        public void SimpleFormAtAdd()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var item = new ControlFormItemInputTextBox() { };
            //var control = new ControlForm("form");

            //control.Add(item);

            //// test execution
            //var html = control.Render(context);
            //var str = html.ToString();

            //Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a complex form.
        /// </summary>
        [Fact]
        public void ComplexForm()
        {
            //// preconditions
            //var expectedResult = Fixture.GetEmbeddedResource("ComplexForm.txt");
            //var context = Fixture.CrerateContext();
            //var item1 = new ControlFormItemInputTextBox() { Label = "Label1", Help = "Help1", Placeholder = "Placeholder1" };
            //var item2 = new ControlFormItemInputTextBox() { Label = "Label2", Help = "Help2", Placeholder = "Placeholder2" };
            //var submitButton = new ControlFormItemButtonSubmit("Submit");
            //var control = new ControlForm("form", item1, item2);
            //control.AddPrimaryButton(submitButton);


            //// test execution
            //var html = control.Render(context);
            //var str = html.ToString();

            //// postconditions
            //expectedResult = expectedResult.Replace("05c888e8-15f3-4be8-b765-0d7be63cc82b", control.FormId.Id);
            //expectedResult = expectedResult.Replace("974c6159-98e3-4ede-8bb5-6bc4d52e1770", control.SubmitType.Id);

            //Assert.Equal(expectedResult.Trim(), str.Trim());
        }
    }
}
