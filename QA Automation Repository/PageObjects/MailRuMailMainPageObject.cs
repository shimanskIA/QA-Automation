using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    class MailRuMailMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _readMessageButton = By.XPath("//a[@class='llc js-tooltip-direction_letter-bottom js-letter-list-item llc_normal']");

        public MailRuMailMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MailRuMessagePageObject OpenMessage()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_readMessageButton));
            _webDriver.FindElement(_readMessageButton).Click();
            return new MailRuMessagePageObject(_webDriver);
        }

        /*public string GetMessageState()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_readMessageButton));
        }*/
    }
}
