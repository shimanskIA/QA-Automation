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

        protected BasePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
