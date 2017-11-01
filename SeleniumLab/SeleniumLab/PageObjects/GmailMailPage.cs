using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class GmailMailPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public GmailMailPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h2.hP")]
        private readonly IWebElement _subjectText;

        [FindsBy(How = How.CssSelector, Using = ".gs div div div[dir='ltr']")]
        private readonly IWebElement _messageText;

        [FindsBy(How = How.CssSelector, Using = "[gh='mtb'] :first-child :nth-child(2) :nth-child(3)")]
        private readonly IWebElement _deleteButton;        

        public bool DoesFirstMailMatch(string subject, string message)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_subjectText));
            _wait.Until(ExpectedConditions.ElementToBeClickable(_messageText));
            var subjectText = _subjectText.Text;
            var messageText = _messageText.Text;
            return subjectText == subject && messageText == message;            
        }

        public void DeleteFirstMail()
        {
            //_wait.Until(ExpectedConditions.ElementToBeClickable(_deleteButton));            
            Thread.Sleep(5000);
            _deleteButton.Click();
        }
    }
}
