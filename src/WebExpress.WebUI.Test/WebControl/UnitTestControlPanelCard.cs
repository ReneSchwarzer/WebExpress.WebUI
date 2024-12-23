﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the panel card control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelCard
    {
        /// <summary>
        /// Tests the id property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the header property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("header", @"<div class=""card border""><div class=""card-header"">header</div>*</div>")]
        public void Header(string header, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard()
            {
                Header = header
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the header image property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("headerImage", @"<div class=""card border""><img src=""headerImage"" class=""card-img-top"">*</div>")]
        public void HeaderImage(string headerImage, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard()
            {
                HeaderImage = headerImage
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the headline property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("headline", @"<div class=""card border"">*<h4 class=""card-title"">headline</h4>*</div>")]
        public void Headline(string headline, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard()
            {
                Headline = headline
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the footer property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("footer", @"<div class=""card border"">*<div class=""card-footer"">footer</div></div>")]
        public void Footer(string footer, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard()
            {
                Footer = footer
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the footer image property of the panel card control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""card border""><div class=""card-body""><div class=""card-text""></div></div></div>")]
        [InlineData("footerImage", @"<div class=""card border"">*<img src=""footerImage"" class=""card-img-top""></div>")]
        public void FooterImage(string footerImage, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelCard()
            {
                FooterImage = footerImage
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
