using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    class MailRuMessagePageObject
    {
        private IWebDriver _webDriver;

        private readonly By _messageText = By.XPath("//div[@class='letter-body']");
        private readonly By _senderNameButton = By.XPath("//span[@class='letter-contact']");

        public MailRuMessagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetMessageText()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_messageText));
            return _webDriver.FindElement(_messageText).Text;
        }

        public string GetSenderName()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_senderNameButton));
            return _webDriver.FindElement(_senderNameButton).GetAttribute("title");
        }
    }
}
