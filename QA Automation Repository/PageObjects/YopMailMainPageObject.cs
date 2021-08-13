using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class YopMailMainPageObject : BasePageObject
    {
        private readonly By _loginInput = By.XPath("//input[@id='login']");
        private readonly By _enterButton = By.XPath("//button[@class='md']");
        
        public YopMailMainPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public YopMailMailMainPageObject LoginToMail(string login)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _loginInput, _waitingTime);
            _webDriver.FindElement(_loginInput).Click();
            _webDriver.FindElement(_loginInput).SendKeys(login);
            WaitersWrapper.WaitElementInteractable(_webDriver, _enterButton, _waitingTime);
            _webDriver.FindElement(_enterButton).Click();
            return new YopMailMailMainPageObject(_webDriver);
        }
    }
}
