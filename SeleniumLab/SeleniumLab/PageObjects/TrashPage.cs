using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class TrashPage : CommonPage
    {
        private By Rows { get; } = By.CssSelector("[gh='tl'] div div table tbody tr");

        public TrashPage(IWebDriver driver) : base(driver)
        {           
        }       

        public ViewMailPage VerifyCount()
        {            
            WaitAndClick(Rows);
            Assert.IsTrue(Rows.FindElements(Driver).Count > 0);
            
            return new ViewMailPage(Driver);
        }
    }
}