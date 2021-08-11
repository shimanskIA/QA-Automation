using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
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
                switch (TestContext.Parameters["browser"])
                {
                    case "firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _webDriver = new FirefoxDriver();
                            _webDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(20));
                            break;
                        }
                    default:
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _webDriver = new ChromeDriver();
                            _webDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(20));
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
