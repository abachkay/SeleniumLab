using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class SentMailPage : CommonPage
    {
        private By Row { get; set; } = By.CssSelector("[gh='tl'] div div table tbody :first-child :nth-child(4)");

        public SentMailPage(IWebDriver driver) : base(driver)
        {           
        }       

        public ViewMailPage OpenMail(int index = 0)
        {
            if (index != 0)
            {
                Row = By.CssSelector($"[gh='tl'] div div table tbody :nth-child({index + 1}) :nth-child(4)");
            }
            WaitAndClick(Row);
            
            return new ViewMailPage(Driver);
        }
    }
}