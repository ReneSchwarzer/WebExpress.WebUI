using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb { Uri = new UriResource(uri) };

            // test execution
            var html = control.Render(context, visualTree);

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb { EmptyName = emptyName, Uri = new UriResource("http://example.com") };

            // test execution
            var html = control.Render(context, visualTree);

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb { Size = size, Uri = new UriResource("http://example.com") };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the prefix property of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("Prefix", @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""><li><div class=""me-2 text-muted"">Prefix</div></li></ol>")]
        public void Prefix(string prefix, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb { Prefix = prefix, Uri = new UriResource("http://example.com") };

            // test execution
            var html = control.Render(context, visualTree);

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
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlBreadcrumb { TakeLast = takeLast, Uri = new UriResource("http://example.com") };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the render function of the breadcrumb control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""></ol>")]
        [InlineData("http://localhost:80/app/page", @"<ol class=""breadcrumb bg-light ps-2 bg-light btn-sm""><li class=""breadcrumb-item""><a href=""http://localhost/app/page"" class=""link"">abc</a></li></ol>")]
        public void Render(string uri, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var uriResource = new UriResource(uri);
            var control = new ControlBreadcrumb()
            {
                Uri = uriResource
            };

            if (uriResource.PathSegments.LastOrDefault() != null)
            {
                uriResource.PathSegments.LastOrDefault().Display ??= "abc";
            }

            var uriProperty = context.Request.GetType().GetProperty("Uri");
            uriProperty.SetValue(context.Request, uriResource);

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
