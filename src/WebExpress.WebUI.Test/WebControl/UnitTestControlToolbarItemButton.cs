using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the toolbar item button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlToolbarItemButton
    {
        /// <summary>
        /// Tests the id property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link nav-link""></a>")]
        [InlineData("id", @"<a id=""id"" class=""link nav-link""></a>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<a class=""link nav-link""></a>")]
        [InlineData(TypeColorBackground.Primary, @"<a class=""link nav-link bg-primary""></a>")]
        [InlineData(TypeColorBackground.Secondary, @"<a class=""link nav-link bg-secondary""></a>")]
        [InlineData(TypeColorBackground.Warning, @"<a class=""link nav-link bg-warning""></a>")]
        [InlineData(TypeColorBackground.Danger, @"<a class=""link nav-link bg-danger""></a>")]
        [InlineData(TypeColorBackground.Dark, @"<a class=""link nav-link bg-dark""></a>")]
        [InlineData(TypeColorBackground.Light, @"<a class=""link nav-link bg-light""></a>")]
        [InlineData(TypeColorBackground.Transparent, @"<a class=""link nav-link bg-transparent""></a>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link nav-link""></a>")]
        [InlineData("abc", @"<a class=""link nav-link"">abc</a>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<a class=""link nav-link"">WebExpress.WebUI</a>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the tooltip property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""link nav-link""></a>")]
        [InlineData("abc", @"<a class=""link nav-link"" title=""abc"" data-bs-toggle=""tooltip""></a>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<a class=""link nav-link"" title=""WebExpress.WebUI"" data-bs-toggle=""tooltip""></a>")]
        public void Tooltip(string tooltip, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton()
            {
                Tooltip = tooltip,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<a class=""link nav-link""></a>")]
        [InlineData(TypeIcon.Star, @"<a class=""link nav-link""><span class=""fas fa-star""></span></a>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the active property of the toolbar item button control.
        /// </summary>
        [Theory]
        [InlineData(TypeActive.None, @"<a class=""link nav-link""></a>")]
        [InlineData(TypeActive.Active, @"<a class=""link nav-link active""></a>")]
        [InlineData(TypeActive.Disabled, @"<a class=""link nav-link disabled""></a>")]
        public void Active(TypeActive active, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlToolbarItemButton()
            {
                Active = active
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the uri property of the toolbar item button control.
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
            var control = new ControlLink()
            {
                Uri = uri,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the title property of the toolbar item button control.
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
            var control = new ControlLink()
            {
                Title = title,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the target property of the toolbar item button control.
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
            var control = new ControlLink()
            {
                Target = target,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the add function of the toolbar item button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control1 = new ControlLink(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlLink(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlLink(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            var control4 = new ControlLink(null);
            var control5 = new ControlLink(null);
            var control6 = new ControlLink(null);

            // test execution
            control4.Add(new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            control5.Add([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());

            var html1 = control1.Render(context);
            var html2 = control2.Render(context);
            var html3 = control3.Render(context);
            var html4 = control4.Render(context);
            var html5 = control5.Render(context);
            var html6 = control6.Render(context);

            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html1.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html2.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html3.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html4.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html5.Trim());
            Assert.Equal(@"<a class=""link""><span class=""fas fa-star""></span></a>", html6.Trim());
        }
    }
}
