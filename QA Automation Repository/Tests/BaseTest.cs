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
using System.Xml;
using System.Xml.Serialization;
using TestProject.Driver;
using TestProject.Model;
using TestProject.Utils;

namespace TestProject.Tests
{
    public class BaseTest
    {
        private readonly string _pathToRootDirectory = @"..\..\..\";
        private readonly string _configFileName = "config.xml";


        protected string _searchKeyWord;
        protected string _mailPostfix;
        protected string _mailServiceAddress;
        protected string _cloudServiceAddress;
        protected string _screenshotsFilePath;

        protected IWebDriver _webDriver;

        protected void TestWrapper(Action execute)
        {
            try
            {
                execute();
            }
            catch (Exception)
            {
                try
                {
                    var screenshot = _webDriver.TakeScreenshot();
                    screenshot.SaveAsFile(_pathToRootDirectory + _screenshotsFilePath + $"{DateTime.Now}.png".Replace(':', '-'), ScreenshotImageFormat.Png);
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

        private void SetConfiguration()
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(_pathToRootDirectory + _configFileName);
                LoggerWrapper.LogInfo("XML configuration file was loaded!");
            }
            catch
            {
                LoggerWrapper.LogError("XML configuration file: unable to load.");
            }
            XmlElement xRoot = xmlDocument.DocumentElement;
            try
            {
                _searchKeyWord = xRoot.GetAttribute("SearchKeyWord");
                _mailPostfix = xRoot.GetAttribute("MailPostfix");
                _mailServiceAddress = xRoot.GetAttribute("MailServiceAddress");
                _cloudServiceAddress = xRoot.GetAttribute("CloudServiceAddress");
                _screenshotsFilePath = xRoot.GetAttribute("ScreenshotsFilePath");
            }
            catch
            {
                LoggerWrapper.LogError("Unable to read configuration attributes.");
            }
        }

        [SetUp]

        public void SetUp()
        {
            
            SetConfiguration();
            TestWrapper(() => 
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
            });
            WaitersWrapper.SetWaiter(_webDriver, TestContext.Parameters["WaitingTime"]);
        }

        [TearDown]

        public void TearDown()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
