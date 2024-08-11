using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the inline radio control.
    /// </summary>
    public class UnitTestControlFormItemInputRadio : IClassFixture<UnitTestControlFixture>
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
        public UnitTestControlFormItemInputRadio(UnitTestControlFixture fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            Output = output;
        }

        /// <summary>
        /// Tests a empty control.
        /// </summary>
        [Fact]
        public void Empty()
        {
            // preconditions
            var context = Fixture.CrerateContextForm();
            var control = new ControlFormItemInputRadio();

            var html = control.Render(context).Trim();

            // test execution
            Assert.StartsWith(@"<div class=""radio""><label><input type=""radio""></label></div>", html);
        }

        /// <summary>
        /// Tests a control.
        /// </summary>
        [Fact]
        public void True()
        {
            // preconditions
            var context = Fixture.CrerateContextForm();
            var control = new ControlFormItemInputRadio() { Checked = true };

            var html = control.Render(context).Trim();

            // test execution
            Assert.StartsWith(@"<div class=""radio""><label><input type=""radio"" checked></label></div>", html);
        }

        /// <summary>
        /// Tests a control.
        /// </summary>
        [Fact]
        public void False()
        {
            // preconditions
            var context = Fixture.CrerateContextForm();
            var control = new ControlFormItemInputRadio() { Checked = false };

            var html = control.Render(context).Trim();

            // test execution
            Assert.StartsWith(@"<div class=""radio""><label><input type=""radio""></label></div>", html);
        }

        /// <summary>
        /// Tests a control.
        /// </summary>
        [Fact]
        public void Description()
        {
            // preconditions
            var context = Fixture.CrerateContextForm();
            var control = new ControlFormItemInputRadio() { Description = "abcdefg" };

            var html = control.Render(context).Trim();

            // test execution
            Assert.StartsWith(@"<div class=""radio""><label><input type=""radio"">&nbsp;abcdefg</label></div>", html);
        }
    }
}
