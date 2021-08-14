using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class YopMailMailMainPageObject : BasePageObject
    {
        private readonly By _frame = By.XPath("//iframe[@id='ifinbox']");
        private readonly By _latestMessage = By.XPath("//div[@class='m'][position()=1]");
        private readonly By _refreshButton = By.XPath("//button[@id='refresh']");

        public YopMailMailMainPageObject(IWebDriver webDriver) : base(webDriver)
        {
            LoggerWrapper.LogInfo("YopMail main page was successfully opened!");
        }

        public YopMailMessagePageObject OpenLatestMessage()
        {
            WaitersWrapper.Wait(5);
            try
            {
                WaitersWrapper.WaitElementInteractable(_webDriver, _refreshButton, WaitingTime);
                _webDriver.FindElement(_refreshButton).Click();
                LoggerWrapper.LogInfo("Refresh button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Refresh button: unable to push.");
                throw;
            }
            WaitersWrapper.Wait(5);
            try
            {
                WaitersWrapper.WaitElementInteractable(_webDriver, _frame, WaitingTime);
                IWebElement frame = _webDriver.FindElement(_frame);
                _webDriver.SwitchTo().Frame(frame);
            }
            catch
            {
                LoggerWrapper.LogError("Frame wasn't found or XPath (or CSSSelector) is incorrect.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_webDriver, _latestMessage, WaitingTime);
                _webDriver.FindElement(_latestMessage).Click();
                LoggerWrapper.LogInfo("Latest message was opened!");
            }
            catch
            {
                LoggerWrapper.LogError("Latest message: unable to open.");
                throw;
            }
            try
            {
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
                LoggerWrapper.LogInfo("Browser tab was switched!");
            }
            catch
            {
                LoggerWrapper.LogError("Browser tab wasn't switched.");
                throw;
            }
            return new YopMailMessagePageObject(_webDriver);
        }
    }
}
