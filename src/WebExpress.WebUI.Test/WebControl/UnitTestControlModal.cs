using WebExpress.WebUI.Test.Fixture;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebUI.Test.WebControl
{
    /// <summary>
    /// Tests the modal control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlModal
    {
        /// <summary>
        /// Tests the id property of the modal control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""modal fade"" role=""dialog""><div class=""modal-dialog"" role=""document""><div class=""modal-content""><div class=""modal-header""><h4 class=""modal-title""></h4><button class=""btn-close"" aria-label=""close"" data-bs-dismiss=""modal""></button></div><div class=""modal-body""></div><div class=""modal-footer""><button type=""button"" class=""btn"" data-bs-dismiss=""modal"">Close</button></div></div></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""modal fade"" role=""dialog""><div class=""modal-dialog"" role=""document""><div class=""modal-content""><div class=""modal-header""><h4 class=""modal-title""></h4><button class=""btn-close"" aria-label=""close"" data-bs-dismiss=""modal""></button></div><div class=""modal-body""></div><div class=""modal-footer""><button type=""button"" class=""btn"" data-bs-dismiss=""modal"">Close</button></div></div></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlModal(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.Trim()));
        }

        /// <summary>
        /// Tests the header property of the modal control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""modal fade"" role=""dialog""><div class=""modal-dialog"" role=""document""><div class=""modal-content""><div class=""modal-header""><h4 class=""modal-title""></h4><button class=""btn-close"" aria-label=""close"" data-bs-dismiss=""modal""></button></div><div class=""modal-body""></div><div class=""modal-footer""><button type=""button"" class=""btn"" data-bs-dismiss=""modal"">Close</button></div></div></div></div>")]
        [InlineData("abc", @"<div class=""modal fade"" role=""dialog""><div class=""modal-dialog"" role=""document""><div class=""modal-content""><div class=""modal-header""><h4 class=""modal-title"">abc</h4><button class=""btn-close"" aria-label=""close"" data-bs-dismiss=""modal""></button></div><div class=""modal-body""></div><div class=""modal-footer""><button type=""button"" class=""btn"" data-bs-dismiss=""modal"">Close</button></div></div></div></div>")]

        public void Header(string header, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlModal()
            {
                Header = header
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, html.Trim());
        }
    }
}
