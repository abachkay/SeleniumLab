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

        public void WaitUntilVisibleMany(By by)
        {           
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by.FindElements(Driver)));
        }

        public void WaitUntilExists(By by)
        {
            Wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void WaitUntilExistsMany(By by)
        {
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public void WaitUntilClickable(By by)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void Click(By by)
        {
            Driver.FindElement(by).Click();
        }

        public void WaitAndClick(By by, int? index = null)
        {
            if (index == null)
            {
                WaitUntilClickable(by);
                Driver.FindElement(by).Click();
            }
            else
            {                   
                var elements = by.FindElements(Driver);
                Wait.Until(ExpectedConditions.ElementToBeClickable(elements[index.Value]));
                elements[index.Value].Click();
            }
        }

        public void WaitAndType(By by, string text)
        {
            WaitUntilVisible(by);

            Driver.FindElement(by).SendKeys(text);
        }

        public string WaitAndRead(By by)
        {
            WaitUntilVisible(by);

            return Driver.FindElement(by).Text;
        }

        public void Close()
        {
            Driver.Quit();
        }
    }
}