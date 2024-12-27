using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the list item button control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlListItemButton
    {
        /// <summary>
        /// Tests the id property of the list item button control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<button class=""list-group-item-action""></button>")]
        [InlineData("id", @"<button id=""id"" class=""list-group-item-action""></button>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlListItemButton(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the Active property of the list item button control.
        /// </summary>
        [Theory]
        [InlineData(TypeActive.None, @"<button class=""list-group-item-action""></button>")]
        [InlineData(TypeActive.Active, @"<button class=""list-group-item-action active""></button>")]
        public void Active(TypeActive active, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlListItemButton(null)
            {
                Active = active
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the list item button control.
        /// </summary>
        [Fact]
        public void Add()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control1 = new ControlListItemButton(null, new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            var control2 = new ControlListItemButton(null, [new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            var control3 = new ControlListItemButton(null, new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());
            var control4 = new ControlListItemButton(null);
            var control5 = new ControlListItemButton(null);
            var control6 = new ControlListItemButton(null);

            // test execution
            control4.Add(new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) });
            control5.Add([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]);
            control6.Add(new List<ControlIcon>([new ControlIcon() { Icon = new PropertyIcon(TypeIcon.Star) }]).ToArray());

            var html1 = control1.Render(context);
            var html2 = control2.Render(context);
            var html3 = control3.Render(context);
            var html4 = control4.Render(context);
            var html5 = control5.Render(context);
            var html6 = control6.Render(context);

            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html1);
            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html2);
            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html3);
            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html4);
            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html5);
            AssertExtensions.EqualWithPlaceholders(@"<button class=""list-group-item-action""><span class=""fas fa-star""></span></button>", html6);
        }
    }
}
