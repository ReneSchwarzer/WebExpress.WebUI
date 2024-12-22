﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemButton
    {
        /// <summary>
        /// Tests the id property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""button"" class=""btn""></button>")]
        [InlineData("id", @"<button id=""id"" type=""button"" class=""btn""></button>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""button"" class=""btn""></button>")]
        [InlineData("abc", @"<button type=""button"" class=""btn"">abc</button>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeSizeButton.Small, @"<button type=""button"" class=""btn btn-sm""></button>")]
        [InlineData(TypeSizeButton.Large, @"<button type=""button"" class=""btn btn-lg""></button>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Size = size
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the backgroundcolor property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeColorBackground.Primary, @"<button type=""button"" class=""btn bg-primary""></button>")]
        [InlineData(TypeColorBackground.Secondary, @"<button type=""button"" class=""btn bg-secondary""></button>")]
        [InlineData(TypeColorBackground.Warning, @"<button type=""button"" class=""btn bg-warning""></button>")]
        [InlineData(TypeColorBackground.Danger, @"<button type=""button"" class=""btn bg-danger""></button>")]
        [InlineData(TypeColorBackground.Dark, @"<button type=""button"" class=""btn bg-dark""></button>")]
        [InlineData(TypeColorBackground.Light, @"<button type=""button"" class=""btn bg-light""></button>")]
        [InlineData(TypeColorBackground.White, @"<button type=""button"" class=""btn bg-white""></button>")]
        [InlineData(TypeColorBackground.Transparent, @"<button type=""button"" class=""btn bg-transparent""></button>")]
        public void BackgroundColor(TypeColorBackground color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                BackgroundColor = new PropertyColorBackground(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeColorButton.Primary, @"<button type=""button"" class=""btn btn-primary""></button>")]
        [InlineData(TypeColorButton.Secondary, @"<button type=""button"" class=""btn btn-secondary""></button>")]
        [InlineData(TypeColorButton.Warning, @"<button type=""button"" class=""btn btn-warning""></button>")]
        [InlineData(TypeColorButton.Danger, @"<button type=""button"" class=""btn btn-danger""></button>")]
        [InlineData(TypeColorButton.Dark, @"<button type=""button"" class=""btn btn-dark""></button>")]
        [InlineData(TypeColorButton.Light, @"<button type=""button"" class=""btn btn-light""></button>")]
        public void Color(TypeColorButton color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Color = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(false, TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(true, TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(true, TypeColorButton.Primary, @"<button type=""button"" class=""btn btn-outline-primary""></button>")]
        [InlineData(true, TypeColorButton.Secondary, @"<button type=""button"" class=""btn btn-outline-secondary""></button>")]
        [InlineData(true, TypeColorButton.Warning, @"<button type=""button"" class=""btn btn-outline-warning""></button>")]
        [InlineData(true, TypeColorButton.Danger, @"<button type=""button"" class=""btn btn-outline-danger""></button>")]
        [InlineData(true, TypeColorButton.Dark, @"<button type=""button"" class=""btn btn-outline-dark""></button>")]
        [InlineData(true, TypeColorButton.Light, @"<button type=""button"" class=""btn""></button>")]
        public void Outline(bool outline, TypeColorButton color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Outline = outline,
                Color = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the block property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(TypeBlockButton.None, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeBlockButton.Block, @"<button type=""button"" class=""btn btn-block""></button>")]
        public void Block(TypeBlockButton block, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Block = block
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the form button control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeIcon.Star, @"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control = new ControlFormItemButton()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the form button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var control1 = new ControlFormItemButton(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlFormItemButton(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlFormItemButton(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            var control4 = new ControlFormItemButton(null);
            var control5 = new ControlFormItemButton(null);
            var control6 = new ControlFormItemButton(null);

            // test execution
            control4.Add(new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            control5.Add([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]));

            var html1 = control1.Render(context);
            var html2 = control2.Render(context);
            var html3 = control2.Render(context);
            var html4 = control1.Render(context);
            var html5 = control2.Render(context);
            var html6 = control2.Render(context);

            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html1.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html2.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html3.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html4.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html5.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html6.Trim());
        }
    }
}
