using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class SentMailPage : CommonPage
    {
        public SentMailPage(IWebDriver driver) : base(driver)
        {           
        }

        [FindsBy(How = How.CssSelector, Using = "[gh='tl'] div div table tbody :first-child :nth-child(4) [class='yW']")]
        private readonly IWebElement _firstRow;

        public ViewMailPage OpenMail(int index = 0)
        {            
            Wait.Until(ExpectedConditions.ElementToBeClickable(_firstRow));
            _firstRow.Click();

            return new ViewMailPage(Driver);
        }
    }
}
