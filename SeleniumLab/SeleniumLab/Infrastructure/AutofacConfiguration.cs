using  Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLab.Infrastructure
{
    public class AutofacConfiguration
    {
        private static IContainer _container;
        public static IContainer GetContainer()
        {               
            return _container ?? (_container = new AutofacConfiguration().Configure());
        }

        private AutofacConfiguration()
        {
            _container = this.Configure();
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ChromeDriver>().As<IWebDriver>().InstancePerDependency();

            return  builder.Build();
        }
    }
}
