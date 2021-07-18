using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    class MailRuAuthorizationPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _enterPasswordButton = By.XPath("//button[@data-testid='enter-password']");
        private readonly By _enterButton = By.XPath("//button[@class='second-button svelte-1eyrl7y']");
        private readonly By _loginInputButton = By.XPath("//input[@name='login']");
        private readonly By _passwordInputButton = By.XPath("//input[@type='password']");


        public MailRuAuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MailRuMailMainPageObject Login(string login, string password)
        {
            WebDriverWait waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_loginInputButton));
            _webDriver.FindElement(_loginInputButton).SendKeys(login);
            _webDriver.FindElement(_enterPasswordButton).Click();
            waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            waiter.Until(ExpectedConditions.ElementToBeClickable(_passwordInputButton));
            _webDriver.FindElement(_passwordInputButton).SendKeys(password);
            _webDriver.FindElement(_enterButton).Click();
            return new MailRuMailMainPageObject(_webDriver);
        }
    }
}
