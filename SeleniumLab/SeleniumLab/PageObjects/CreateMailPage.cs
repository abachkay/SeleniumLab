using OpenQA.Selenium;
using SeleniumLab.Utilities;

namespace SeleniumLab.PageObjects
{
    public class CreateMailPage : CommonPage
    {
        private readonly By _toFieldEnable = By.CssSelector("[class='aoD hl']");

        private readonly By _deleteWrongEmailButton = By.CssSelector("[class='vM']");

        private readonly By _toField = By.CssSelector("[name='to']");

        private readonly By _subjectField = By.CssSelector("[name='subjectbox']");

        private readonly By _messageField = By.CssSelector("div[class='Am Al editable LW-avf']:first-of-type");

        private readonly By _sendButton = By.CssSelector("[class='J-J5-Ji btA']:first-child");

        private readonly By _closeButton = By.CssSelector("img.Ha");

        private readonly By _okCloseErrorButton = By.CssSelector("[name='ok']");

        public CreateMailPage(IWebDriver driver) : base(driver)
        {            
        }
               
        public CreateMailPage TypeMessage(string to, string subject, string message)
        {
            _subjectField.WaitAndType(Driver, subject);
            _messageField.WaitAndType(Driver, message);        
            _toFieldEnable.WaitAndClick(Driver);
            _toField.WaitAndType(Driver, to);

            return this;
        }

        public CreateMailPage FixMessage(string to)
        {           
            _toFieldEnable.WaitAndClick(Driver);
            _deleteWrongEmailButton.WaitAndClick(Driver);
            _toField.WaitAndType(Driver, to);

            return this;
        }       

        public CreateMailPage SendMessage()
        {
            _sendButton.WaitAndClick(Driver);

            return this;
        }

        public CreateMailPage CloseMessage()
        {
            _closeButton.WaitAndClick(Driver);

            return this;
        }

        public CreateMailPage CloseError()
        {
            _okCloseErrorButton.WaitAndClick(Driver);

            return this;
        }
    }
}
