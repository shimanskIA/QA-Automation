using OpenQA.Selenium;
using TestProject.Model;
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

        public YopMailMailMainPageObject LoginToMail(User user)
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(_loginInput);
                _webDriver.FindElement(_loginInput).Click();
                _webDriver.FindElement(_loginInput).SendKeys(user.Login);
                LoggerWrapper.LogInfo("Login input field was filled!");
            }
            catch
            {
                LoggerWrapper.LogError("Login input field: unable to fill.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_enterButton);
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
