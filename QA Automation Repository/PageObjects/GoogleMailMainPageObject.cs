using OpenQA.Selenium;

namespace Task13.PageObjects
{
    public class GoogleMailMainPageObject : GoogleMailPageObject
    {
        private readonly By _writeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By _destinationAddressButton = By.XPath("//textarea[@name='to']");
        private readonly By _messageTextButton = By.XPath("//div[@class='Am Al editable LW-avf tS-tW']");
        private readonly By _sendButton = By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        private readonly By _sendConfirmation = By.XPath("//span[@class='bAo']/child::span[position()=1]");
        private readonly By _openLatestMessageButton = By.XPath("//tr[@jscontroller='ZdOxDb']");

        public GoogleMailMainPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void SendMessage(string destination, string message)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _writeButton, 10);
            _webDriver.FindElement(_writeButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _destinationAddressButton, 10);
            _webDriver.FindElement(_destinationAddressButton).SendKeys(destination);
            _webDriver.FindElement(_messageTextButton).SendKeys(message);
            _webDriver.FindElement(_sendButton).Click();
            WaitersWrapper.WaitElementAppearDisappear(_webDriver, _sendConfirmation, 20);
        }

        public GoogleMessagePageObject OpenMessage()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _openLatestMessageButton, 10);
            _webDriver.FindElement(_openLatestMessageButton).Click();
            return new GoogleMessagePageObject(_webDriver);
        }
    }
}
