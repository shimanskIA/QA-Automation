using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13.PageObjects
{
    public class GoogleMessagePageObject
    {
        private IWebDriver _webDriver;

        private readonly By _messageText = By.XPath("//div[@class='adM']/following-sibling::div/child::div");
        private readonly By _accountInfoButton = By.XPath("//a[@class='gb_C gb_Ma gb_h']");
        private readonly By _accountSettingsButton = By.XPath("//a[@class='gb_rb gb_Sf gbp1 gb_Pe gb_3c']");

        public GoogleMessagePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetMessageText()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _messageText, 10);
            return _webDriver.FindElement(_messageText).Text;
        }

        public GoogleMailSettingsPageObject GoToAccountSettings()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountInfoButton, 10);
            _webDriver.FindElement(_accountInfoButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountSettingsButton, 10);
            _webDriver.FindElement(_accountSettingsButton).Click();
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
            return new GoogleMailSettingsPageObject(_webDriver);
        }

        public GoogleMailMainPageObject ReturnToMainPage()
        {
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            return new GoogleMailMainPageObject(_webDriver);
        }
    }
}
