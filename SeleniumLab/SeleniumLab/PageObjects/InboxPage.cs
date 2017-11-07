using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class InboxPage : CommonPage
    {
        private By RowCheckbox { get; set; } = By.CssSelector("[gh='tl'] div div table tbody :first-child :nth-child(2) :first-child");

        private  By MenuButton { get; } = By.CssSelector("[gh='mtb'] :first-child :first-child :nth-child(6)");

        private  By MarkAsImportantButton { get; } = By.CssSelector("[class='SK AX'] :nth-child(4) :first-child");

        public InboxPage(IWebDriver driver) : base(driver)
        {       
        }

        public InboxPage MarkCheckbox(int index = 0)
        {
            if (index != 0)
            {
                RowCheckbox = By.CssSelector($"[gh='tl'] div div table tbody :nth-child({index + 1}) :nth-child(2) :first-child");
            }
            WaitAndClick(RowCheckbox);

            return new InboxPage(Driver);
        }

        public InboxPage MarkAsImportant()
        {
            WaitAndClick(MenuButton);            

            return new InboxPage(Driver);
        }
    }
}