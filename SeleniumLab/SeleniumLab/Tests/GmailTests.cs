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
        public void GmailTest1()
        {
            var gmailHomePage = new GmailHomePage(_driver);
            gmailHomePage.Login();        
            gmailHomePage.CreateMessage();
            gmailHomePage.TypeMessage("abachkayspare@gmail.com", "Test", "Test message");
            gmailHomePage.SendMessage();
            var gmailSentMailPage = gmailHomePage.GoToSentMailPage();
            var gmailMailPage = gmailSentMailPage.OpenMail();
            Assert.IsTrue(gmailMailPage.DoesFirstMailMatch("Test", "Test message"));
            gmailMailPage.DeleteFirstMail();
        }

        [Test]
        public void TestMethod4()
        {
            var gmailHomePage = new GmailHomePage(_driver);
            gmailHomePage.Login();
            gmailHomePage.CreateMessage();
            gmailHomePage.TypeMessage("aba", "Test", "Test message");
            gmailHomePage.SendMessage();
            gmailHomePage.CloseError();
            gmailHomePage.CloseMessage();
            gmailHomePage.CreateMessage();
            gmailHomePage.TypeMessage("abachkayspare@gmail.com", "Test", "Test message");
            gmailHomePage.SendMessage();
            //var gmailSentMailPage = gmailHomePage.GoToSentMailPage();
            //var gmailMailPage = gmailSentMailPage.OpenMail();
            //Assert.IsTrue(gmailMailPage.DoesFirstMailMatch("Test", "Test message"));
            //gmailMailPage.DeleteFirstMail();
        }

        [Test]
        public void GmailTest2()
        {
            var gmailHomePage = new GmailHomePage(_driver);
            gmailHomePage.Login();
            //gmailHomePage.CreateMessage();
            //gmailHomePage.TypeMessage("aba", "Test", "Test message");            
            //gmailHomePage.CloseMessage();
            //var draftsPage = gmailHomePage.GoToDraftsPage();
            //draftsPage.OpenMail();
        }
    }
}