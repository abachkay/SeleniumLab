using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class InboxPage : CommonPage
    {
        public InboxPage(IWebDriver driver) : base(driver)
        {
          //  Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[class='aim ain'] div div div span a[title='Inbox']")));
        }       
    }
}
