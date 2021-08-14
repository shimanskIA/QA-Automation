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
            LoggerWrapper.LogInfo("YopMail main page was successfully opened!");
        }

        public YopMailMailMainPageObject LoginToMail(string login)
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(_webDriver, _loginInput, WaitingTime);
                _webDriver.FindElement(_loginInput).Click();
                _webDriver.FindElement(_loginInput).SendKeys(login);
                LoggerWrapper.LogInfo("Login input field was filled!");
            }
            catch
            {
                LoggerWrapper.LogError("Login input field: unable to fill.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_webDriver, _enterButton, WaitingTime);
                _webDriver.FindElement(_enterButton).Click();
                LoggerWrapper.LogInfo("Enter button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Enter button: unable to push.");
                throw;
            }
            return new YopMailMailMainPageObject(_webDriver);
        }
    }
}
