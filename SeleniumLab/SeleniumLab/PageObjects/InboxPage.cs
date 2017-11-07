using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class InboxPage : CommonPage
    {
        private By _rowCheckbox = By.CssSelector("[gh='tl'] div div table tbody :first-child :nth-child(2) :first-child");

        private readonly By _menuButton = By.CssSelector("[gh='mtb'] :first-child :first-child :nth-child(6) :first-child");

        public InboxPage(IWebDriver driver) : base(driver)
        {       
        }

        public InboxPage MarkCheckbox(int index = 0)
        {
            if (index != 0)
            {
                _rowCheckbox = By.CssSelector($"[gh='tl'] div div table tbody :nth-child({index + 1}) :nth-child(2) :first-child");
            }
            _rowCheckbox.WaitAndClick(Driver);

            return new InboxPage(Driver);
        }

        public InboxPage MarkAsImportant()
        {
            _menuButton.WaitAndClick(Driver);

            return new InboxPage(Driver);
        }
    }
}
