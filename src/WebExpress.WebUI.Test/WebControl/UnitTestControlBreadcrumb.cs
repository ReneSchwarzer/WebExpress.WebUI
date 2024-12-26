using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the breadcrumb control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlBreadcrumb
    {
        /// <summary>
        /// Tests the id property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("id", @"<ol id=""id"" class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the uri property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("http://example.com", @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        public void Uri(string uri, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb { Uri = uri };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the empty name property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("Home", @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        public void EmptyName(string emptyName, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb { EmptyName = emptyName };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<ol class=""breadcrumb bg-light ps-2 bg-light""></ol>")]
        [InlineData(TypeSizeButton.Small, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData(TypeSizeButton.Large, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-lg""></ol>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb { Size = size };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the prefix property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("Prefix", @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        public void Prefix(string prefix, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb { Prefix = prefix };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the take last property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData((ushort)5, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData(3, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        public void TakeLast(ushort takeLast, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlBreadcrumb { TakeLast = takeLast };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
