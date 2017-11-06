using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLab.Infrastructure;
using SeleniumLab.PageObjects;
using System.Configuration;

namespace SeleniumLab.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GmailTests
    {                     
        [Test]
        public void GmailTest1()
        {
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(ConfigurationManager.AppSettings["Url"])       
                .EnterEmail(ConfigurationManager.AppSettings["Email"])
                .EnterPassword(ConfigurationManager.AppSettings["Password"])
                .CreateMessage()
                .TypeMessage("abachkayspare@gmail.com", "Test", "Test message")
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail("Test", "Test message")
                .DeleteMail();
        }

        [Test]
        public void GmailTest2()
        {
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(ConfigurationManager.AppSettings["Url"])
                .EnterEmail(ConfigurationManager.AppSettings["Email"])
                .EnterPassword(ConfigurationManager.AppSettings["Password"])
                .CreateMessage()
                .TypeMessage("abachkayspare@gmail.com", "Test", "Test message")
                .CloseMessage()
                .GoToDraftsPage()
                .OpenMail()
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail("Test", "Test message");
        }

        [Test]
        public void GmailTest4()
        {
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(ConfigurationManager.AppSettings["Url"])
                .EnterEmail(ConfigurationManager.AppSettings["Email"])
                .EnterPassword(ConfigurationManager.AppSettings["Password"])
                .CreateMessage()
                .TypeMessage("aba", "Test", "Test message")
                .SendMessage()
                .CloseError()
                .FixMessage("abachkayspare@gmail.com")
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail("Test", "Test message");            
        }
    }
}