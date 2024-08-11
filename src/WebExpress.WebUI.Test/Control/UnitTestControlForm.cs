using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the form control.
    /// </summary>
    public class UnitTestControlForm : IClassFixture<UnitTestControlFixture>
    {
        /// <summary>
        /// Returns the log.
        /// </summary>
        protected ITestOutputHelper Output { get; private set; }

        /// <summary>
        /// Returns the test context.
        /// </summary>
        protected UnitTestControlFixture Fixture { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fixture">The log.</param>
        /// <param name="output">The test context.</param>
        public UnitTestControlForm(UnitTestControlFixture fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            Output = output;
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyForm()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var control = new ControlForm();

            var html = control.Render(context);

            // test execution
            Assert.StartsWith("<form action=", html.Trim());
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyFormChangeSubmitText()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var control = new ControlForm();
            control.AddPrimaryButton(new ControlFormItemButtonSubmit("") { Text = "sendbutton" });

            var html = control.Render(context);
            var str = html.ToString();

            // test execution
            Assert.Contains(@"sendbutton", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with id.
        /// </summary>
        [Fact]
        public void EmptyFormWithId()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var control = new ControlForm("form");

            var html = control.Render(context);

            // test execution
            Assert.StartsWith(@"<form id=""form""", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added during rendering.
        /// </summary>
        [Fact]
        public void SimpleFormAtRender()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var control = new ControlForm();
            var item = new ControlFormItemInputTextBox() { };

            // test execution
            var html = control.Render(context, [item]);

            Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added when instantiating.
        /// </summary>
        [Fact]
        public void SimpleFormAtInstancing()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var item = new ControlFormItemInputTextBox() { };
            var control = new ControlForm("form", item);

            // test execution
            var html = control.Render(context);

            Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a simple form.
        /// The control elements are added using add.
        /// </summary>
        [Fact]
        public void SimpleFormAtAdd()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var item = new ControlFormItemInputTextBox() { };
            var control = new ControlForm("form");

            control.Add(item);

            // test execution
            var html = control.Render(context);
            var str = html.ToString();

            Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }

        /// <summary>
        /// Tests a complex form.
        /// </summary>
        [Fact]
        public void ComplexForm()
        {
            // preconditions
            var expectedResult = Fixture.GetEmbeddedResource("ComplexForm.txt");
            var context = Fixture.CrerateContext();
            var item1 = new ControlFormItemInputTextBox() { Label = "Label1", Help = "Help1", Placeholder = "Placeholder1" };
            var item2 = new ControlFormItemInputTextBox() { Label = "Label2", Help = "Help2", Placeholder = "Placeholder2" };
            var submitButton = new ControlFormItemButtonSubmit("Submit");
            var control = new ControlForm("form", item1, item2);
            control.AddPrimaryButton(submitButton);


            // test execution
            var html = control.Render(context);
            var str = html.ToString();

            // postconditions
            expectedResult = expectedResult.Replace("05c888e8-15f3-4be8-b765-0d7be63cc82b", control.FormId.Id);
            expectedResult = expectedResult.Replace("974c6159-98e3-4ede-8bb5-6bc4d52e1770", control.SubmitType.Id);

            Assert.Equal(expectedResult.Trim(), str.Trim());
        }
    }
}
