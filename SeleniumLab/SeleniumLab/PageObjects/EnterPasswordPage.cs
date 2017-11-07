using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class EnterPasswordPage : PageObject
    {
        private  By PasswordField { get; } = By.CssSelector("[name='password']");

        private  By PasswordNextButton { get; } = By.CssSelector("#passwordNext");

        public EnterPasswordPage(IWebDriver driver) : base(driver)
        {            
        }
              
        public InboxPage EnterPassword(string password)
        {
            WaitAndType(PasswordField, password);
            WaitAndClick(PasswordNextButton);

            return new InboxPage(Driver);
        }
    }
}
