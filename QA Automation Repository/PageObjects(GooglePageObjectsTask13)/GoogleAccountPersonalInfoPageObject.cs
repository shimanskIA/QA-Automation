using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace GooglePageObjectsTask13.PageObjects
{
    public class GoogleAccountPersonalInfoPageObject : GoogleAccountPageObject
    {
        private readonly By _nameButton = By.XPath("//a[@href='name?gar=1']");

        public GoogleAccountPersonalInfoPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public GoogleAccountNamePageObject GoToGoogleMailNameInfo()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _nameButton, 10);
            _webDriver.FindElement(_nameButton).Click();
            return new GoogleAccountNamePageObject(_webDriver);
        }
    }
}
