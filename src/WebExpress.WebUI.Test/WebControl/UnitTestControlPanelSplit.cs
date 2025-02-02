using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the panel split control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlPanelSplit
    {
        /// <summary>
        /// Tests the id property of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""d-flex split"">*</div>")]
        [InlineData("id", @"<div id=""id"" class=""d-flex split"">*</div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelSplit(id);
            control.AddPanel1(new ControlText() { Text = "p1" });
            control.AddPanel2(new ControlText() { Text = "p2" });

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the orientation property of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(TypeOrientationSplit.Horizontal, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeOrientationSplit.Vertical, @"<div class=""split"">*</div>")]
        public void Orientation(TypeOrientationSplit orientation, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelSplit()
            {
                Orientation = orientation,
            };
            control.AddPanel1(new ControlText() { Text = "p1" });
            control.AddPanel2(new ControlText() { Text = "p2" });

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the splitter color property of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""d-flex split"">*</div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""d-flex split"">*</div>")]
        public void SplitterColor(TypeColorBackground splitterColor, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlPanelSplit()
            {
                SplitterColor = new PropertyColorBackground(splitterColor),
            };
            control.AddPanel1(new ControlText() { Text = "p1" });
            control.AddPanel2(new ControlText() { Text = "p2" });

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(null, null, null)]
        [InlineData(typeof(ControlText), null, @"<div></div>")]
        [InlineData(null, typeof(ControlText), @"<div></div>")]
        [InlineData(typeof(ControlText), typeof(ControlText), @"<div class=""d-flex split""><div id=""-p1""><div></div></div><div id=""-p2""><div></div></div></div>")]
        [InlineData(typeof(ControlLink), typeof(ControlLink), @"<div class=""d-flex split""><div id=""-p1""><a class=""link""></a></div><div id=""-p2""><a class=""link""></a></div></div>")]
        [InlineData(typeof(ControlImage), typeof(ControlImage), @"<div class=""d-flex split""><div id=""-p1""><img></div><div id=""-p2""><img></div></div>")]
        public void Add(Type child1, Type child2, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var childInstance1 = child1 != null ? Activator.CreateInstance(child1, [null]) as IControl : null;
            var childInstance2 = child2 != null ? Activator.CreateInstance(child2, [null]) as IControl : null;
            var control = new ControlPanelSplit();

            // test execution
            if (childInstance1 != null)
            {
                control.AddPanel1(childInstance1);
            }

            if (childInstance2 != null)
            {
                control.AddPanel2(childInstance2);
            }

            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
