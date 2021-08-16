using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver _webDriver;

        private DriverSingleton()
        {

        }

        public static IWebDriver GetInstance()
        {
            if (_webDriver == null)
            {
                switch (TestContext.Parameters["Browser"])
                {
                    case "Firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _webDriver = new FirefoxDriver();
                            break;
                        }
                    default:
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _webDriver = new ChromeDriver();
                            break;
                        }
                }
                _webDriver.Manage().Window.Maximize();
            }
            return _webDriver;
        }

        public static void CloseDriver()
        {
            _webDriver.Quit();
            _webDriver = null;
        }
    }
}
