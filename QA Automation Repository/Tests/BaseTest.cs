using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Driver;

namespace TestProject.Tests
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;
        
        [SetUp]

        public void SetUp()
        {
            _webDriver = DriverSingleton.GetInstance();
        }

        [TearDown]

        public void TearDown()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
