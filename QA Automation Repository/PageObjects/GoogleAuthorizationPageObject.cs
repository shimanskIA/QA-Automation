using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    public class GoogleAuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _enterButton = By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b']");
        private readonly By _loginInputButton = By.XPath("//input[@type='email']");
        private readonly By _passwordInputButton = By.XPath("//input[@type='password']");
        private readonly By _incorrectLoginMessage = By.XPath("//div[@class='o6cuMc']");
        private readonly By _incorrectPasswordMessage = By.XPath("//div[@class='OyEIQ uSvLId']");


        public GoogleAuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    
        public GoogleMailMainPageObject Login(string login, string password)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _loginInputButton, 10);
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_enterButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _passwordInputButton, 10);
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            return new GoogleMailMainPageObject(_webDriver);
        }

        public string UnsuccessfullLogin(string login)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _loginInputButton, 10);
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_enterButton).Click();
            WaitersWrapper.WaitElementVisiable(_webDriver, _incorrectLoginMessage, 10);
            return _webDriver.FindElement(_incorrectLoginMessage).Text;
        }

        public string UnsuccessfullPassword(string login, string password)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _loginInputButton, 10);
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_enterButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _passwordInputButton, 10);
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            WaitersWrapper.WaitElementVisiable(_webDriver, _incorrectPasswordMessage, 10);
            return _webDriver.FindElement(_incorrectPasswordMessage).Text;
        }
    }
}
