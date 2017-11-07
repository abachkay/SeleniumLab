using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class DraftsPage : CommonPage
    {
        private By _firstRow = By.CssSelector("[gh='tl'] div div table tbody :nth-child(1) :nth-child(4)");

       

        public DraftsPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public CreateMailPage OpenMail(int index = 0)
        {
            if (index != 0)
            {
                _firstRow = By.CssSelector($"[gh='tl'] div div table tbody :nth-child({index + 1}) :nth-child(4)");
            }
            _firstRow.WaitAndClick(Driver);

            return new CreateMailPage(Driver);
        }
    }
}
