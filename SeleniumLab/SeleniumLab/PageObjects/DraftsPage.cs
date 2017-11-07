using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class DraftsPage : CommonPage
    {
        private By FirstRow { get; set; } = By.CssSelector("[gh='tl'] div div table tbody :nth-child(1) :nth-child(4)");

       

        public DraftsPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public CreateMailPage OpenMail(int index = 0)
        {
            if (index != 0)
            {
                FirstRow = By.CssSelector($"[gh='tl'] div div table tbody :nth-child({index + 1}) :nth-child(4)");
            }
            WaitAndClick(FirstRow);

            return new CreateMailPage(Driver);
        }
    }
}
