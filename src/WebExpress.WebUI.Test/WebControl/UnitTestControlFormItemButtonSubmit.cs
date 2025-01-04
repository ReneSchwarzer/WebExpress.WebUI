using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the form submit button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlFormItemButtonSubmit
    {
        /// <summary>
        /// Tests the id property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        [InlineData("id", @"<button id=""id"" name=""id"" type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the text property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button type=""submit"" class=""btn me-2 btn-success"" *></button>")]
        [InlineData("abc", @"<button type=""submit"" class=""btn me-2 btn-success"" *>abc</button>")]
        public void Text(string text, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Text = text
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the size property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(TypeSizeButton.Default, @"<button type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        [InlineData(TypeSizeButton.Small, @"<button type=""submit"" class=""btn me-2 btn-success btn-sm"" *>Submit</button>")]
        [InlineData(TypeSizeButton.Large, @"<button type=""submit"" class=""btn me-2 btn-success btn-lg"" *>Submit</button>")]
        public void Size(TypeSizeButton size, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Size = size
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the backgroundcolor property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<button type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Primary, @"<button type=""submit"" class=""btn bg-primary *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Secondary, @"<button type=""submit"" class=""btn bg-secondary *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Warning, @"<button type=""submit"" class=""btn bg-warning *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Danger, @"<button type=""submit"" class=""btn bg-danger *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Dark, @"<button type=""submit"" class=""btn bg-dark *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Light, @"<button type=""submit"" class=""btn bg-light *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.White, @"<button type=""submit"" class=""btn bg-white *"" *>Submit</button>")]
        [InlineData(TypeColorBackground.Transparent, @"<button type=""submit"" class=""btn bg-transparent *"" *>Submit</button>")]
        public void BackgroundColor(TypeColorBackground color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                BackgroundColor = new PropertyColorBackground(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorButton.Default, @"<button type=""submit"" class=""btn me-2"" *>Submit</button>")]
        [InlineData(TypeColorButton.Primary, @"<button type=""submit"" class=""btn me-2 btn-primary"" *>Submit</button>")]
        [InlineData(TypeColorButton.Secondary, @"<button type=""submit"" class=""btn me-2 btn-secondary"" *>Submit</button>")]
        [InlineData(TypeColorButton.Warning, @"<button type=""submit"" class=""btn me-2 btn-warning"" *>Submit</button>")]
        [InlineData(TypeColorButton.Danger, @"<button type=""submit"" class=""btn me-2 btn-danger"" *>Submit</button>")]
        [InlineData(TypeColorButton.Dark, @"<button type=""submit"" class=""btn me-2 btn-dark"" *>Submit</button>")]
        [InlineData(TypeColorButton.Light, @"<button type=""submit"" class=""btn me-2 btn-light"" *>Submit</button>")]
        public void Color(TypeColorButton color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Color = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the outline property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(false, TypeColorButton.Default, @"<button type=""submit"" class=""btn me-2"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Default, @"<button type=""submit"" class=""btn me-2"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Primary, @"<button type=""submit"" class=""btn me-2 btn-outline-primary"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Secondary, @"<button type=""submit"" class=""btn me-2 btn-outline-secondary"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Warning, @"<button type=""submit"" class=""btn me-2 btn-outline-warning"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Danger, @"<button type=""submit"" class=""btn me-2 btn-outline-danger"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Dark, @"<button type=""submit"" class=""btn me-2 btn-outline-dark"" *>Submit</button>")]
        [InlineData(true, TypeColorButton.Light, @"<button type=""submit"" class=""btn me-2"" *>Submit</button>")]
        public void Outline(bool outline, TypeColorButton color, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Outline = outline,
                Color = new PropertyColorButton(color)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the block property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(TypeBlockButton.None, @"<button type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        [InlineData(TypeBlockButton.Block, @"<button type=""submit"" class=""btn me-2 btn-success btn-block"" *>Submit</button>")]
        public void Block(TypeBlockButton block, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Block = block
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the icon property of the form submit button control.
        /// </summary>
        [Theory]
        [InlineData(TypeIcon.None, @"<button type=""submit"" class=""btn me-2 btn-success"" *>Submit</button>")]
        [InlineData(TypeIcon.Star, @"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-star""></span>Submit</button>")]
        public void Icon(TypeIcon icon, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlFormItemButtonSubmit()
            {
                Icon = new PropertyIcon(icon)
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the form submit button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var form = new ControlForm();
            var context = new RenderControlFormContext(UnitTestControlFixture.CrerateRenderContextMock(), form);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control1 = new ControlFormItemButtonSubmit(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlFormItemButtonSubmit(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlFormItemButtonSubmit(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            var control4 = new ControlFormItemButtonSubmit(null);
            var control5 = new ControlFormItemButtonSubmit(null);
            var control6 = new ControlFormItemButtonSubmit(null);

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

            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html1.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html2.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html3.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html4.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html5.Trim());
            AssertExtensions.EqualWithPlaceholders(@"<button type=""submit"" class=""btn me-2 btn-success"" *><span class=""me-2 fas fa-save""></span>Submit<span class=""fas fa-star""></span></button>", html6.Trim());
        }
    }
}
