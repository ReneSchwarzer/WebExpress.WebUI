using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the table control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTable
    {
        /// <summary>
        /// Tests the id property of the table control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData("id", @"<table id=""id"" class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTable(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the column layout property of the table control.
        /// </summary>
        [Theory]
        [InlineData(TypesLayoutTableRow.Default, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Primary, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Secondary, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Info, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Success, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Warning, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Danger, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Light, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(TypesLayoutTableRow.Dark, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        public void ColumnLayout(TypesLayoutTableRow layout, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTable
            {
                ColumnLayout = layout
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the responsive property of the table control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(true, @"<table class=""table table-striped table-responsive""><thead><tr></tr></thead><tbody></tbody></table>")]
        public void Responsive(bool responsive, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTable
            {
                Responsive = responsive
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the striped property of the table control.
        /// </summary>
        [Theory]
        [InlineData(true, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(false, @"<table class=""table""><thead><tr></tr></thead><tbody></tbody></table>")]
        public void Striped(bool striped, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTable
            {
                Striped = striped
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the reflow property of the table control.
        /// </summary>
        [Theory]
        [InlineData(true, @"<table class=""table table-striped table-reflow""><thead><tr></tr></thead><tbody></tbody></table>")]
        [InlineData(false, @"<table class=""table table-striped""><thead><tr></tr></thead><tbody></tbody></table>")]
        public void Reflow(bool reflow, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTable
            {
                Reflow = reflow
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
