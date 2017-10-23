using System;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumLab.Infrastructure;

namespace SeleniumLab.PageObjects
{
    public class GmailHomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public GmailHomePage()
        {           
            _driver = AutofacConfiguration.GetContainer().Resolve<IWebDriver>();   
            _wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(30));
            PageFactory.InitElements(_driver, this);
            _driver.Navigate().GoToUrl("http://mail.google.com");            
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement _loginField;

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement _loginNextButton;

        [FindsBy(How = How.ClassName, Using = "whsOnd zHQkBf")]
        private IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement _passwordNextButton;
        

        public void Login()
        {
            _loginField.SendKeys("abachkayspare@gmail.com");            
            _loginNextButton.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_passwordField));
            _passwordField.SendKeys("aba142");
            _passwordNextButton.Click();
        }
    }
}
