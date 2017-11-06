using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class DraftsPage : CommonPage
    {
        private readonly By _firstRow = By.CssSelector("[gh='tl'] div div table tbody :first-child :nth-child(4) [class='yW']");

        public DraftsPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public CreateMailPage OpenMail(int index = 0)
        {            
            _firstRow.WaitAndClick(Driver);

            return new CreateMailPage(Driver);
        }
    }
}
