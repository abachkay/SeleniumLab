using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class InboxPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr td div[role='checkbox']");

        private  By MenuButton { get; } = By.CssSelector("[gh='mtb'] :first-child :first-child :nth-child(6)");

        private  By MarkAsImportantButton { get; } = By.CssSelector("[class='J-M aX0 aYO jQjAxd'] [class='SK AX'] :nth-child(4) :first-child");

        public InboxPage(IWebDriver driver) : base(driver)
        {       
        }

        public InboxPage MarkThreeCheckboxes()
        {
            var checkBoxes = Rows.FindElements(Driver);
            Wait.Until(ExpectedConditions.ElementToBeClickable(checkBoxes[2]));

            checkBoxes[0].Click();           
            checkBoxes[1].Click();           
            checkBoxes[2].Click();

            return new InboxPage(Driver);
        }

        public InboxPage MarkAsImportant()
        {
            WaitAndClick(MenuButton);       
            
            WaitAndClick(MarkAsImportantButton);

            return new InboxPage(Driver);
        }
    }
}