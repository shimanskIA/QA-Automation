using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace GooglePageObjectsTask13.PageObjects
{
    public class GoogleAccountSettingsPageObject : GoogleAccountPageObject
    {
        private readonly By _personalInfoButton = By.XPath("//div[@class='VjFXz']/following-sibling::div/descendant::li[@class='BBRNg'][position()=2]/child::a");

        public GoogleAccountSettingsPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public GoogleAccountPersonalInfoPageObject GoToPersonalInfo()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _personalInfoButton, 10);
            _webDriver.FindElement(_personalInfoButton).Click();
            return new GoogleAccountPersonalInfoPageObject(_webDriver);
        }
    }
}
