using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class SentMailPage : CommonPage
    {
        private readonly By _firstRow = By.CssSelector("[gh='tl'] div div table tbody :first-child :nth-child(4) [class='yW']");

        public SentMailPage(IWebDriver driver) : base(driver)
        {           
        }       

        public ViewMailPage OpenMail(int index = 0)
        {            
            _firstRow.WaitAndClick(Driver);

            return new ViewMailPage(Driver);
        }
    }
}
