using WebExpress.WebUI.Test.Fixture;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the inline form control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormInline : IClassFixture<UnitTestControlFixture>
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
        public UnitTestControlFormInline(UnitTestControlFixture fixture, ITestOutputHelper output)
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
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlForm() { FormLayout = TypeLayoutForm.Inline };

            //var html = control.Render(context);
            //var str = html.ToString();

            //// test execution
            //Assert.StartsWith(@"<form class=""form-inline""", html.Trim());
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyFormChangeSubmitText()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlForm() { FormLayout = TypeLayoutForm.Inline };
            //control.AddPrimaryButton(new ControlFormItemButtonSubmit("") { Text = "sendbutton" });

            //var html = control.Render(context);
            //var str = html.ToString();

            //// test execution
            //Assert.Contains(@"sendbutton", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with id.
        /// </summary>
        [Fact]
        public void EmptyFormWithId()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlForm("form") { FormLayout = TypeLayoutForm.Inline };

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
            //var control = new ControlForm() { FormLayout = TypeLayoutForm.Inline };
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
            //var control = new ControlForm("form", item) { FormLayout = TypeLayoutForm.Inline };

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
            //var control = new ControlForm("form") { FormLayout = TypeLayoutForm.Inline };

            //control.Add(item);

            //// test execution
            //var html = control.Render(context);
            //var str = html.ToString();

            //Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }
    }
}
