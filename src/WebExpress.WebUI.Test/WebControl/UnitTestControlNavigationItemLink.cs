using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the navigation item link control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlNavigationItemLink
    {
        /// <summary>
        /// Tests the id property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("id", @"<a id=""id"" class=""link""></a>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("abc", @"<a class=""link"">abc</a>")]
        [InlineData("webexpress.webui:plugin.name", @"<a class=""link"">WebExpress.WebUI</a>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the uri property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("/a", @"<a class=""link"" href=""/a""></a>")]
        [InlineData("/a/b", @"<a class=""link"" href=""/a/b""></a>")]
        public void Uri(string uri, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Uri = uri,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the title property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("a", @"<a class=""link"" title=""a""></a>")]
        [InlineData("b", @"<a class=""link"" title=""b""></a>")]
        public void Title(string title, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Title = title,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the target property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(TypeTarget.None, @"<a class=""link""></a>")]
        [InlineData(TypeTarget.Blank, @"<a class=""link"" target=""_blank""></a>")]
        [InlineData(TypeTarget.Self, @"<a class=""link"" target=""_self""></a>")]
        [InlineData(TypeTarget.Parent, @"<a class=""link"" target=""_parent""></a>")]
        [InlineData(TypeTarget.Framename, @"<a class=""link"" target=""_framename""></a>")]
        public void Target(TypeTarget target, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Target = target,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the tooltip property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("a", @"<a class=""link"" title=""a"" data-bs-toggle=""tooltip""></a>")]
        [InlineData("b", @"<a class=""link"" title=""b"" data-bs-toggle=""tooltip""></a>")]
        [InlineData("a<br/>b", @"<a class=""link"" title=""a<br/>b"" data-bs-toggle=""tooltip""></a>")]
        public void Tooltip(string tooltip, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Tooltip = tooltip
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the icon property of the navigation item link control.
        /// </summary>
        [Fact]
        public void Icon()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                Icon = new PropertyIcon(TypeIcon.Star)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html.Trim());
        }

        /// <summary>
        /// Tests the no wrap property of the navigation item link control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<a class=""link""></a>")]
        [InlineData(true, @"<a class=""link text-nowrap""></a>")]
        public void NoWrap(bool noWrap, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlNavigationItemLink()
            {
                NoWrap = noWrap
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the content property of the navigation item link control.
        /// </summary>
        [Fact]
        public void Content()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control1 = new ControlNavigationItemLink(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlNavigationItemLink(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlNavigationItemLink(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());

            // test execution
            var html1 = control1.Render(context);
            var html2 = control2.Render(context);
            var html3 = control2.Render(context);

            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html1.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html2.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html3.Trim());
        }
    }
}
