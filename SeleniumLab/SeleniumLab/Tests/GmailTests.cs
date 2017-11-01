using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLab.Infrastructure;
using SeleniumLab.PageObjects;

namespace SeleniumLab.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GmailTests
    {
        private readonly IWebDriver _driver = AutofacConfiguration.GetContainer().Resolve<IWebDriver>();

        [Test]
        public void TestMethod1()
        {
            var gmailHomePage = new GmailHomePage(_driver);
            gmailHomePage.Login();            
            gmailHomePage.SendMessage("abachkayspare@gmail.com", "Test", "Test message");
            var gmailSentMailPage = gmailHomePage.GoToSentMailPage();
            var gmailMailPage = gmailSentMailPage.OpenMail();
            //Assert.IsTrue(gmailMailPage.DoesFirstMailMatch("Test", "Test message"));
            //gmailMailPage.DeleteFirstMail();
        }

        [Test]
        public void TestMethod4()
        {
            var gmailHomePage = new GmailHomePage(_driver);
            gmailHomePage.Login();            
            gmailHomePage.SendMessage("aba", "Test", "Test message");
            gmailHomePage.CloseError();
            gmailHomePage.SendMessage("abachkayspare@gmail.com", "Test", "Test message");
            //var gmailSentMailPage = gmailHomePage.GoToSentMailPage();
            //var gmailMailPage = gmailSentMailPage.OpenMail();
            //Assert.IsTrue(gmailMailPage.DoesFirstMailMatch("Test", "Test message"));
            //gmailMailPage.DeleteFirstMail();
        }
    }
}