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

        }

        public YopMailMessagePageObject OpenLatestMessage()
        {
            WaitersWrapper.Wait(5);
            WaitersWrapper.WaitElementInteractable(_webDriver, _refreshButton, _waitingTime);
            _webDriver.FindElement(_refreshButton).Click();
            WaitersWrapper.Wait(5);
            WaitersWrapper.WaitElementInteractable(_webDriver, _frame, _waitingTime);
            IWebElement frame = _webDriver.FindElement(_frame);
            _webDriver.SwitchTo().Frame(frame);
            WaitersWrapper.WaitElementInteractable(_webDriver, _latestMessage, _waitingTime);
            _webDriver.FindElement(_latestMessage).Click();
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
            return new YopMailMessagePageObject(_webDriver);
        }
    }
}
