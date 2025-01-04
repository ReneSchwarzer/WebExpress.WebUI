using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the tree control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlTree : IClassFixture<UnitTestControlFixture>
    {
        /// <summary>
        /// Tests the id property of the tree control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<ul></ul>")]
        [InlineData("id", @"<ul id=""id""></ul>")]
        [InlineData("03C6031F-04A9-451F-B817-EBD6D32F8B0C", @"<ul id=""03C6031F-04A9-451F-B817-EBD6D32F8B0C""></ul>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTree(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the layout property of the tree control.
        /// </summary>
        [Theory]
        [InlineData(TypeLayoutTree.Default, @"<ul></ul>")]
        [InlineData(TypeLayoutTree.Simple, @"<ul class=""tree-simple""></ul>")]
        [InlineData(TypeLayoutTree.Group, @"<ul class=""list-group""></ul>")]
        [InlineData(TypeLayoutTree.Horizontal, @"<ul class=""list-group list-group-horizontal""></ul>")]
        [InlineData(TypeLayoutTree.Flat, @"<ul class=""list-unstyled""></ul>")]
        [InlineData(TypeLayoutTree.Flush, @"<ul class=""list-group list-group-flush""></ul>")]
        [InlineData(TypeLayoutTree.TreeView, @"<ul class=""tree-treeview""></ul>")]
        public void Layout(TypeLayoutTree layout, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTree()
            {
                Layout = layout
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the sorted property of the tree control.
        /// </summary>
        [Theory]
        [InlineData(false, @"<ul></ul>")]
        [InlineData(true, @"<ul></ul>")]
        public void Sorted(bool sorted, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlTree()
            {
                Sorted = sorted
            };

            // test execution
            var html = control.Render(context, visualTree);

            Assert.Equal(expected, html.Trim());
        }

        /// <summary>
        /// Tests the add function of the tree control.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetControlTreeItemsData))]
        public void Add(IEnumerable<ControlTreeItem> items, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);

            // test execution
            var control = new ControlTree(null, items.ToArray());
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }

        /// <summary>
        /// Provides test data for the Add method of the UnitTestControlList class.
        /// </summary>
        /// <returns>An enumerable collection of object arrays, each containing test data.</returns>
        public static TheoryData<IEnumerable<ControlTreeItem>, string> GetControlTreeItemsData()
        {
            return new TheoryData<IEnumerable<ControlTreeItem>, string>
            {
                { new List<ControlTreeItem> { new(null, new ControlText() { Text = "Item 1" }) }, @"<ul><li><div><div>Item 1</div></div></li></ul>" },
                { new List<ControlTreeItem> { new("id") }, @"<ul><li id=""id""><div></div></li></ul>" },
                { new List<ControlTreeItem> { }, "<ul></ul>" }
            };
        }
    }
}
