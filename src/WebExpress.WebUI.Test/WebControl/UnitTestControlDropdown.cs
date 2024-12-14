﻿using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the dropdown control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlDropdown
    {
        /// <summary>
        /// Tests the id property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("id", @"<div id=""id"" class=""dropdown""><button id=""id_btn"" class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.ToString()));
        }

        /// <summary>
        /// Tests the background color property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorButton.Default, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Primary, @"<div class=""dropdown""><button class=""btn btn-primary"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Secondary, @"<div class=""dropdown""><button class=""btn btn-secondary"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Info, @"<div class=""dropdown""><button class=""btn btn-info"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Warning, @"<div class=""dropdown""><button class=""btn btn-warning"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Danger, @"<div class=""dropdown""><button class=""btn btn-danger"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Light, @"<div class=""dropdown""><button class=""btn btn-light"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeColorButton.Dark, @"<div class=""dropdown""><button class=""btn btn-dark"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void BackgroundColor(TypeColorButton backgroundColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                BackgroundColor = new PropertyColorButton(backgroundColor)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the size property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeSizeButton.Small, @"<div class=""dropdown""><button class=""btn btn-sm"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeSizeButton.Large, @"<div class=""dropdown""><button class=""btn btn-lg"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Size = size
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the outline property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<div class=""dropdown""><button class=""btn btn-primary"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(true, @"<div class=""dropdown""><button class=""btn btn-outline-primary"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Outline(bool outline, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Outline = outline,
                BackgroundColor = new PropertyColorButton(TypeColorButton.Primary)
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the block property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(TypeBlockButton.None, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeBlockButton.Block, @"<div class=""dropdown""><button class=""btn btn-block"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Block(TypeBlockButton block, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Block = block
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the toogle property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(TypeToggleDropdown.None, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData(TypeToggleDropdown.Toggle, @"<div class=""dropdown""><button class=""btn dropdown-toggle"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Toogle(TypeToggleDropdown toogle, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Toogle = toogle
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the text property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("abc", @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false"">abc</button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false"">WebExpress.WebUI</button><ul class=""dropdown-menu""></ul></div>")]
        public void Text(string text, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Text = text,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the tooltip property of the dropdown control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""dropdown""><button class=""btn"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("abc", @"<div class=""dropdown""><button class=""btn"" title=""abc"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        [InlineData("webexpress.WebUI:plugin.name", @"<div class=""dropdown""><button class=""btn"" title=""WebExpress.WebUI"" data-bs-toggle=""dropdown"" aria-expanded=""false""></button><ul class=""dropdown-menu""></ul></div>")]
        public void Tooltip(string tooltip, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlDropdown()
            {
                Tooltip = tooltip,
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        ///// <summary>
        ///// Tests the add function of the dropdown control.
        ///// </summary>
        //[Theory]
        //[InlineData(typeof(ControlText), @"<div><div></div></div>")]
        //[InlineData(typeof(ControlLink), @"<div><a class=""link""></a></div>")]
        //[InlineData(typeof(ControlImage), @"<div><img></div>")]
        //public void Add(Type child, string expected)
        //{
        //    // preconditions
        //    UnitTestControlFixture.CreateAndRegisterComponentHubMock();
        //    var context = UnitTestControlFixture.CrerateRenderContextMock();
        //    var childInstance = Activator.CreateInstance(child, [null]) as IControl;
        //    var control = new ControlDropdown();

        //    // test execution
        //    control.AddChild(childInstance);

        //    var html = control.Render(context);

        //    Assert.Equal(expected, html.Trim());
        //}
    }
}
