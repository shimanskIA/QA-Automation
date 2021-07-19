using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task13.PageObjects
{
    public class GoogleMailSettingsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _personalInfoButton = By.XPath("//div[@class='VjFXz']/following-sibling::div/descendant::li[@class='BBRNg'][position()=2]/child::a");

        public GoogleMailSettingsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GooglePersonalInfoPageObject GoToPersonalInfo()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _personalInfoButton, 10);
            _webDriver.FindElement(_personalInfoButton).Click();
            return new GooglePersonalInfoPageObject(_webDriver);
        }
    }
}
