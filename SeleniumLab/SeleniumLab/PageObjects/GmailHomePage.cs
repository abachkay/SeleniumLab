using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumLab.Infrastructure;

namespace SeleniumLab.PageObjects
{
    public class GmailHomePage
    {
        private readonly IWebDriver _driver;

        public GmailHomePage()
        {           
            _driver = AutofacConfiguration.GetContainer().Resolve<IWebDriver>();            
            PageFactory.InitElements(_driver, this);
            _driver.Navigate().GoToUrl("http://mail.google.com");
            _driver.Quit();
        }

        [FindsBy(How = How.CssSelector, Using = ".fusion-main-menu a[href*='about']")]
        private IWebElement about;

        [FindsBy(How = How.ClassName, Using = "fusion-main-menu-icon")]
        private IWebElement searchIcon;

        //public AboutPage goToAboutPage()
        //{
        //    about.Click();
        //    return new AboutPage(driver);
        //}
    }
}
