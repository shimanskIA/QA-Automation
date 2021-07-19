using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task13.PageObjects
{
    class GooglePersonalInfoPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _nameButton = By.XPath("//a[@href='name?gar=1']");

        public GooglePersonalInfoPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GoogleMailNamePageObject GoToGoogleMailNameInfo()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_nameButton));
            _webDriver.FindElement(_nameButton).Click();
            return new GoogleMailNamePageObject(_webDriver);
        }
    }
}
