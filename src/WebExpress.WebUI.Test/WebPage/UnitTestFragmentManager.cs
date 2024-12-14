﻿using WebExpress.WebUI.Test.Fixture;

namespace WebExpress.WebUI.Test.WebPage
{
    /// <summary>
    /// Test the fragment manager.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestPageManager
    {
        /// <summary>
        /// Test the id property of the page manager.
        /// </summary>
        [Theory]
        [InlineData(typeof(TestApplication), typeof(TestPage), "webexpress.webui.test.testpage")]
        public void Id(Type applicationType, Type pageType, string id)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(applicationType).FirstOrDefault();

            // test execution
            var page = componentHub.PageManager.GetPages(pageType, application);

            if (id == null)
            {
                Assert.Empty(page);
                return;
            }

            Assert.Contains(id, page.Select(x => x.EndpointId?.ToString()));
        }
    }
}
