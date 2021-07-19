using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task13.PageObjects
{
    class GoogleMailMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _accountInfoButton = By.XPath("//a[@class='gb_C gb_Ma gb_h']");
        private readonly By _writeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By _destinationAddressButton = By.XPath("//textarea[@name='to']");
        private readonly By _messageTextButton = By.XPath("//div[@class='Am Al editable LW-avf tS-tW']");
        private readonly By _sendButton = By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        private readonly By _sendConfirmation = By.XPath("//span[text()='Письмо отправлено.']");
        private readonly By _openLatestMessageButton = By.XPath("//tr[@jscontroller='ZdOxDb']");
        private readonly By _amountOfIncomingMessages = By.XPath("//div[@class='bsU']");
        private readonly By _loggedUserName = By.XPath("//div[@class='gb_lb gb_mb']");

        public GoogleMailMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToAccountInfo()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_accountInfoButton));
        }

        public void SendMessage(string destination, string message)
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_writeButton));
            _webDriver.FindElement(_writeButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_destinationAddressButton));
            _webDriver.FindElement(_destinationAddressButton).SendKeys(destination);
            _webDriver.FindElement(_messageTextButton).SendKeys(message);
            _webDriver.FindElement(_sendButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_sendConfirmation));
        }

        public void WaitUntilMessageRecieved()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_amountOfIncomingMessages));
        }

        public GoogleMessagePageObject OpenMessage()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_openLatestMessageButton));
            _webDriver.FindElement(_openLatestMessageButton).Click();
            return new GoogleMessagePageObject(_webDriver);
        }

        public string GetLoggedUserName()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_accountInfoButton));
            _webDriver.FindElement(_accountInfoButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_loggedUserName));
            return _webDriver.FindElement(_loggedUserName).Text;
        }
    }
}
