using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace GooglePageObjectsTask13.PageObjects
{
    public abstract class GoogleMailPageObject : GoogleAccountPageObject
    {
        protected readonly By _amountOfIncomingMessages = By.XPath("//div[@class='bsU']");

        protected GoogleMailPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void WaitUntilMessageRecieved()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _amountOfIncomingMessages, 10);
        }
    }
}
