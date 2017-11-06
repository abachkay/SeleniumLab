using OpenQA.Selenium;
using SeleniumLab.Utilities;
using System.Configuration;

namespace SeleniumLab.PageObjects
{
    public class EnterEmailPage : PageObject
    {
        private readonly By _loginField = By.CssSelector("#identifierId");

        private readonly By _loginNextButton = By.CssSelector("#identifierNext");

        public EnterEmailPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public EnterPasswordPage EnterEmail(string email)
        {
            _loginField.WaitAndType(Driver, email);          
            _loginNextButton.WaitAndClick(Driver);
                        
            return new EnterPasswordPage(Driver);
        }

        public virtual EnterEmailPage Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);

            return new EnterEmailPage(Driver);
        }
    }
}
