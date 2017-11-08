using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class ImportantPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr");

        private By DeleteButton { get; } = By.CssSelector("[gh='mtb'] :first-child :nth-child(2) :nth-child(3)");

        private By MarkAllButton { get; } = By.CssSelector("[class='G-tF'] :first-child :first-child :first-child :first-child :first-child");        

        public ImportantPage(IWebDriver driver) : base(driver)
        {
        }

        public ImportantPage MarkAll()
        {
            WaitAndClick(MarkAllButton);

            return this;
        }

        public ImportantPage CheckCount(int count = 0)
        {
            var elements = Rows.FindElements(Driver);
            Assert.IsTrue(elements.Count >= count);

            return this;
        }

        public ImportantPage DeleteImportant()
        {
            WaitAndClick(DeleteButton);

            return this;
        }
    }
}