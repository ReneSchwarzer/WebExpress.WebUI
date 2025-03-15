﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using WebExpress.WebCore;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebLog;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebPlugin;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebUI.Test.Fixture
{
    /// <summary>
    /// A fixture class for unit tests, providing various mock objects and utility methods.
    /// </summary>
    public partial class UnitTestControlFixture : IDisposable
    {
        private static readonly string[] _separator = ["\r\n", "\r", "\n"];

        /// <summary>
        /// Initializes a new instance of the class and boot the component manager.
        /// </summary>
        public UnitTestControlFixture()
        {
        }

        /// <summary>
        /// Create a fake server context.
        /// </summary>
        /// <returns>The server context.</returns>
        public static IHttpServerContext CreateHttpServerContextMock()
        {
            return new HttpServerContext
            (
                "localhost",
                [],
                "",
                Environment.CurrentDirectory,
                Environment.CurrentDirectory,
                Environment.CurrentDirectory,
                new UriResource("/server"),
                CultureInfo.GetCultureInfo("en"),
                new Log() { LogMode = LogMode.Off },
                null
            );
        }

        /// <summary>
        /// Create a component hub.
        /// </summary>
        /// <returns>The component hub.</returns>
        public static ComponentHub CreateComponentHubMock()
        {
            var ctorComponentHub = typeof(ComponentHub).GetConstructor
            (
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                [typeof(HttpServerContext)],
                null
            );

            var componentHub = (ComponentHub)ctorComponentHub.Invoke([CreateHttpServerContextMock()]);

            // set static field in the webex class
            var type = typeof(WebEx);
            var field = type.GetField("_componentHub", BindingFlags.Static | BindingFlags.NonPublic);

            field.SetValue(null, componentHub);

            return componentHub;
        }

        /// <summary>
        /// Create a component hub and register the plugins.
        /// </summary>
        /// <returns>The component hub.</returns>
        public static ComponentHub CreateAndRegisterComponentHubMock()
        {
            var componentHub = CreateComponentHubMock();
            var pluginManager = componentHub.PluginManager as PluginManager;

            var registerMethod = pluginManager.GetType().GetMethod("Register", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, []);
            registerMethod.Invoke(pluginManager, null);

            return componentHub;
        }

        /// <summary>
        /// Create a fake request.
        /// </summary>
        /// <param name="content">The content of the request.</param>
        /// <param name="uri">The URI of the request.</param>
        /// <returns>A fake request for testing.</returns>
        public static Request CrerateRequestMock(string content = "", string uri = "")
        {
            var context = CreateHttpContextMock(content);

            var request = context.Request;

            if (!string.IsNullOrEmpty(uri))
            {
                var uriProperty = typeof(Request).GetProperty("Uri", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                uriProperty.SetValue(request, new UriResource(uri));
            }

            return request;
        }

        /// <summary>
        /// Create a fake http context.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>A fake http context for testing.</returns>
        public static WebCore.WebMessage.HttpContext CreateHttpContextMock(string content = "")
        {
            var ctorRequest = typeof(Request).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, [typeof(IFeatureCollection), typeof(RequestHeaderFields), typeof(IHttpServerContext)], null);
            var featureCollection = new FeatureCollection();
            var firstLine = content.Split('\n').FirstOrDefault();
            var lines = content.Split(_separator, StringSplitOptions.None);
            var filteredLines = lines.Skip(1).TakeWhile(line => !string.IsNullOrWhiteSpace(line));
            var pos = content.Length > 0 ? content.IndexOf(filteredLines.LastOrDefault()) + filteredLines.LastOrDefault().Length + 4 : 0;
            var innerContent = pos < content.Length ? content[pos..] : "";
            var contentBytes = Encoding.UTF8.GetBytes(innerContent);

            var requestFeature = new HttpRequestFeature
            {
                Headers = new HeaderDictionary
                {
                    ["Host"] = "localhost",
                    ["Connection"] = "keep-alive",
                    ["ContentType"] = "text/html",
                    ["ContentLength"] = innerContent.Length.ToString(),
                    ["ContentLanguage"] = "en",
                    ["ContentEncoding"] = "gzip, deflate, br, zstd",
                    ["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7",
                    ["AcceptEncoding"] = "gzip, deflate, br, zstd",
                    ["AcceptLanguage"] = "de,de-DE;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6",
                    ["UserAgent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0",
                    ["Referer"] = "0HN50661TV8TP",
                    ["Cookie"] = "session=AB333C76-E73F-45E0-85FD-123320D9B85F"
                },
                Body = contentBytes.Length > 0 ? new MemoryStream(contentBytes) : null,
                Method = firstLine.Split(' ')?.Where(x => !string.IsNullOrEmpty(x)).FirstOrDefault() ?? "GET",
                RawTarget = firstLine.Split(' ')?.Skip(1)?.FirstOrDefault()?.Split('?')?.FirstOrDefault() ?? "/",
                QueryString = "?" + firstLine.Split(' ')?.Skip(1)?.FirstOrDefault()?.Split('?')?.Skip(1)?.FirstOrDefault() ?? "",
            };

            foreach (var line in filteredLines)
            {
                var key = line.Split(':').FirstOrDefault().Trim();
                var value = line.Split(':').Skip(1).FirstOrDefault().Trim();
                requestFeature.Headers[key] = value;
            }

            requestFeature.Headers.ContentLength = contentBytes.Length;

            var requestIdentifierFeature = new HttpRequestIdentifierFeature
            {
                TraceIdentifier = "Ihr TraceIdentifier-Wert"
            };

            var connectionFeature = new HttpConnectionFeature
            {
                LocalPort = 8080,
                LocalIpAddress = IPAddress.Parse("192.168.0.1"),
                RemotePort = 8080,
                RemoteIpAddress = IPAddress.Parse("127.0.0.1"),
                ConnectionId = "0HN50661TV8TP"
            };

            featureCollection.Set<IHttpRequestFeature>(requestFeature);
            featureCollection.Set<IHttpRequestIdentifierFeature>(requestIdentifierFeature);
            featureCollection.Set<IHttpConnectionFeature>(connectionFeature);

            var context = new WebCore.WebMessage.HttpContext(featureCollection, CreateHttpServerContextMock());

            return context;
        }

        /// <summary>
        /// Creates a mock render context for unit testing.
        /// </summary>
        /// <param name="applicationContext">The application context. If null, defaults to null.</param>
        /// <param name="scopes">The scopes of the page. If null, defaults to null.</param>
        /// <returns>A mock render context for testing.</returns>
        public static IRenderControlContext CrerateRenderContextMock(IApplicationContext applicationContext = null, IEnumerable<Type> scopes = null)
        {
            var request = CrerateRequestMock();

            return new RenderControlContext(null, CreratePageContextMock(applicationContext, scopes), request);
        }

        /// <summary>
        /// Create a fake page context for unit testing.
        /// </summary>
        /// <param name="applicationContext">The application context. If null, defaults to null.</param>
        /// <param name="scopes">The scopes of the page.</param></param>
        /// <returns>A fake context for testing.</returns>
        public static PageContext CreratePageContextMock(IApplicationContext applicationContext = null, IEnumerable<Type> scopes = null)
        {
            var ctorPageContext = typeof(PageContext).GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, [], null);

            var pageContext = (PageContext)ctorPageContext.Invoke([]);
            var applicationContextProperty = typeof(PageContext).GetProperty("ApplicationContext", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            applicationContextProperty.SetValue(pageContext, applicationContext);

            var scopesProperty = typeof(PageContext).GetProperty("Scopes", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            scopesProperty.SetValue(pageContext, scopes);

            return pageContext;
        }

        /// <summary>
        /// Gets the content of an embedded resource as a string.
        /// </summary>
        /// <param name="fileName">The name of the resource file.</param>
        /// <returns>The content of the embedded resource as a string.</returns>
        public static string GetEmbeddedResource(string fileName)
        {
            var assembly = typeof(UnitTestControlFixture).Assembly;
            var resourceName = assembly.GetManifestResourceNames()
                                   .FirstOrDefault(name => name.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            var data = memoryStream.ToArray();

            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// Release of unmanaged resources reserved during use.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
