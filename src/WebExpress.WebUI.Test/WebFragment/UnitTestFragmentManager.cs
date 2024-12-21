using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.Test.Fixture;

namespace WebExpress.WebUI.Test.WebFragment
{
    /// <summary>
    /// Test the fragment manager.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestFragmentManager
    {
        /// <summary>
        /// Test the id property of the fragment manager.
        /// </summary>
        [Theory]
        [InlineData(typeof(TestApplication), typeof(TestFragmentControlText), "webexpress.webui.test.testfragmentcontroltext")]
        [InlineData(typeof(TestApplication), typeof(TestFragmentControlList), "webexpress.webui.test.testfragmentcontrollist")]
        [InlineData(typeof(TestApplication), typeof(TestFragmentControlLink), "webexpress.webui.test.testfragmentcontrollink")]
        public void Id(Type applicationType, Type fragmentType, string id)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(applicationType).FirstOrDefault();

            // test execution
            var fragment = componentHub.FragmentManager.GetFragments(application, fragmentType);

            if (id == null)
            {
                Assert.Empty(fragment);
                return;
            }

            Assert.Contains(id, fragment.Select(x => x.FragmentId?.ToString()));
        }

        /// <summary>
        /// Test the render function of the fragment manager.
        /// </summary>
        [Theory]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlText), typeof(IScope), @"<p id=""webexpress.webui.test.testfragmentcontroltext"">TestFragmentControlText</p>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlList), typeof(IScope), @"<ul id=""webexpress.webui.test.testfragmentcontrollist""><li></li></ul>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlLink), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrollink"" class=""link"">TestFragmentControlLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlButtonLink), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrolbuttonlink"" class=""btn"">TestFragmentControlButtonLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlImage), typeof(IScope), @"<img id=""webexpress.webui.test.testfragmentcontrolimage"" src=""/a/b/c"">")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlDropdownItemLink), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontroldropdownitemlink"" class=""link"">TestFragmentControlDropdownItemLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlNavigationItemLink), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrolnavigationitemlink"" class=""link"">TestFragmentControlNavigationItemLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlPanel), typeof(IScope), @"<div id=""webexpress.webui.test.testfragmentcontrolpanel""><div>TestFragmentControlPanel</div></div>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlPanelFlexbox), typeof(IScope), @"<div id=""webexpress.webui.test.testfragmentcontrolpanelflexbox""></div>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionFragmentControlSplitButtonItemLink), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrolsplitbuttonitemlink"" class=""link"">TestFragmentControlSplitButtonItemLink</a>")]
        //[InlineData(typeof(TestApplication), typeof(TestSectionK), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrol"" class=""link"">TestFragmentControl</a>")]
        public void Render(Type applicationType, Type sectionType, Type scopeType, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(applicationType).FirstOrDefault();
            var renderContext = UnitTestControlFixture.CrerateRenderContextMock(application, [scopeType]);

            // test execution
            var html = componentHub.FragmentManager.Render(renderContext, sectionType);

            Assert.NotNull(html);
            Assert.NotEmpty(html);
            AssertExtensions.EqualWithPlaceholders(expected, html.FirstOrDefault()?.ToString());
        }
    }
}
