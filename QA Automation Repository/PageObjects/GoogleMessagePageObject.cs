using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13.PageObjects
{
    class GoogleMessagePageObject
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
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_messageText));
            return _webDriver.FindElement(_messageText).Text;
        }

        public GoogleMailSettingsPageObject GoToAccountSettings()
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_accountInfoButton));
            _webDriver.FindElement(_accountInfoButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_accountSettingsButton));
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
