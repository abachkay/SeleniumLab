using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace SeleniumLab.Utilities
{
    public static class SeleniumExtensionMethods
    {
        private static readonly TimeSpan Timeout =
            TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"]));

        public static void WaitAndClick(this By by, IWebDriver driver)
        {
            new WebDriverWait(driver, Timeout).Until(ExpectedConditions.ElementToBeClickable(by));

            driver.FindElement(by).Click();
        }

        public static void WaitAndType(this By by, IWebDriver driver, string text)
        {
            new WebDriverWait(driver, Timeout).Until(ExpectedConditions.ElementIsVisible(by));

            driver.FindElement(by).SendKeys(text);
        }

        public static string WaitAndRead(this By by, IWebDriver driver)
        {
            new WebDriverWait(driver, Timeout).Until(ExpectedConditions.ElementIsVisible(by));

            return driver.FindElement(by).Text;
        }

        public static void Wait(this By by, IWebDriver driver)
        {
            new WebDriverWait(driver, Timeout).Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
