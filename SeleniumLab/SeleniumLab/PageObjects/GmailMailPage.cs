using System;
using System.Collections.Generic;
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

        [FindsBy(How = How.CssSelector, Using = "h2.hP:first")]
        private readonly IWebElement _subjectText;

        public bool DoesMailMatch(string to, string subject, string message)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_subjectText));            
            return _subjectText.Text == subject;
        }
    }
}
