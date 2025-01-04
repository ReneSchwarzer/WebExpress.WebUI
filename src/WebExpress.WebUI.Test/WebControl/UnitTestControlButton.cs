﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlButton
    {
        /// <summary>
        /// Tests the id property of the button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""button"" class=""btn""></button>")]
        [InlineData("id", @"<button id=""id"" type=""button"" class=""btn""></button>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""button"" class=""btn""></button>")]
        [InlineData("abc", @"<button type=""button"" class=""btn"">abc</button>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the button control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeSizeButton.Small, @"<button type=""button"" class=""btn btn-sm""></button>")]
        [InlineData(TypeSizeButton.Large, @"<button type=""button"" class=""btn btn-lg""></button>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                Size = size
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the backgroundcolor property of the button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeColorButton.Primary, @"<button type=""button"" class=""btn btn-primary""></button>")]
        [InlineData(TypeColorButton.Secondary, @"<button type=""button"" class=""btn btn-secondary""></button>")]
        [InlineData(TypeColorButton.Warning, @"<button type=""button"" class=""btn btn-warning""></button>")]
        [InlineData(TypeColorButton.Danger, @"<button type=""button"" class=""btn btn-danger""></button>")]
        [InlineData(TypeColorButton.Dark, @"<button type=""button"" class=""btn btn-dark""></button>")]
        public void BackgroundColor(TypeColorButton color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                BackgroundColor = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the button control.
        /// </summary>
        [Theory]
        [InlineData(false, TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(true, TypeColorButton.Default, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(true, TypeColorButton.Primary, @"<button type=""button"" class=""btn btn-outline-primary""></button>")]
        [InlineData(true, TypeColorButton.Secondary, @"<button type=""button"" class=""btn btn-outline-secondary""></button>")]
        [InlineData(true, TypeColorButton.Warning, @"<button type=""button"" class=""btn btn-outline-warning""></button>")]
        [InlineData(true, TypeColorButton.Danger, @"<button type=""button"" class=""btn btn-outline-danger""></button>")]
        [InlineData(true, TypeColorButton.Dark, @"<button type=""button"" class=""btn btn-outline-dark""></button>")]
        public void Outline(bool outline, TypeColorButton color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                Outline = outline,
                BackgroundColor = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the block property of the button control.
        /// </summary>
        [Theory]
        [InlineData(TypeBlockButton.None, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeBlockButton.Block, @"<button type=""button"" class=""btn btn-block""></button>")]
        public void Block(TypeBlockButton block, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                Block = block
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the button control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<button type=""button"" class=""btn""></button>")]
        [InlineData(TypeIcon.Star, @"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlButton()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control1 = new ControlButton(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlButton(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlButton(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            var control4 = new ControlButton(null);
            var control5 = new ControlButton(null);
            var control6 = new ControlButton(null);

            // test execution
            control4.Add(new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            control5.Add([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]));

            var html1 = control1.Render(context, visualTree);
            var html2 = control2.Render(context, visualTree);
            var html3 = control3.Render(context, visualTree);
            var html4 = control4.Render(context, visualTree);
            var html5 = control5.Render(context, visualTree);
            var html6 = control6.Render(context, visualTree);

            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html1.Trim());
            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html2.Trim());
            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html3.Trim());
            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html4.Trim());
            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html5.Trim());
            Assert.Equal(@"<button type=""button"" class=""btn""><span class=""fas fa-star""></span></button>", html6.Trim());
        }
    }
}
