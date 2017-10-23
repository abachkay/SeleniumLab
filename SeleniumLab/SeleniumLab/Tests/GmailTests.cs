using NUnit.Framework;
using SeleniumLab.PageObjects;

namespace SeleniumLab.Tests
{
    [TestFixture]
    public class GmailTests
    {
        [Test]
        public void TestMethod1()
        {
            var gmail = new GmailHomePage();
            gmail.Login();
        }
    }
}
