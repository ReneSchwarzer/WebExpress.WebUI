using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebPage;

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
        [InlineData(typeof(TestApplication), typeof(TestSectionA), typeof(IScope), @"<p id=""webexpress.webui.test.testfragmentcontroltext"">TestFragmentControlText</p>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionB), typeof(IScope), @"<ul id=""webexpress.webui.test.testfragmentcontrollist""><li></li></ul>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionC), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrollink"" class=""link"">TestFragmentControlLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionD), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontrolbuttonlink"" class=""btn"">TestFragmentControlButtonLink</a>")]
        [InlineData(typeof(TestApplication), typeof(TestSectionE), typeof(IScope), @"<img id=""webexpress.webui.test.testfragmentcontrolimage"" src=""/a/b/c"">")]
        [InlineData(typeof(TestApplication), typeof(TestSectionF), typeof(IScope), @"<a id=""webexpress.webui.test.testfragmentcontroldropdownitemlink"" class=""link"">TestFragmentControlDropdownItemLink</a>")]
        public void Render(Type applicationType, Type sectionType, Type scopeType, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(applicationType).FirstOrDefault();
            var renderContext = UnitTestControlFixture.CrerateRenderContextMock(application, [scopeType]);

            // test execution
            var html = componentHub.FragmentManager.Render<IRenderControlContext>(renderContext, sectionType);

            Assert.NotNull(html);
            Assert.NotEmpty(html);
            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.FirstOrDefault()?.ToString()));
        }
    }
}
