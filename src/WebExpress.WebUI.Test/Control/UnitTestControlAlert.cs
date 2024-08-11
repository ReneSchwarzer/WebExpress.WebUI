using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using Xunit.Abstractions;

namespace WebExpress.WebUI.Test.Control
{
    /// <summary>
    /// Tests the alert control.
    /// </summary>
    public class UnitTestControlAlert : IClassFixture<UnitTestControlFixture>
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
        public UnitTestControlAlert(UnitTestControlFixture fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            Output = output;
        }

        /// <summary>
        /// Tests a empty alert.
        /// </summary>
        [Fact]
        public void EmptyAlert()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlAlert();

            // test execution
            var html = control.Render(context);

            Assert.Equal(@"<div class=""alert"" role=""alert""><button class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""close""></button></div>", html.Trim());
        }

        /// <summary>
        /// Tests a alert.
        /// </summary>
        [Fact]
        public void AlertWithId()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlAlert("alertid");

            // test execution
            var html = control.Render(context);

            Assert.Contains(@"alertid", html.Trim());
        }

        /// <summary>
        /// Tests a alert.
        /// </summary>
        [Fact]
        public void AlertWithText()
        {
            // preconditions
            var context = new WebCore.WebPage.RenderContext();
            var control = new ControlAlert() { Text = "abc" };

            // test execution
            var html = control.Render(context);

            Assert.Contains(@"abc", html.Trim());
        }
    }
}
