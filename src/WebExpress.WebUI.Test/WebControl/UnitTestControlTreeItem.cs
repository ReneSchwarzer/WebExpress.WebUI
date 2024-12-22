using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the tree item control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTreeItem : IClassFixture<UnitTestControlFixture>
    {
        /// <summary>
        /// Tests the id property of the tree item control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<li><div></div></li>")]
        [InlineData("id", @"<li id=""id""><div></div></li>")]
        [InlineData("03C6031F-04A9-451F-B817-EBD6D32F8B0C", @"<li id=""03C6031F-04A9-451F-B817-EBD6D32F8B0C""><div></div></li>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the active property of the tree item control.
        /// </summary>
        [Theory]
        [InlineData(TypeActive.None, @"<li><div></div></li>")]
        [InlineData(TypeActive.Active, @"<li class=""active""><div class=""active""></div></li>")]
        [InlineData(TypeActive.Disabled, @"<li class=""disabled""><div class=""disabled""></div></li>")]
        public void Active(TypeActive active, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem()
            {
                Active = active
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the layout property of the tree item control.
        /// </summary>
        [Theory]
        [InlineData(TypeLayoutTreeItem.Default, @"<li><div></div></li>")]
        [InlineData(TypeLayoutTreeItem.Simple, @"<li><div class=""list-simple""></div></li>")]
        [InlineData(TypeLayoutTreeItem.Group, @"<li><div class=""list-group""></div></li>")]
        [InlineData(TypeLayoutTreeItem.Horizontal, @"<li><div class=""list-group list-group-horizontal""></div></li>")]
        [InlineData(TypeLayoutTreeItem.Flat, @"<li><div class=""list-unstyled""></div></li>")]
        [InlineData(TypeLayoutTreeItem.Flush, @"<li><div class=""list-group list-group-flush""></div></li>")]
        [InlineData(TypeLayoutTreeItem.TreeView, @"<li><div class=""tree-treeview-container"">*</div></li>")]
        public void Layout(TypeLayoutTreeItem layout, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem()
            {
                Layout = layout
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the expand property of the tree item control.
        /// </summary>
        [Theory]
        [InlineData(TypeExpandTree.None, @"<li><div></div></li>")]
        [InlineData(TypeExpandTree.Visible, @"<li><div></div></li>")]
        [InlineData(TypeExpandTree.Collapse, @"<li><div class=""tree-node-hide""></div></li>")]
        public void Expand(TypeExpandTree expand, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem()
            {
                Expand = expand
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Tests the add function of the tree item control.
        /// </summary>
        [Fact]
        public void AddContent()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem()
            {
            };

            // test execution
            control.Add(new ControlText() { Text = "abc" });

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(@"<li><div><div>abc</div></div></li>", html);
        }

        /// <summary>
        /// Tests the add function of the tree item control.
        /// </summary>
        [Fact]
        public void AddChild()
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlTreeItem()
            {
            };

            // test execution
            control.Add(new ControlTreeItem());

            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(@"<li><div></div><ul><li><div></div></li></ul></li>", html);
        }
    }
}
