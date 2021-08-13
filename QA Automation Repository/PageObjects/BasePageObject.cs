using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.PageObjects
{
    public abstract class BasePageObject
    {
        protected IWebDriver _webDriver;
        protected int _waitingTime;

        protected BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Int32.TryParse(TestContext.Parameters["WaitingTime"], out _waitingTime);
        }
    }
}
