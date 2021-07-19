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
        private readonly By _respondButton = By.XPath("//span[@class='button2 button2_has-ico button2_has-ico-s button2_reply button2_clean button2_hover-support js-shortcut']");
        private readonly By _respondInput = By.XPath("//div[@tabindex='505']");
        private readonly By _sendButton = By.XPath("//span[@title='Отправить']");

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

        public void Respond(string name)
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_respondButton));
            _webDriver.FindElement(_respondButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_respondInput));
            _webDriver.FindElement(_respondInput).SendKeys(name);
            _webDriver.FindElement(_sendButton).Click();
        }
    }
}
