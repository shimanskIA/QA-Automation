using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    public class GooglePersonalInfoPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _nameButton = By.XPath("//a[@href='name?gar=1']");

        public GooglePersonalInfoPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GoogleMailNamePageObject GoToGoogleMailNameInfo()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _nameButton, 10);
            _webDriver.FindElement(_nameButton).Click();
            return new GoogleMailNamePageObject(_webDriver);
        }
    }
}
