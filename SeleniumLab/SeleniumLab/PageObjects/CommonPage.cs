using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class CommonPage : PageObject
    {
        private By ComposeButton { get; } = By.CssSelector("[gh='cm']");

        private By GoToInboxButton { get; } = By.CssSelector("[title*='Inbox']");

        private By GoToSentMailButton { get; } = By.CssSelector("[title*='Sent Mail']");

        private By GoToDraftButton { get; } = By.CssSelector("[title*='Drafts']");

        private By GoToImportantButton { get; } = By.CssSelector("[title*='Important']");

        private By GoToTrashButton { get; } = By.CssSelector("[title*='Trash']");

        private By GoToInboxButtonSelected { get; } = By.CssSelector("[class='aim ain'] div div div span a[title*='Inbox']");

        private By GoToSentMailButtonSelected { get; } = By.CssSelector("[class='aim ain'] div div div span a[title*='Sent Mail']");

        private By GoToDraftButtonSelected { get; } = By.CssSelector("[class='aim ain'] div div div span a[title*='Drafts']");

        private By GoToImportantButtonSelected { get; } = By.CssSelector("[class='aim ain'] div div div span a[title*='Important']");        

        public CommonPage(IWebDriver driver) : base(driver)
        {            
        }

        public CreateMailPage CreateMessage()
        {
            WaitAndClick(ComposeButton);

            return new CreateMailPage(Driver);
        }

        public InboxPage GoToInboxPage()
        {
            WaitAndClick(GoToInboxButton);
            WaitUntilVisible(GoToInboxButtonSelected);

            return new InboxPage(Driver);
        }

        public SentMailPage GoToSentMailPage()
        {
            WaitAndClick(GoToSentMailButton);
            WaitUntilVisible(GoToSentMailButtonSelected);

            return new SentMailPage(Driver);
        }

        public DraftsPage GoToDraftsPage()
        {
            WaitAndClick(GoToDraftButton);
            WaitUntilVisible(GoToDraftButtonSelected);

            return new DraftsPage(Driver);
        }

        public ImportantPage GoToImportantPage()
        {
            WaitAndClick(GoToImportantButton);
            WaitUntilVisible(GoToImportantButtonSelected);

            return new ImportantPage(Driver);
        }

        public ImportantPage GoToTrashPage()
        {
            WaitAndClick(GoToTrashButton);            

            return new ImportantPage(Driver);
        }
    }
}
