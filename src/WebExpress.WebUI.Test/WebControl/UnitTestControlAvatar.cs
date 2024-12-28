using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the avatar control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlAvatar
    {
        /// <summary>
        /// Tests the id property of the avatar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""profile""></div>")]
        [InlineData("id", @"<div id=""id"" class=""profile""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAvatar(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the user property of the avatar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""profile""></div>")]
        [InlineData("me", @"<div class=""profile""><b class=""bg-info text-light"">m</b>me</div>")]
        public void User(string user, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAvatar()
            {
                User = user
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the image property of the avatar control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""profile""></div>")]
        [InlineData("http://example.com", @"<div class=""profile""><img src=""http://example.com/""></div>")]
        public void Image(string uri, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAvatar()
            {
                Image = uri != null ? new Uri(uri) : null
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text color property of the avatar control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorText.Default, @"<div class=""profile""></div>")]
        [InlineData(TypeColorText.Primary, @"<div class=""profile text-primary""></div>")]
        [InlineData(TypeColorText.Secondary, @"<div class=""profile text-secondary""></div>")]
        [InlineData(TypeColorText.Info, @"<div class=""profile text-info""></div>")]
        [InlineData(TypeColorText.Success, @"<div class=""profile text-success""></div>")]
        [InlineData(TypeColorText.Warning, @"<div class=""profile text-warning""></div>")]
        [InlineData(TypeColorText.Danger, @"<div class=""profile text-danger""></div>")]
        [InlineData(TypeColorText.Light, @"<div class=""profile text-light""></div>")]
        [InlineData(TypeColorText.Dark, @"<div class=""profile text-dark""></div>")]
        [InlineData(TypeColorText.Muted, @"<div class=""profile text-muted""></div>")]
        public void TextColor(TypeColorText color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAvatar()
            {
                TextColor = new PropertyColorText(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the background color property of the avatar control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div class=""profile""></div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""profile bg-primary""></div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""profile bg-secondary""></div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""profile bg-warning""></div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""profile bg-danger""></div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""profile bg-dark""></div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""profile bg-light""></div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""profile bg-transparent""></div>")]
        public void BackgroundColor(TypeColorBackground backgroundColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlAvatar()
            {
                BackgroundColor = new PropertyColorBackground(backgroundColor)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
