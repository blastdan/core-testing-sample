using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreTestingSample.Test.Integration
{
    [TestFixture, Description("Performs integration testing on the person controller")]
    public class PersonControllerIntegrationTests
    {
        private TestServer server;
        private HttpClient client;

        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            Bootstrap.AutoMapper();

            var integrationTestsPath = PlatformServices.Default.Application.ApplicationBasePath;
            var applicationPath = Path.GetFullPath(Path.Combine(integrationTestsPath, "../../../../core-testing-sample"));

            server = new TestServer(new WebHostBuilder()
                                   .UseStartup<TestingStartup>()
                                   .UseContentRoot(applicationPath)
                                   .UseEnvironment("Development"));

            client = server.CreateClient();
        }

        [Test, Description("ensures that all loaded people will be found on the people index page")]
        public async Task ReturnAllPeople()
        {
            var response = await client.GetAsync("/people");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var loadedPeople = TestDBInitializer.GetLoadedPeopleIds().Select(p => string.Format("<a href=\"/people/Edit/{0}\">Edit</a>", p));
            responseString.Should().ContainAll(loadedPeople, "the people should have an edit link on the page");
        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            this.server.Dispose();
            this.client.Dispose();
        }
    }
}
