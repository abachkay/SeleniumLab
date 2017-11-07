using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace SeleniumLab.PageObjects
{
    public abstract class PageObject
    {
        protected IWebDriver Driver { get; }

        protected WebDriverWait Wait { get; } 


        protected PageObject(IWebDriver driver)
        {           
            Driver = driver;
            Wait = new WebDriverWait(Driver,
                TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"])));
        }

        public void WaitUntilVisible(By by)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitUntilExists(By by)
        {
            Wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitUntilClickable(By by)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void Click(By by)
        {
            Driver.FindElement(by).Click();
        }

        public void WaitAndClick(By by)
        {
            WaitUntilClickable(by);

            Driver.FindElement(by).Click();
        }

        public void WaitAndType(By by, string text)
        {
            WaitUntilExists(by);

            Driver.FindElement(by).SendKeys(text);
        }

        public string WaitAndRead(By by)
        {
            WaitUntilExists(by);

            return Driver.FindElement(by).Text;
        }
    }
}