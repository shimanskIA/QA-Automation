using OpenQA.Selenium;

namespace Task13.PageObjects
{
    public class GoogleMailMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _accountInfoButton = By.XPath("//a[@class='gb_C gb_Ma gb_h']");
        private readonly By _writeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By _destinationAddressButton = By.XPath("//textarea[@name='to']");
        private readonly By _messageTextButton = By.XPath("//div[@class='Am Al editable LW-avf tS-tW']");
        private readonly By _sendButton = By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        private readonly By _sendConfirmation = By.XPath("//span[@class='bAo']/child::span[position()=1]");
        private readonly By _openLatestMessageButton = By.XPath("//tr[@jscontroller='ZdOxDb']");
        private readonly By _amountOfIncomingMessages = By.XPath("//div[@class='bsU']");
        private readonly By _loggedUserName = By.XPath("//div[@class='gb_lb gb_mb']");

        public GoogleMailMainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToAccountInfo()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountInfoButton, 10);
            _webDriver.FindElement(_accountInfoButton).Click();
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

        public void WaitUntilMessageRecieved()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _amountOfIncomingMessages, 10);
        }

        public GoogleMessagePageObject OpenMessage()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _openLatestMessageButton, 10);
            _webDriver.FindElement(_openLatestMessageButton).Click();
            return new GoogleMessagePageObject(_webDriver);
        }

        public string GetLoggedUserName()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountInfoButton, 10);
            _webDriver.FindElement(_accountInfoButton).Click();
            WaitersWrapper.WaitElementVisiable(_webDriver, _loggedUserName, 10);
            return _webDriver.FindElement(_loggedUserName).Text;
        }
    }
}
