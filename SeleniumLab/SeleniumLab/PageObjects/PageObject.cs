using OpenQA.Selenium;

namespace SeleniumLab.PageObjects
{
    public class PageObject
    {
        protected IWebDriver Driver { get; }        

        public PageObject(IWebDriver driver)
        {           
            Driver = driver;            
        }       
    }
}
