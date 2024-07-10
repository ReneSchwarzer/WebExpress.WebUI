using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the inline formular control.
    /// </summary>
    public class UnitTestControlFormularInline : IClassFixture<UnitTestControlFixture>
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
        /// Constructor
        /// </summary>
        /// <param name="fixture">The log.</param>
        /// <param name="output">The test context.</param>
        public UnitTestControlFormularInline(UnitTestControlFixture fixture, ITestOutputHelper output)
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
            var control = new ControlFormInline();

            var html = control.Render(context);
            var str = html.ToString();

            // test execution
            Assert.StartsWith(@"<form class=""form-inline""", html.Trim());
        }

        /// <summary>
        /// Tests a empty form.
        /// </summary>
        [Fact]
        public void EmptyFormChangeSubmitText()
        {
            // preconditions
            var context = Fixture.CrerateContext();
            var control = new ControlFormInline();
            control.SubmitButton.Text = "sendbutton";

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
            var control = new ControlFormInline("form");

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
            var control = new ControlFormInline();
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
            var control = new ControlFormInline("form", item);

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
            var control = new ControlFormInline("form");

            control.Add(item);

            // test execution
            var html = control.Render(context);
            var str = html.ToString();

            Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }
    }
}
