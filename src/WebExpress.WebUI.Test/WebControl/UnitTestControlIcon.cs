using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

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
        [InlineData(null, @"<span></span>")]
        [InlineData("id", @"<span id=""id""></span>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlIcon(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the title property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<span></span>")]
        [InlineData("abc", @"<span title=""abc""></span>")]
        public void Title(string title, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlIcon()
            {
                Title = title
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the icon property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<span></span>")]
        [InlineData(TypeIcon.Star, @"<span class=""fas fa-star""></span>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlIcon()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the size property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeText.Default, @"<span></span>")]
        [InlineData(TypeSizeText.ExtraSmall, @"<span style=""font-size:0.55rem;""></span>")]
        [InlineData(TypeSizeText.Small, @"<span style=""font-size:0.75rem;""></span>")]
        [InlineData(TypeSizeText.Large, @"<span style=""font-size:1.5rem;""></span>")]
        [InlineData(TypeSizeText.ExtraLarge, @"<span style=""font-size:2rem;""></span>")]
        public void Size(TypeSizeText size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlIcon()
            {
                Size = new PropertySizeText(size)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the vertical alignment property of the icon control.
        /// </summary>
        [Theory]
        [InlineData(TypeVerticalAlignment.Default, @"<span></span>")]
        [InlineData(TypeVerticalAlignment.Middle, @"<span class=""align-middle""></span>")]
        [InlineData(TypeVerticalAlignment.TextTop, @"<span class=""align-text-top""></span>")]
        [InlineData(TypeVerticalAlignment.TextBottom, @"<span class=""align-text-bottom""></span>")]
        [InlineData(TypeVerticalAlignment.Bottom, @"<span class=""align-bottom""></span>")]
        public void VerticalAlignment(TypeVerticalAlignment verticalAlignment, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlIcon()
            {
                VerticalAlignment = verticalAlignment
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
