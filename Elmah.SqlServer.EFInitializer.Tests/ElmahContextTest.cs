namespace Elmah.SqlServer.EFInitializer.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    internal class ElmahContextTest
    {
        private ElmahContext _context;

        [SetUp]
        public void Init()
        {
            this._context = new ElmahContext("DefaultConnection");
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

        [TearDown]
        public void Cleanup()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }

        [Test]
        [TestCase("TestApplication", "localhost", "OneType", "ReliableSource", "Test message", "TestUser", "<error>XmlError</error>", 500)]
        public async void GivenParameters_Should_AddRecord(string application, string host, string type, string source, string message, string user, string allXml, int statusCode)
        {
            var errorId = Guid.NewGuid();
            var utcNow = DateTime.UtcNow;
            var result = await this._context.LogErrorAsync(errorId, application, host, type, source, message, user, allXml, statusCode, utcNow);

            //result.Should().Be(1);

            var error = await this._context.GetErrorXmlAsync(application, errorId);
            error.Should().Be(allXml);
        }
    }
}