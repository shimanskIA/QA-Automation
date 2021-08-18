using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace MailRuPageObjectsTask13.PageObjects
{
    public abstract class MailRuMailPageObject
    {
        protected IWebDriver _webDriver;

        protected readonly By _amountOfIncomingMessages = By.XPath("//span[@class='badge__text']");

        public MailRuMailPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void WaitUntilMessageRecieved()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _amountOfIncomingMessages, 10);
        }
    }
}
