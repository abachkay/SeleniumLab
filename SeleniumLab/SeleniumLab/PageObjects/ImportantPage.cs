using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class ImportantPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr");

        private By DeleteButton { get; } = By.CssSelector("[gh='mtb'] :first-child :nth-child(2) :nth-child(3)");

        public ImportantPage(IWebDriver driver) : base(driver)
        {           
        }       

        public ImportantPage CheckImportant()
        {
            var elements = Rows.FindElements(Driver);
            Assert.IsTrue(elements.Count == 3);
            
            return new ImportantPage(Driver);
        }

        public ImportantPage DeleteImportant()
        {
            WaitAndClick(DeleteButton);

            return new ImportantPage(Driver);
        }
    }
}