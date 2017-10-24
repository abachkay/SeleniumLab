using System.Runtime.InteropServices;
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
            //gmail.SendMessage("abachkayspare@gmail.com", "Test", "Test message");            
            var gmailSentMailPage = gmailHomePage.GoToSentMailPage();
            var gmailMailPage = gmailSentMailPage.OpenMail();
            gmailMailPage.DoesMailMatch("me", "Test", "Test message");
        }        
    }
}