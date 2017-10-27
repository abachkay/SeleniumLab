using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class GmailMailPage
    {
        private readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public GmailMailPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h2.hP")]
        private readonly IWebElement _subjectText;


        [FindsBy(How = How.CssSelector, Using = "[class='a3s aXjCH m15f5e3418a15706c'] [dir='ltr']")]
        private readonly IWebElement _messageText;

        [FindsBy(How = How.CssSelector, Using = "[class='asa']")]
        private readonly IWebElement _deleteButton;        

        public bool DoesFirstMailMatch(string subject, string message)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_subjectText));
            _wait.Until(ExpectedConditions.ElementToBeClickable(_messageText));
            return _subjectText.Text == subject && _messageText.Text == message;            
        }

        public void DeleteFirstMail()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_deleteButton));
            _deleteButton.Click();
        }
    }
}
