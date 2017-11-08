using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class InboxPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr td div[role='checkbox']");

        private  By MenuButton { get; } = By.CssSelector("[gh='mtb'] :first-child :first-child :nth-child(6)");

        private  By MarkAsImportantButton { get; } = By.CssSelector("[class='J-M aX0 aYO jQjAxd'] [class='SK AX'] :nth-child(4) :first-child");

        private By MarkAsNotImportantButton { get; } = By.CssSelector("[class='J-M aX0 aYO jQjAxd'] [class='SK AX'] :nth-child(5) :first-child");

        public InboxPage(IWebDriver driver) : base(driver)
        {       
        }

        public InboxPage MarkCheckbox(int index = 0)
        {
            var checkBoxes = Rows.FindElements(Driver);
            Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Rows));
            try
            {
                checkBoxes[index].Click();
            }
            catch
            {
                checkBoxes = Rows.FindElements(Driver);                
                checkBoxes[index].Click();
            }
           
            return this;
        }

        public InboxPage MarkAsImportant()
        {
            WaitAndClick(MenuButton);            
            try
            {                
                Click(MarkAsNotImportantButton);
                WaitAndClick(MenuButton);
                WaitAndClick(MarkAsImportantButton);
            }
            catch
            {
                WaitAndClick(MarkAsImportantButton);
            }           

            return this;
        }        
    }
}