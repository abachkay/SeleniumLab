using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class CommonPage : PageObject
    {
        private readonly By _composeButton = By.CssSelector("[gh='cm']");

        private readonly By _goToInboxButton = By.CssSelector("[title*='Inbox']");

        private readonly By _goToSentMailButton = By.CssSelector("[title*='Sent Mail']");

        private readonly By _goToDraftButton = By.CssSelector("[title*='Drafts']");

        private readonly By _goToInboxButtonSelected = By.CssSelector("[class='aim ain'] div div div span a[title*='Inbox']");

        private readonly By _goToSentMailButtonSelected = By.CssSelector("[class='aim ain'] div div div span a[title*='Sent Mail']");

        private readonly By _goToDraftButtonSelected = By.CssSelector("[class='aim ain'] div div div span a[title*='Drafts']");

        private readonly By _refreshButton = By.CssSelector("[gh='mtb'] :first-child :first-child :nth-child(4)");

        public CommonPage(IWebDriver driver) : base(driver)
        {            
        }

        public CreateMailPage CreateMessage()
        {
            _composeButton.WaitAndClick(Driver);

            return new CreateMailPage(Driver);
        }

        public InboxPage GoToInboxPage()
        {
            _goToInboxButton.WaitAndClick(Driver);
            _goToInboxButtonSelected.Wait(Driver);

            return new InboxPage(Driver);
        }

        public SentMailPage GoToSentMailPage()
        {
            _goToSentMailButton.WaitAndClick(Driver);
            _goToSentMailButtonSelected.Wait(Driver);

            return new SentMailPage(Driver);
        }

        public DraftsPage GoToDraftsPage()
        {
            _goToDraftButton.WaitAndClick(Driver);
            _goToDraftButtonSelected.Wait(Driver);
            _refreshButton.WaitAndClick(Driver);            

            return new DraftsPage(Driver);
        }
    }
}
