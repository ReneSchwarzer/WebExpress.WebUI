using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the tree item link control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTreeItemLink
    {
        /// <summary>
        /// Tests the id property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData("id", @"<li id=""id""><a id=""id"" class=""link tree-link""></a></li>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData("abc", @"<li><a class=""link tree-link"">abc</a></li>")]
        [InlineData("webexpress.webui:plugin.name", @"<li><a class=""link tree-link"">webexpress.webui:plugin.name</a></li>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the uri property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData("/a", @"<li><a class=""link tree-link"" href=""/a""></a></li>")]
        [InlineData("/a/b", @"<li><a class=""link tree-link"" href=""/a/b""></a></li>")]
        public void Uri(string uri, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Uri = uri != null ? new UriEndpoint(uri) : null
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the title property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData("a", @"<li><a class=""link tree-link"" title=""a""></a></li>")]
        [InlineData("b", @"<li><a class=""link tree-link"" title=""b""></a></li>")]
        public void Title(string title, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Title = title,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the target property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(TypeTarget.None, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData(TypeTarget.Blank, @"<li><a class=""link tree-link"" target=""_blank""></a></li>")]
        [InlineData(TypeTarget.Self, @"<li><a class=""link tree-link"" target=""_self""></a></li>")]
        [InlineData(TypeTarget.Parent, @"<li><a class=""link tree-link"" target=""_parent""></a></li>")]
        [InlineData(TypeTarget.Framename, @"<li><a class=""link tree-link"" target=""_framename""></a></li>")]
        public void Target(TypeTarget target, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Target = target,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the tooltip property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData("a", @"<li><a class=""link tree-link"" data-toggle=""tooltip""></a></li>")]
        [InlineData("b", @"<li><a class=""link tree-link"" data-toggle=""tooltip""></a></li>")]
        [InlineData("a<br/>b", @"<li><a class=""link tree-link"" data-toggle=""tooltip""></a></li>")]
        public void Tooltip(string tooltip, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Tooltip = tooltip
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the tree item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><a class=""link tree-link""></a></li>")]
        [InlineData(typeof(IconStar), @"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>")]
        public void Icon(Type icon, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTreeItemLink()
            {
                Icon = icon != null ? Activator.CreateInstance(icon) as IIcon : null
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the tree item link control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control1 = new ControlTreeItemLink(null, new ControlIcon() { Icon = new IconStar() });
            var control2 = new ControlTreeItemLink(null, [new ControlIcon() { Icon = new IconStar() }]);
            var control3 = new ControlTreeItemLink(null, new List<ControlIcon>([new ControlIcon() { Icon = new IconStar() }]).ToArray());
            var control4 = new ControlTreeItemLink(null);
            var control5 = new ControlTreeItemLink(null);
            var control6 = new ControlTreeItemLink(null);

            // test execution
            control4.Add(new ControlIcon() { Icon = new IconStar() });
            control5.Add([new ControlIcon() { Icon = new IconStar() }]);
            control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new IconStar() }]).ToArray());

            var html1 = control1.Render(context, visualTree);
            var html2 = control2.Render(context, visualTree);
            var html3 = control3.Render(context, visualTree);
            var html4 = control4.Render(context, visualTree);
            var html5 = control5.Render(context, visualTree);
            var html6 = control6.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html1);
            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html2);
            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html3);
            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html4);
            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html5);
            AssertExtensions.EqualWithPlaceholders(@"<li><a class=""link tree-link""><span class=""fas fa-star""></span></a></li>", html6);
        }
    }
}
