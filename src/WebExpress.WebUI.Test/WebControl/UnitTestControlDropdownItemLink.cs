using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the dropdown item link control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlControlDropdownItemLink
    {
        /// <summary>
        /// Tests the id property of the dropdown item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link""></a>")]
        [InlineData("id", @"<a id=""id"" class=""link""></a>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdownItemLink(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the dropdown item link control.
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
            var control = new ControlDropdownItemLink()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the uri property of the dropdown item link control.
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
            var control = new ControlDropdownItemLink()
            {
                Uri = uri,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the title property of the dropdown item link control.
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
            var control = new ControlDropdownItemLink()
            {
                Title = title,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the target property of the dropdown item link control.
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
            var control = new ControlDropdownItemLink()
            {
                Target = target,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the tooltip property of the dropdown item link control.
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
            var control = new ControlDropdownItemLink()
            {
                Tooltip = tooltip
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the icon property of the dropdown item link control.
        /// </summary>
        [Fact]
        public void Icon()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdownItemLink()
            {
                Icon = new PropertyIcon(TypeIcon.Star)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html.Trim());
        }

        /// <summary>
        /// Tests the content property of the dropdown item link control.
        /// </summary>
        [Fact]
        public void Content()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control1 = new ControlDropdownItemLink(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlDropdownItemLink(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlDropdownItemLink(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());

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
