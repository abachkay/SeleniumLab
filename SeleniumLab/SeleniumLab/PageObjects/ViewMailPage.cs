using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class ViewMailPage : CommonPage
    {
        private readonly By _subjectText = By.CssSelector("h2.hP");

        private readonly By _messageText = By.CssSelector(".gs div div div[dir='ltr']");

        private readonly By _deleteButton = By.CssSelector("[gh='mtb'] :first-child :nth-child(2) :nth-child(3)");

        public ViewMailPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public ViewMailPage VerifyMail(string subject, string message)
        {
            Assert.IsTrue(_subjectText.WaitAndRead(Driver) == subject && _messageText.WaitAndRead(Driver) == message);

            return this;
        }

        public InboxPage DeleteMail()
        {
            _deleteButton.WaitAndClick(Driver);

            return new InboxPage(Driver);
        }
    }
}
