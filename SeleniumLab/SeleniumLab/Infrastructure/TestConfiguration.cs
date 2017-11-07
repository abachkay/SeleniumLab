using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLab.Infrastructure
{
    public class TestConfiguration
    {
        public string Url { get; } = ConfigurationManager.AppSettings["Url"];

        public string Email { get; } = ConfigurationManager.AppSettings["Email"];

        public string Password { get; } = ConfigurationManager.AppSettings["Password"];

        public string Timeout { get; } = ConfigurationManager.AppSettings["Timeout"];

        public string TestSubject { get; } = ConfigurationManager.AppSettings["TestSubject"];

        public string TestMessage { get; } = ConfigurationManager.AppSettings["TestMessage"];

        public string InvalidTestMessage { get; } = ConfigurationManager.AppSettings["InvalidTestMessage"];
    }
}
