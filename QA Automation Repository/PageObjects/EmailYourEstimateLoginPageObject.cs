using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class EmailYourEstimateLoginPageObject : BasePageObject
    {
        private readonly By _emailField = By.XPath("//input[@type='email']");
        private readonly By _sendEmailButton = By.XPath("//button[contains(text(), 'Send Email')]");
        
        public EmailYourEstimateLoginPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public GoogleCloudPricingCalculatorPageObject SendEmail(string address)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _emailField, _waitingTime);
            _webDriver.FindElement(_emailField).Click();
            _webDriver.FindElement(_emailField).SendKeys(address);
            WaitersWrapper.WaitElementInteractable(_webDriver, _sendEmailButton, _waitingTime);
            _webDriver.FindElement(_sendEmailButton).Click();
            return new GoogleCloudPricingCalculatorPageObject(_webDriver);
        }
    }
}
