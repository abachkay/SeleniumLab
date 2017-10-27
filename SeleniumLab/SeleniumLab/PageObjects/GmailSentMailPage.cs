using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
namespace SeleniumLab.PageObjects
{
    public class GmailSentMailPage
    {
        private readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public GmailSentMailPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[gh='tl'] div div table tbody :first-child :nth-child(4)")]
        private readonly IWebElement _firstRow;

        public GmailMailPage OpenMail(int index = 0)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_firstRow));
            _firstRow.Click();
            return new GmailMailPage(_driver);
        }
    }
}