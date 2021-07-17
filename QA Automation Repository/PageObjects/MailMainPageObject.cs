using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    class MailMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _accountInfoButton = By.XPath("//a[@class='gb_C gb_Ma gb_h']");

        public MailMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToAccountInfo()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_accountInfoButton));
            _webDriver.FindElement(_accountInfoButton).Click();
        }
    }
}
