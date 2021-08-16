using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TestProject.Driver;
using TestProject.Model;
using TestProject.Utils;

namespace TestProject.Tests
{
    public class BaseTest
    {
        protected readonly string _searchKeyWord = "Google Cloud Platform Pricing Calculator";
        protected readonly string _mailLogin = "epamfake1";
        protected readonly string _mailPostfix = "@yopmail.com";
        protected readonly string _mailServiceAddress = "https://yopmail.com/";
        protected readonly string _cloudServiceAddress = "https://cloud.google.com/";
        protected readonly string _screenshotsFilePath = @"..\..\..\Screenshots\Screenshot ";

        protected IWebDriver _webDriver;

        protected void TestWrapper(Action executeTest)
        {
            try
            {
                executeTest();
            }
            catch (Exception)
            {
                try
                {
                    var screenshot = _webDriver.TakeScreenshot();
                    screenshot.SaveAsFile(_screenshotsFilePath + $"{DateTime.Now}.png".Replace(':', '-'), ScreenshotImageFormat.Png);
                    LoggerWrapper.LogInfo("Screenshot was made!");
                }
                catch(WebDriverException)
                {
                    LoggerWrapper.LogError("Screenshot wasn't made: inner web driver error");
                    throw;
                }
                catch(DirectoryNotFoundException)
                {
                    LoggerWrapper.LogError("Screenshot wasn't made: directory doesn't exist");
                    throw;
                }
                catch(IOException)
                {
                    LoggerWrapper.LogError("Screenshot wasn't made: disallowed file name");
                    throw;
                }
                throw;
            }
        }

        [SetUp]

        public void SetUp()
        {
            _webDriver = DriverSingleton.GetInstance();
            _webDriver.Manage().Window.Maximize();
            try
            {
                _webDriver.Navigate().GoToUrl(_mailServiceAddress);
                LoggerWrapper.LogInfo("E-Mail generator page was successfully opened!");
            }
            catch
            {
                LoggerWrapper.LogError("E-Mail generator page wasn't opened.");
                throw;
            }
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
                js.ExecuteScript("window.open();");
                LoggerWrapper.LogInfo("The new tab in browser was successfully opened!");
            }
            catch
            {
                LoggerWrapper.LogError("The new tab in browser wasn't opened.");
                throw;
            }
            try
            {
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
                _webDriver.Navigate().GoToUrl(_cloudServiceAddress);
                LoggerWrapper.LogInfo("Cloud service page was successfully opened!");
            }
            catch
            {
                LoggerWrapper.LogError("Cloud service page wasn't opened.");
                throw;
            }
            WaitersWrapper.SetWaiter(_webDriver, TestContext.Parameters["WaitingTime"]);
        }

        [TearDown]

        public void TearDown()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
