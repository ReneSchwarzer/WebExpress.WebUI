using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the table row control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTableRow
    {
        /// <summary>
        /// Tests the id property of the table row control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<tr></tr>")]
        [InlineData("id", @"<tr id=""id""></tr>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTableRow(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the layout property of the table row control.
        /// </summary>
        [Theory]
        [InlineData(TypesLayoutTableRow.Default, @"<tr></tr>")]
        [InlineData(TypesLayoutTableRow.Primary, @"<tr class=""table-primary""></tr>")]
        [InlineData(TypesLayoutTableRow.Secondary, @"<tr class=""table-secondary""></tr>")]
        [InlineData(TypesLayoutTableRow.Info, @"<tr class=""table-info""></tr>")]
        [InlineData(TypesLayoutTableRow.Success, @"<tr class=""table-success""></tr>")]
        [InlineData(TypesLayoutTableRow.Warning, @"<tr class=""table-warning""></tr>")]
        [InlineData(TypesLayoutTableRow.Danger, @"<tr class=""table-danger""></tr>")]
        [InlineData(TypesLayoutTableRow.Light, @"<tr class=""table-light""></tr>")]
        [InlineData(TypesLayoutTableRow.Dark, @"<tr class=""table-dark""></tr>")]
        public void Layout(TypesLayoutTableRow layout, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTableRow()
            {
                Layout = layout
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the table row control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<tr><td><div></div></td></tr>")]
        [InlineData(typeof(ControlLink), @"<tr><td><a class=""link""></a></td></tr>")]
        [InlineData(typeof(ControlImage), @"<tr><td><img></td></tr>")]
        public void Add(Type cell, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var childInstance = Activator.CreateInstance(cell, [null]) as IControl;
            var control = new ControlTableRow();

            // test execution
            control.Add(childInstance);

            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
