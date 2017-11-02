using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class PageObject
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        public PageObject(IWebDriver driver)
        {           
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private readonly IWebElement _loginField;

        public void NavigateHome()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Url"]);
        }
    }
}
