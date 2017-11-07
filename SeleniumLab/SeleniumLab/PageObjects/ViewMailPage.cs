using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class ViewMailPage : CommonPage
    {
        private  By SubjectText { get; } = By.CssSelector("h2.hP");

        private  By MessageText { get; } = By.CssSelector(".gs div div div[dir='ltr']");

        private  By DeleteButton { get; } = By.CssSelector("[gh='mtb'] :first-child :nth-child(2) :nth-child(3)");

        public ViewMailPage(IWebDriver driver) : base(driver)
        {            
        }
        
        public ViewMailPage VerifyMail(string subject, string message)
        {
            Assert.IsTrue(WaitAndRead(SubjectText) == subject && WaitAndRead(MessageText) == message);

            return this;
        }

        public InboxPage DeleteMail()
        {
            WaitAndClick(DeleteButton);

            return new InboxPage(Driver);
        }
    }
}