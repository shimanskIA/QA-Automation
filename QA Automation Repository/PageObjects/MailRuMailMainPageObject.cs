using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    public class MailRuMailMainPageObject
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
            WaitersWrapper.WaitElementInteractable(_webDriver, _openLatestMessageButton, 10);
            _webDriver.FindElement(_openLatestMessageButton).Click();
            return new MailRuMessagePageObject(_webDriver);
        }

        public void WaitUntilMessageRecieved()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _amountOfIncomingMessages, 10);
        }

        public string GetMessageState()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _latestMessageState, 10);
            return _webDriver.FindElement(_latestMessageState).GetAttribute("title");
        }
    }
}
