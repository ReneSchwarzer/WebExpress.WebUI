using WebExpress.WebCore.WebIcon;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the icon control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlIcon
    {
        /// <summary>
        /// Tests the id property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<span class=""fas fa-star""></span>")]
        [InlineData("id", @"<span id=""id"" class=""fas fa-star""></span>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlIcon(id)
            {
                Icon = new IconStar()
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html.Trim());
        }

        /// <summary>
        /// Tests the title property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<span class=""fas fa-star""></span>")]
        [InlineData("abc", @"<span class=""fas fa-star"" title=""abc""></span>")]
        public void Title(string title, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlIcon()
            {
                Icon = new IconStar(),
                Title = title
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html.Trim());
        }

        /// <summary>
        /// Tests the icon property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(null, @"")]
        [InlineData(typeof(IconStar), @"<span class=""fas fa-star""></span>")]
        public void Icon(Type icon, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlIcon()
            {
                Icon = icon != null ? Activator.CreateInstance(icon) as IIcon : null
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html.Trim());
        }

        /// <summary>
        /// Tests the size property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeText.Default, @"<span class=""fas fa-star""></span>")]
        [InlineData(TypeSizeText.ExtraSmall, @"<span class=""fas fa-star"" style=""font-size:0.55rem;""></span>")]
        [InlineData(TypeSizeText.Small, @"<span class=""fas fa-star"" style=""font-size:0.75rem;""></span>")]
        [InlineData(TypeSizeText.Large, @"<span class=""fas fa-star"" style=""font-size:1.5rem;""></span>")]
        [InlineData(TypeSizeText.ExtraLarge, @"<span class=""fas fa-star"" style=""font-size:2rem;""></span>")]
        public void Size(TypeSizeText size, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlIcon()
            {
                Icon = new IconStar(),
                Size = new PropertySizeText(size)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html.Trim());
        }

        /// <summary>
        /// Tests the vertical alignment property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(TypeVerticalAlignment.Default, @"<span class=""fas fa-star""></span>")]
        [InlineData(TypeVerticalAlignment.Middle, @"<span class=""fas fa-star align-middle""></span>")]
        [InlineData(TypeVerticalAlignment.TextTop, @"<span class=""fas fa-star align-text-top""></span>")]
        [InlineData(TypeVerticalAlignment.TextBottom, @"<span class=""fas fa-star align-text-bottom""></span>")]
        [InlineData(TypeVerticalAlignment.Bottom, @"<span class=""fas fa-star align-bottom""></span>")]
        public void VerticalAlignment(TypeVerticalAlignment verticalAlignment, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlIcon()
            {
                Icon = new IconStar(),
                VerticalAlignment = verticalAlignment
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html.Trim());
        }
    }
}
