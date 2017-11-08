using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class ImportantPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr :nth-child(5)");

        public ImportantPage(IWebDriver driver) : base(driver)
        {           
        }       

        public ViewMailPage OpenMail(int index = 0)
        {            
            WaitAndClick(Rows, index);
            
            return new ViewMailPage(Driver);
        }
    }
}