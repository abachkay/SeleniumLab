using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class ViewMailPage : CommonPage
    {
        public ViewMailPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.CssSelector, Using = "h2.hP")]
        private readonly IWebElement _subjectText;

        [FindsBy(How = How.CssSelector, Using = ".gs div div div[dir='ltr']")]
        private readonly IWebElement _messageText;

        [FindsBy(How = How.CssSelector, Using = "[gh='mtb'] :first-child :nth-child(2) :nth-child(3)")]
        private readonly IWebElement _deleteButton;

        public bool VerifyMail(string subject, string message)
        {                       
            return _subjectText.Text == subject && _messageText.Text == message;
        }

        public InboxPage DeleteMail()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_deleteButton));            
            _deleteButton.Click();

            return new InboxPage(Driver);
        }
    }
}
