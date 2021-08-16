using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class EmailYourEstimateLoginPageObject : BasePageObject
    {
        private readonly By _emailField = By.XPath("//input[@type='email']");
        private readonly By _sendEmailButton = By.XPath("//button[contains(text(), 'Send Email')]");
        
        public EmailYourEstimateLoginPageObject(IWebDriver webDriver) : base(webDriver)
        {
            LoggerWrapper.LogInfo("Email your estimate form was successfully opened!");
        }

        public GoogleCloudPricingCalculatorPageObject SendEmail(string address)
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(_emailField);
                _webDriver.FindElement(_emailField).Click();
                _webDriver.FindElement(_emailField).SendKeys(address);
                LoggerWrapper.LogInfo("Email field was filled!");
            }
            catch
            {
                LoggerWrapper.LogError("Email field: unable to fill.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_sendEmailButton);
                _webDriver.FindElement(_sendEmailButton).Click();
                LoggerWrapper.LogInfo("Send email button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Send email button: unable to push.");
                throw;
            }
            return new GoogleCloudPricingCalculatorPageObject(_webDriver);
        }
    }
}
