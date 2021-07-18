using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    class MailRuMailMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _amountOfIncomingMessages = By.XPath("//span[@class='badge__text']");
        private readonly By _openLatestMessageButton = By.XPath("//div[@class='llc__read-status']/ancestor::a");
        private readonly By _latestMessageState = By.XPath("//div[@class='llc__read-status']/child::span");

        public MailRuMailMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MailRuMessagePageObject OpenMessage()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_openLatestMessageButton));
            _webDriver.FindElement(_openLatestMessageButton).Click();
            return new MailRuMessagePageObject(_webDriver);
        }

        public void WaitUntilMessageRecieved()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_amountOfIncomingMessages));
        }

        public string GetMessageState()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_latestMessageState));
            return _webDriver.FindElement(_latestMessageState).GetAttribute("title");
        }
    }
}
