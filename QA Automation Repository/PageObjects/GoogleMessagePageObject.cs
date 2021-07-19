using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13.PageObjects
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
