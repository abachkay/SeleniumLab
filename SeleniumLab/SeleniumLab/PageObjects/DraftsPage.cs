using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class DraftsPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr");

        public DraftsPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public CreateMailPage OpenMail(int index = 0)
        {
            WaitAndClick(Rows, index);

            return new CreateMailPage(Driver);
        }
    }
}
