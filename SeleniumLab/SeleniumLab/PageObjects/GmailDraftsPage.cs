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
    public class GmailDraftsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public GmailDraftsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Timeout"])));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "font[color='#DD4B39']")]
        private readonly IWebElement _firstRow;

        public void OpenMail(int index = 0)
        {
            _wait.Until(ExpectedConditions.ElementToBeSelected(_firstRow));
            //_firstRow.Click();            
        }
    }
}