using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class DraftsPage : CommonPage
    {
        public DraftsPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.CssSelector, Using = "[gh='tl'] div div table tbody :first-child :nth-child(4) [class='yW']")]
        private readonly IWebElement _firstRow;

        public CreateMailPage OpenMail(int index = 0)
        {            
            Wait.Until(ExpectedConditions.ElementToBeClickable(_firstRow));
            _firstRow.Click();

            return new CreateMailPage(Driver);
        }
    }
}
