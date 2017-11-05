using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class CommonPage : PageObject
    {
        public CommonPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.CssSelector, Using = "[gh='cm']")]
        private readonly IWebElement _composeButton;

        [FindsBy(How = How.CssSelector, Using = "[title*='Inbox']")]
        private readonly IWebElement _goToInboxButton;

        [FindsBy(How = How.CssSelector, Using = "[title*='Sent Mail']")]
        private readonly IWebElement _goToSentMailButton;

        [FindsBy(How = How.CssSelector, Using = "[title*='Drafts']")]
        private readonly IWebElement _goToDraftButton;

        [FindsBy(How = How.CssSelector, Using = "[class='aim ain'] div div div span a[title*='Inbox']")]
        private readonly IWebElement _goToInboxButtonSelected;

        [FindsBy(How = How.CssSelector, Using = "[class='aim ain'] div div div span a[title*='Sent Mail']")]
        private readonly IWebElement _goToSentMailButtonSelected;

        [FindsBy(How = How.CssSelector, Using = "[class='aim ain'] div div div span a[title*='Drafts']")]
        private readonly IWebElement _goToDraftButtonSelected;

        public CreateMailPage CreateMessage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_composeButton));
            _composeButton.Click();

            return new CreateMailPage(Driver);
        }

        public InboxPage GoToInbox()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToInboxButton));
            _goToSentMailButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToInboxButtonSelected));

            return new InboxPage(Driver);
        }

        public SentMailPage GoToSentMailPage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToSentMailButton));
            _goToSentMailButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToSentMailButtonSelected));

            return new SentMailPage(Driver);
        }

        public DraftsPage GoToDraftsPage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToDraftButton));
            _goToDraftButton.Click();
            Wait.Until(ExpectedConditions.ElementToBeClickable(_goToDraftButtonSelected));

            return new DraftsPage(Driver);
        }
    }
}
