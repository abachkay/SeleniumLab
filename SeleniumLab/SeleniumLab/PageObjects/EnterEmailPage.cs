using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class EnterEmailPage : PageObject
    {
        public EnterEmailPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private readonly IWebElement _loginField;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private readonly IWebElement _loginNextButton;
   
        public EnterPasswordPage Next()
        {            
            _loginField.SendKeys(ConfigurationManager.AppSettings["Email"]);

            Wait.Until(ExpectedConditions.ElementToBeClickable(_loginNextButton));
            _loginNextButton.Click();

            return new EnterPasswordPage(Driver);
        }
    }
}
