using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form move control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemInputMove
    {
        /// <summary>
        /// Tests the id property of the form move control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div id=""selection-move-*""></div>")]
        [InlineData("id", @"<div id=""selection-move-id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputMove(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the form move control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div id=""selection-move-*""></div>")]
        [InlineData("abc", @"<div id=""selection-move-*""></div>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputMove()
            {
                Name = name
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the value property of the form move control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div id=""selection-move-*""></div>")]
        [InlineData("abc", @"<div id=""selection-move-*""></div>")]
        public void Value(string value, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputMove()
            {
                Value = value
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Add method of the form move control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemInputMove()
            {
            };

            // test execution
            control.Add(new ControlFormItemInputSelectionItem() { Label = "label" });
            var html = control.Render(context);

            Assert.NotEmpty(control.Options);
            AssertExtensions.EqualWithPlaceholders(@"<div id=""selection-move-*""></div>", html);
        }
    }
}
