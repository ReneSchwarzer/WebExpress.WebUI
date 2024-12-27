using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

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
        [InlineData(null, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""d-flex split border""><div id=""id-p1""></div><div id=""id-p2""></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelSplit(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the orientation property of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(TypeOrientationSplit.Horizontal, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeOrientationSplit.Vertical, @"<div class=""split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        public void Orientation(TypeOrientationSplit orientation, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelSplit()
            {
                Orientation = orientation,
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the splitter color property of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(TypeColorBackground.Default, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Primary, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Secondary, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Warning, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Danger, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Dark, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Light, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]
        [InlineData(TypeColorBackground.Transparent, @"<div class=""d-flex split border""><div id=""-p1""></div><div id=""-p2""></div></div>")]

        public void SplitterColor(TypeColorBackground splitterColor, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlPanelSplit()
            {
                SplitterColor = new PropertyColorBackground(splitterColor),
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the panel split control.
        /// </summary>
        [Theory]
        [InlineData(typeof(ControlText), @"<div class=""d-flex split border""><div id=""-p1""><div></div></div><div id=""-p2""><div></div></div></div>")]
        [InlineData(typeof(ControlLink), @"<div class=""d-flex split border""><div id=""-p1""><a class=""link""></a></div><div id=""-p2""><a class=""link""></a></div></div>")]
        [InlineData(typeof(ControlImage), @"<div class=""d-flex split border""><div id=""-p1""><img></div><div id=""-p2""><img></div></div>")]
        public void Add(Type child, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var childInstance1 = Activator.CreateInstance(child, [null]) as IControl;
            var childInstance2 = Activator.CreateInstance(child, [null]) as IControl;
            var control = new ControlPanelSplit();

            // test execution
            control.AddPanel1(childInstance1);
            control.AddPanel2(childInstance2);

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
