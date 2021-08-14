using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver _webDriver;
        
        protected int WaitingTime { get; set; }

        protected BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            string waitingTime = TestContext.Parameters["WaitingTime"];
            try
            {
                WaitingTime = Int32.Parse(waitingTime);
            }
            catch
            {
                LoggerWrapper.LogError($"Waiting time: {waitingTime} is an invalid value.");
                throw;
            }
        }
    }
}
