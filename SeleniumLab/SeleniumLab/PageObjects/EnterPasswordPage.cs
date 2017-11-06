using OpenQA.Selenium;
using SeleniumLab.Utilities;
using System.Configuration;

namespace SeleniumLab.PageObjects
{
    public class EnterPasswordPage : PageObject
    {
        private readonly By _passwordField = By.CssSelector("[name='password']");

        private readonly By _passwordNextButton = By.CssSelector("#passwordNext");

        public EnterPasswordPage(IWebDriver driver) : base(driver)
        {            
        }
              
        public InboxPage EnterPassword(string password)
        {            
            _passwordField.WaitAndType(Driver, password);
            _passwordNextButton.WaitAndClick(Driver);

            return new InboxPage(Driver);
        }
    }
}
