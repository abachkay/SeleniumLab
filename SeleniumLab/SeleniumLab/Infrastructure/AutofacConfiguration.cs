using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumLab.Infrastructure
{
    public static class AutofacConfiguration
    {
        private static IContainer _container;
        public static IContainer GetContainer()
        {               
            return _container ?? (_container = Configure());
        }       

        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ChromeDriver>().As<IWebDriver>().InstancePerDependency();

            return  builder.Build();
        }
    }
}
