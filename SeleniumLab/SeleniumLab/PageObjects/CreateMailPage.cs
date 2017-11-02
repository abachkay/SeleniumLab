using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLab.PageObjects
{
    public class CreateMailPage : CommonPage
    {
        public CreateMailPage(IWebDriver driver) : base(driver)
        {            
        }

        [FindsBy(How = How.CssSelector, Using = "[class='aoD hl']")]
        private readonly IWebElement _toFieldEnable;

        [FindsBy(How = How.CssSelector, Using = "[class='vM']")]
        private readonly IWebElement _deleteWrongEmailButton;

        [FindsBy(How = How.CssSelector, Using = "[name='to']")]
        private readonly IWebElement _toField;
        
        [FindsBy(How = How.CssSelector, Using = "[name='subjectbox']")]
        private readonly IWebElement _subjectField;

        [FindsBy(How = How.CssSelector, Using = "div[class='Am Al editable LW-avf']:first-of-type")]
        private readonly IWebElement _messageField;

        [FindsBy(How = How.CssSelector, Using = "[class='J-J5-Ji btA']:first-child")]
        private readonly IWebElement _sendButton;

        [FindsBy(How = How.CssSelector, Using = "img.Ha")]
        private readonly IWebElement _closeButton;

        [FindsBy(How = How.CssSelector, Using = "[name='ok']")]
        private readonly IWebElement _okCloseErrorButton;

        
        public void TypeMessage(string to, string subject, string message)
        {                        
            _subjectField.SendKeys(subject);                        
            _messageField.SendKeys(message);

            Wait.Until(ExpectedConditions.ElementToBeClickable(_toFieldEnable));
            _toFieldEnable.Click();
            
            _toField.SendKeys(to);
        }

        public void FixMessage(string to)
        {           
            Wait.Until(ExpectedConditions.ElementToBeClickable(_toFieldEnable));
            _toFieldEnable.Click();

            Wait.Until(ExpectedConditions.ElementToBeClickable(_deleteWrongEmailButton));
            _deleteWrongEmailButton.Click();

            _toField.SendKeys(to);
        }

        public void ClearMessage()
        {
            _toField.Clear();            
            _subjectField.Clear();            
            _messageField.Clear();            
        }

        public void SendMessage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_sendButton));
            _sendButton.Click();
        }

        public void CloseMessage()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_closeButton));
            _closeButton.Click();
        }

        public void CloseError()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(_okCloseErrorButton));
            _okCloseErrorButton.Click();
        }
    }
}
