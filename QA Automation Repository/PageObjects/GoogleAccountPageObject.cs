using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13.PageObjects
{
    public abstract class GoogleAccountPageObject
    {
        protected IWebDriver _webDriver;

        protected readonly By _accountInfoButton = By.XPath("//a[@class='gb_C gb_Ma gb_h']");
        protected readonly By _loggedUserName = By.XPath("//div[@class='gb_lb gb_mb']");
        protected readonly By _accountSettingsButton = By.XPath("//a[@class='gb_rb gb_Sf gbp1 gb_Pe gb_3c']");

        protected GoogleAccountPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToAccountInfo()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountInfoButton, 10);
            _webDriver.FindElement(_accountInfoButton).Click();
        }

        public string GetLoggedUserName()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountInfoButton, 10);
            _webDriver.FindElement(_accountInfoButton).Click();
            WaitersWrapper.WaitElementVisiable(_webDriver, _loggedUserName, 10);
            return _webDriver.FindElement(_loggedUserName).Text;
        }

        public GoogleAccountSettingsPageObject GoToAccountSettings()
        {
            GoToAccountInfo();
            WaitersWrapper.WaitElementInteractable(_webDriver, _accountSettingsButton, 10);
            _webDriver.FindElement(_accountSettingsButton).Click();
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
            return new GoogleAccountSettingsPageObject(_webDriver);
        }

        public GoogleMailMainPageObject ReturnToMainPage()
        {
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            return new GoogleMailMainPageObject(_webDriver);
        }
    }
}
