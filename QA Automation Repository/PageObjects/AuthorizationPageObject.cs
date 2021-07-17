using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task13.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _continueButton = By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b']");
        private readonly By _enterButton = By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc qIypjc TrZEUc lw1w4b']");
        private readonly By _loginInputButton = By.XPath("//input[@type='email']");
        private readonly By _passwordInputButton = By.XPath("//input[@type='password']");
        private readonly By _incorrectLoginMessage = By.XPath("//div[text()='Не удалось найти аккаунт Google.']");
        private readonly By _incorrectPasswordMessage = By.XPath("//div[@class='OyEIQ uSvLId']");


        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    
        public MailMainPageObject Login(string login, string password)
        {
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_continueButton).Click();
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_passwordInputButton));
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            return new MailMainPageObject(_webDriver);
        }

        public string UnsuccessfullLogin(string login)
        {
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_continueButton).Click();
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementIsVisible(_incorrectLoginMessage));
            return _webDriver.FindElement(_incorrectLoginMessage).Text;
        }

        public string UnsuccessfullPassword(string login, string password)
        {
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_continueButton).Click();
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_passwordInputButton));
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            waiter.Until(ExpectedConditions.ElementIsVisible(_incorrectPasswordMessage));
            return _webDriver.FindElement(_incorrectPasswordMessage).Text;
        }
    }
}
