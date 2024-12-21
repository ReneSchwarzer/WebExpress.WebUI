﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the split button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlSplitButton
    {
        /// <summary>
        /// Tests the id property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""btn-group""><button class=""btn""></button><button class=""btn dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" data-bs-toggle=""dropdown"" aria-expanded=""false""><span class=""caret""></span></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("id", @"<div id=""id"" class=""btn-group""><button id=""id_btn"" class=""btn""></button><button id=""id_toggle"" class=""btn dropdown-toggle dropdown-toggle-split"" data-toggle=""dropdown"" data-bs-toggle=""dropdown"" aria-expanded=""false""><span class=""caret""></span></button><ul class=""dropdown-menu""></ul></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData("abc", @"<div class=""btn-group""><button class=""btn"">abc</button>*</div>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(TypeSizeButton.Small, @"<div class=""btn-group""><button class=""btn btn-sm""></button><button class=""btn * btn-sm"" *</div>")]
        [InlineData(TypeSizeButton.Large, @"<div class=""btn-group""><button class=""btn btn-lg""></button><button class=""btn * btn-lg"" *</div>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                Size = size
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the backgroundcolor property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorButton.Default, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(TypeColorButton.Primary, @"<div class=""btn-group""><button class=""btn btn-primary""></button><button class=""btn * btn-primary"" *")]
        [InlineData(TypeColorButton.Secondary, @"<div class=""btn-group""><button class=""btn btn-secondary""></button><button class=""btn * btn-secondary"" *")]
        [InlineData(TypeColorButton.Warning, @"<div class=""btn-group""><button class=""btn btn-warning""></button><button class=""btn * btn-warning"" *")]
        [InlineData(TypeColorButton.Danger, @"<div class=""btn-group""><button class=""btn btn-danger""></button><button class=""btn * btn-danger"" *")]
        [InlineData(TypeColorButton.Dark, @"<div class=""btn-group""><button class=""btn btn-dark""></button><button class=""btn * btn-dark"" *")]
        public void BackgroundColor(TypeColorButton color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                BackgroundColor = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(false, TypeColorButton.Default, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(true, TypeColorButton.Default, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(true, TypeColorButton.Primary, @"<div class=""btn-group""><button class=""btn btn-outline-primary""></button><button class=""btn * btn-outline-primary"" *")]
        [InlineData(true, TypeColorButton.Secondary, @"<div class=""btn-group""><button class=""btn btn-outline-secondary""></button><button class=""btn * btn-outline-secondary"" *")]
        [InlineData(true, TypeColorButton.Warning, @"<div class=""btn-group""><button class=""btn btn-outline-warning""></button><button class=""btn * btn-outline-warning"" *")]
        [InlineData(true, TypeColorButton.Danger, @"<div class=""btn-group""><button class=""btn btn-outline-danger""></button><button class=""btn * btn-outline-danger"" *")]
        [InlineData(true, TypeColorButton.Dark, @"<div class=""btn-group""><button class=""btn btn-outline-dark""></button><button class=""btn * btn-outline-dark"" *")]
        public void Outline(bool outline, TypeColorButton color, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                Outline = outline,
                BackgroundColor = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the block property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(TypeBlockButton.None, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(TypeBlockButton.Block, @"<div class=""btn-group btn-block""><button class=""btn btn-block""></button>*</div>")]
        public void Block(TypeBlockButton block, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                Block = block
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the split button control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<div class=""btn-group""><button class=""btn""></button>*</div>")]
        [InlineData(TypeIcon.Star, @"<div class=""btn-group""><button class=""btn""><span class=""fas fa-star""></span></button>*</div>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlSplitButton()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the split button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            //UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            //var context = UnitTestControlFixture.CrerateRenderContextMock();
            //var control1 = new ControlSplitButton(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            //var control2 = new ControlSplitButton(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            //var control3 = new ControlSplitButton(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            //var control4 = new ControlSplitButton(null);
            //var control5 = new ControlSplitButton(null);
            //var control6 = new ControlSplitButton(null);

            //// test execution
            //control4.Add(new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            //control5.Add([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            //control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());

            //var html1 = control1.Render(context);
            //var html2 = control2.Render(context);
            //var html3 = control2.Render(context);
            //var html4 = control1.Render(context);
            //var html5 = control2.Render(context);
            //var html6 = control2.Render(context);

            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html1.Trim());
            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html2.Trim());
            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html3.Trim());
            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html4.Trim());
            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html5.Trim());
            //AssertExtensions.EqualWithPlaceholders(@"<div class=""btn-group ""><button class=""btn""></button>*</div>", html6.Trim());
        }
    }
}
