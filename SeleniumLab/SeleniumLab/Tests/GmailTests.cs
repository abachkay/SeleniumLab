using System.Threading;
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

        [SetUp]
        public void SetUp()
        {
            var enterEmailPage = new EnterEmailPage(_driver);
            enterEmailPage.NavigateHome();
            var enterPasswordPage = enterEmailPage.Next();
            enterPasswordPage.Next();
        }

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

        [Test]
        public void GmailTest11()
        {            
            var inboxPage = new InboxPage(_driver);
            var createMailPage = inboxPage.CreateMessage();
            createMailPage.TypeMessage("abachkayspare@gmail.com", "Test", "Test message");
            createMailPage.SendMessage();
            var sentMailPage = createMailPage.GoToSentMailPage();
            var viewMailPage = sentMailPage.OpenMail();
            Assert.IsTrue(viewMailPage.VerifyMail("Test", "Test message"));
            viewMailPage.DeleteMail();
        }

        [Test]
        public void GmailTest12()
        {
            var inboxPage = new InboxPage(_driver);
            var createMailPage = inboxPage.CreateMessage();
            createMailPage.TypeMessage("abachkayspare@gmail.com", "Test", "Test message");
            createMailPage.CloseMessage();

            createMailPage.CreateMessage();
            var newcreatemailpage = new CreateMailPage(_driver);
            createMailPage.TypeMessage("abachkayspare@gmail.com", "Test", "Test message");
            createMailPage.CloseMessage();


            //var draftsPage = createMailPage.GoToDraftsPage();
            //var newCreateMailPage = draftsPage.OpenMail();

            //newCreateMailPage.SendMessage();           
        }

        [Test]
        public void GmailTest14()
        {
            var inboxPage = new InboxPage(_driver);
            var createMailPage = inboxPage.CreateMessage();
            createMailPage.TypeMessage("aba", "Test", "Test message");
            createMailPage.SendMessage();
            createMailPage.CloseError();
            createMailPage.FixMessage("abachkayspare@gmail.com");
            createMailPage.SendMessage();
            var sentMailPage = createMailPage.GoToSentMailPage();
            var viewMailPage = sentMailPage.OpenMail();
            Assert.IsTrue(viewMailPage.VerifyMail("Test", "Test message"));
        }
    }
}