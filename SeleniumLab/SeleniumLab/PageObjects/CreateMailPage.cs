using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class CreateMailPage : CommonPage
    {
        private  By ToFieldEnable { get; } = By.CssSelector("[class='aoD hl']");

        private  By DeleteWrongEmailButton { get; } = By.CssSelector("[class='vM']");

        private  By ToField { get; } = By.CssSelector("[name='to']");

        private  By SubjectField { get; } = By.CssSelector("[name='subjectbox']");

        private  By MessageField { get; } = By.CssSelector("div[class='Am Al editable LW-avf']:first-of-type");

        private  By SendButton { get; } = By.CssSelector("[class='J-J5-Ji btA']:first-child");

        private  By CloseButton { get; } = By.CssSelector("img.Ha");

        private  By OkCloseErrorButton { get; } = By.CssSelector("[name='ok']");

        public CreateMailPage(IWebDriver driver) : base(driver)
        {            
        }
               
        public CreateMailPage TypeMessage(string to, string subject, string message)
        {
            WaitAndType(SubjectField, subject);
            WaitAndType(MessageField, message);
            WaitAndClick(ToFieldEnable);
            WaitAndType(ToField, to);

            return this;
        }

        public CreateMailPage FixMessage(string to)
        {           
            WaitAndClick(ToFieldEnable);
            WaitAndClick(DeleteWrongEmailButton);
            WaitAndType(ToField, to);

            return this;
        }       

        public CreateMailPage SendMessage()
        {
            WaitAndClick(SendButton);

            return this;
        }

        public CreateMailPage CloseMessage()
        {
            WaitAndClick(CloseButton);

            return this;
        }

        public CreateMailPage CloseError()
        {
            WaitAndClick(OkCloseErrorButton);

            return this;
        }
    }
}
