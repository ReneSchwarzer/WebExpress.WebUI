using WebExpress.WebUI.Test.Fixture;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the modal form control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlModalForm : IClassFixture<UnitTestControlFixture>
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
        public UnitTestControlModalForm(UnitTestControlFixture fixture, ITestOutputHelper output)
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
            //var control = new ControlModalForm();

            //var html = control.Render(context);
            //var str = html.ToString();

            //// test execution
            //Assert.StartsWith("<form action=", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with id.
        /// </summary>
        [Fact]
        public void EmptyFormWithId()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlModalForm("form");

            //var html = control.Render(context);

            //// test execution
            //Assert.StartsWith(@"<form id=""form""", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with header.
        /// </summary>
        [Fact]
        public void EmptyFormWithHeaderAtInstancing()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlModalForm("form", "header");

            //var html = control.Render(context);

            //// test execution
            //Assert.Contains(@"<h4 class=""modal-title"">header</h4>", html.Trim());
        }

        /// <summary>
        /// Tests a simple form with header.
        /// </summary>
        [Fact]
        public void EmptyFormWithHeaderAtProperty()
        {
            //// preconditions
            //var context = Fixture.CrerateContext();
            //var control = new ControlModalForm("form") { Header = "header" };

            //var html = control.Render(context);

            //// test execution
            //Assert.Contains(@"<h4 class=""modal-title"">header</h4>", html.Trim());
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
            //var control = new ControlModalForm();
            //var item = new ControlFormItemInputTextBox() { };

            //// test execution
            //var html = control.Render(context, [item]);
            ////var str = html.ToString();

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
            //var control = new ControlModalForm("form", item);

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
            //var control = new ControlModalForm("form");

            //control.Add(item);

            //// test execution
            //var html = control.Render(context);

            //Assert.Contains(@"<input type=""text"" class=""form-control"">", html.Trim());
        }
    }
}
