using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Driver;

namespace TestProject.Tests
{
    public class BaseTest
    {
        protected readonly string _searchKeyWord = "Google Cloud Platform Pricing Calculator";
        protected readonly string _mailLogin = "epamfake1";
        protected readonly string _mailPostfix = "@yopmail.com";
        protected readonly string _mailServiceAddress = "https://yopmail.com/";
        protected readonly string _cloudServiceAddress = "https://cloud.google.com/";

        protected IWebDriver _webDriver;
        
        [SetUp]

        public void SetUp()
        {
            _webDriver = DriverSingleton.GetInstance();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(_mailServiceAddress);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("window.open();");
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
            _webDriver.Navigate().GoToUrl(_cloudServiceAddress);
        }

        [TearDown]

        public void TearDown()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
