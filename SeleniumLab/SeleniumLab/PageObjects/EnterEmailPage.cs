using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class EnterEmailPage : PageObject
    {
        private  By LoginField { get; } = By.CssSelector("#identifierId");

        private  By LoginNextButton { get; } = By.CssSelector("#identifierNext");

        public EnterEmailPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public EnterPasswordPage EnterEmail(string email)
        {            
            WaitAndType(LoginField, email);
            WaitAndClick(LoginNextButton);
                        
            return new EnterPasswordPage(Driver);
        }

        public virtual EnterEmailPage Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);

            return new EnterEmailPage(Driver);
        }
    }
}
