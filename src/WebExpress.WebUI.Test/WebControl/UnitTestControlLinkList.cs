﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the link list control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlLinkList
    {
        /// <summary>
        /// Tests the id property of the link list control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name property of the link list control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div></div>")]
        [InlineData("abc", @"<div><span>abc</span></div>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<div><span>WebExpress.WebUI</span></div>")]
        public void Name(string name, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList()
            {
                Name = name,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the name color property of the link list control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorText.Default, @"<div><span>abc</span></div>")]
        [InlineData(TypeColorText.Primary, @"<div><span class=""text-primary"">abc</span></div>")]
        [InlineData(TypeColorText.Secondary, @"<div><span class=""text-secondary"">abc</span></div>")]
        [InlineData(TypeColorText.Info, @"<div><span class=""text-info"">abc</span></div>")]
        [InlineData(TypeColorText.Success, @"<div><span class=""text-success"">abc</span></div>")]
        [InlineData(TypeColorText.Warning, @"<div><span class=""text-warning"">abc</span></div>")]
        [InlineData(TypeColorText.Danger, @"<div><span class=""text-danger"">abc</span></div>")]
        [InlineData(TypeColorText.Light, @"<div><span class=""text-light"">abc</span></div>")]
        [InlineData(TypeColorText.Dark, @"<div><span class=""text-dark"">abc</span></div>")]
        [InlineData(TypeColorText.Muted, @"<div><span class=""text-muted"">abc</span></div>")]
        public void NameColor(TypeColorText color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList()
            {
                Name = "abc",
                NameColor = new PropertyColorText(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the link list control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<div></div>")]
        [InlineData(TypeIcon.Star, @"<div><span class=""fas fa-star""></span></div>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the link list control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div></div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""bg-primary""></div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""bg-secondary""></div>")]
        [InlineData(TypeColorBackground.Info, @"<div class=""bg-info""></div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""bg-warning""></div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""bg-danger""></div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""bg-light""></div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""bg-dark""></div>")]
        [InlineData(TypeColorBackground.White, @"<div class=""bg-white""></div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""bg-transparent""></div>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the link list control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlLinkList();

            // test execution
            control.Add(new ControlLink() { Text = "abc" });

            var html = control.Render(context);

            Assert.Equal(@"<div><a class=""link"">abc</a></div>", html.Trim());
        }
    }
}
