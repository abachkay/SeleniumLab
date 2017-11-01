using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium.Chrome;

namespace SeleniumLab.PageObjects
{
    public class GmailHomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public GmailHomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])));
            PageFactory.InitElements(_driver, this);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Url"]);
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private readonly IWebElement _loginField;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private readonly IWebElement _loginNextButton;

        [FindsBy(How = How.Name, Using = "password")]        
        private readonly IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private readonly IWebElement _passwordNextButton;
        
        [FindsBy(How = How.CssSelector, Using = "[gh='cm']")]
        private readonly IWebElement _composeButton;

        [FindsBy(How = How.Name, Using = "to")]
        private readonly IWebElement _toField;

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private readonly IWebElement _subjectField;

        [FindsBy(How = How.CssSelector, Using = "div[class='Am Al editable LW-avf']:first-of-type")]
        private readonly IWebElement _messageField;
       
        [FindsBy(How = How.CssSelector, Using = "[class='J-J5-Ji btA']:first-child")]
        private readonly IWebElement _sendButton;

        [FindsBy(How = How.CssSelector, Using = "img.Ha")]
        private readonly IWebElement _closeButton;

        [FindsBy(How = How.CssSelector, Using = "[title='Sent Mail']")]
        private readonly IWebElement _goToSentMailButton;

        [FindsBy(How = How.CssSelector, Using = "[title*='Drafts']")]
        private readonly IWebElement _goToDraftButton;


        [FindsBy(How = How.CssSelector, Using = "[name='ok']")]
        private readonly IWebElement _okCloseErrorButton;

        public void Login()
        {
            //_wait.Until(ExpectedConditions.ElementToBeClickable(_loginField));            
            _loginField.SendKeys(ConfigurationManager.AppSettings["Email"]);

            //_wait.Until(ExpectedConditions.ElementToBeClickable(_loginNextButton));
            _loginNextButton.Click();

            //_wait.Until(ExpectedConditions.ElementToBeClickable(_passwordField));            
            _passwordField.SendKeys(ConfigurationManager.AppSettings["Password"]);

            //_wait.Until(ExpectedConditions.ElementToBeClickable(_passwordNextButton));
            _passwordNextButton.Click();
        }

        public void CreateMessage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_composeButton));
            _composeButton.Click();
        }

        public void TypeMessage(string to, string subject, string message)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_toField));
            _toField.SendKeys(to);

            _wait.Until(ExpectedConditions.ElementToBeClickable(_subjectField));
            _subjectField.SendKeys(subject);

            _wait.Until(ExpectedConditions.ElementToBeClickable(_messageField));
            _messageField.SendKeys(message);            
        }

        public void SendMessage()
        {                        
            _wait.Until(ExpectedConditions.ElementToBeClickable(_sendButton));            
            _sendButton.Click();
        }

        public void CloseMessage()
        {           
            _wait.Until(ExpectedConditions.ElementToBeClickable(_closeButton));
            _closeButton.Click();
        }

        public void CloseError()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_okCloseErrorButton));
            _okCloseErrorButton.Click();
        }

        public GmailSentMailPage GoToSentMailPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_goToSentMailButton));
            _goToSentMailButton.Click();
            return new GmailSentMailPage(_driver);
        }

        public GmailDraftsPage GoToDraftsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_goToDraftButton));
            _goToDraftButton.Click();
            return new GmailDraftsPage(_driver);
        }
    }
}