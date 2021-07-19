using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace GooglePageObjectsTask13.PageObjects
{
    public class GoogleMessagePageObject : GoogleMailPageObject
    {
        private readonly By _messageText = By.XPath("//div[@class='adM']/following-sibling::div/child::div");

        public GoogleMessagePageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public string GetMessageText()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _messageText, 10);
            return _webDriver.FindElement(_messageText).Text;
        }
    }
}
