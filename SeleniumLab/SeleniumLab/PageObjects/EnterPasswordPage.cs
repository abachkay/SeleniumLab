using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class EnterPasswordPage : PageObject
    {
        public EnterPasswordPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.Name, Using = "password")]
        private readonly IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private readonly IWebElement _passwordNextButton;

        public InboxPage Next()
        {            
            _passwordField.SendKeys(ConfigurationManager.AppSettings["Password"]);

            Wait.Until(ExpectedConditions.ElementToBeClickable(_passwordNextButton));
            _passwordNextButton.Click();

            return new InboxPage(Driver);
        }
    }
}
