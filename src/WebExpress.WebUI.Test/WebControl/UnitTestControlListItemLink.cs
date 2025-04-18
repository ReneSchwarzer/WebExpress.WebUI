﻿using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebIcon;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the list item link control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlListItemLink
    {
        /// <summary>
        /// Tests the id property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData("id", @"<a id=""id"" class=""list-group-item-action""></a>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData("abc", @"<a class=""list-group-item-action"">abc</a>")]
        [InlineData("webexpress.webui:plugin.name", @"<a class=""list-group-item-action"">WebExpress.WebUI</a>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the uri property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData("/a", @"<a class=""list-group-item-action"" href=""/a""></a>")]
        [InlineData("/a/b", @"<a class=""list-group-item-action"" href=""/a/b""></a>")]
        public void Uri(string uri, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Uri = uri != null ? new UriEndpoint(uri) : null,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the title property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData("a", @"<a class=""list-group-item-action"" title=""a""></a>")]
        [InlineData("b", @"<a class=""list-group-item-action"" title=""b""></a>")]
        public void Title(string title, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Title = title,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the target property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(TypeTarget.None, @"<a class=""list-group-item-action""></a>")]
        [InlineData(TypeTarget.Blank, @"<a class=""list-group-item-action"" target=""_blank""></a>")]
        [InlineData(TypeTarget.Self, @"<a class=""list-group-item-action"" target=""_self""></a>")]
        [InlineData(TypeTarget.Parent, @"<a class=""list-group-item-action"" target=""_parent""></a>")]
        [InlineData(TypeTarget.Framename, @"<a class=""list-group-item-action"" target=""_framename""></a>")]
        public void Target(TypeTarget target, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Target = target,
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the tooltip property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData("a", @"<a class=""list-group-item-action"" data-bs-toggle=""tooltip""></a>")]
        [InlineData("b", @"<a class=""list-group-item-action"" data-bs-toggle=""tooltip""></a>")]
        [InlineData("a<br/>b", @"<a class=""list-group-item-action"" data-bs-toggle=""tooltip""></a>")]
        public void Tooltip(string tooltip, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Tooltip = tooltip
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<a class=""list-group-item-action""></a>")]
        [InlineData(typeof(IconStar), @"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>")]
        public void Icon(Type icon, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink()
            {
                Icon = icon != null ? Activator.CreateInstance(icon) as IIcon : null
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Active property of the list item link control.
        /// </summary>
        [Theory]
        [InlineData(TypeActive.None, @"<a class=""list-group-item-action""></a>")]
        [InlineData(TypeActive.Active, @"<a class=""list-group-item-action active""></a>")]
        public void Active(TypeActive active, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlListItemLink(null)
            {
                Active = active
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the list item link control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control1 = new ControlListItemLink(null, new ControlIcon() { Icon = new IconStar() });
            var control2 = new ControlListItemLink(null, [new ControlIcon() { Icon = new IconStar() }]);
            var control3 = new ControlListItemLink(null, new List<ControlIcon>([new ControlIcon() { Icon = new IconStar() }]).ToArray());
            var control4 = new ControlListItemLink(null);
            var control5 = new ControlListItemLink(null);
            var control6 = new ControlListItemLink(null);

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

            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html1);
            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html2);
            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html3);
            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html4);
            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html5);
            AssertExtensions.EqualWithPlaceholders(@"<a class=""list-group-item-action""><span class=""fas fa-star""></span></a>", html6);
        }
    }
}
