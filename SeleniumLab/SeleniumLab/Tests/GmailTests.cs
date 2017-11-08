using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLab.Infrastructure;
using SeleniumLab.PageObjects;

namespace SeleniumLab.Tests
{
    [TestFixture]    
    public class GmailTests
    {
        private TestConfiguration TestConfiguration { get; } = new TestConfiguration();

        [Test]
        public void GmailTest1() =>
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(TestConfiguration.Url)
                .EnterEmail(TestConfiguration.Email)
                .EnterPassword(TestConfiguration.Password)
                .CreateMessage()
                .TypeMessage(TestConfiguration.Email, TestConfiguration.TestSubject, TestConfiguration.TestMessage)
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail(TestConfiguration.TestSubject, TestConfiguration.TestMessage)
                .DeleteMail()
                .Close();

        [Test]
        public void GmailTest2() =>
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(TestConfiguration.Url)
                .EnterEmail(TestConfiguration.Email)
                .EnterPassword(TestConfiguration.Password)
                .CreateMessage()
                .TypeMessage(TestConfiguration.Email, TestConfiguration.TestSubject, TestConfiguration.TestMessage)
                .CloseMessage()
                .GoToDraftsPage()
                .OpenMail(1)
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail(TestConfiguration.TestSubject, TestConfiguration.TestMessage)
                .Close();

        [Test]
        public void GmailTest3() =>
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(TestConfiguration.Url)
                .EnterEmail(TestConfiguration.Email)
                .EnterPassword(TestConfiguration.Password)
                .GoToInboxPage()
                .MarkThreeCheckboxes()
                .MarkAsImportant()
                .GoToImportantPage()
                .CheckImportant()
                .DeleteImportant()
                .Close();
                

        [Test]
        public void GmailTest4() =>
            new EnterEmailPage(AutofacConfiguration.GetContainer().Resolve<IWebDriver>())
                .Navigate(TestConfiguration.Url)
                .EnterEmail(TestConfiguration.Email)
                .EnterPassword(TestConfiguration.Password)
                .CreateMessage()
                .TypeMessage(TestConfiguration.InvalidTestMessage, TestConfiguration.TestSubject,
                    TestConfiguration.TestMessage)
                .SendMessage()
                .CloseError()
                .FixMessage(TestConfiguration.Email)
                .SendMessage()
                .GoToSentMailPage()
                .OpenMail()
                .VerifyMail(TestConfiguration.TestSubject, TestConfiguration.TestMessage)
                .Close();
    }
}