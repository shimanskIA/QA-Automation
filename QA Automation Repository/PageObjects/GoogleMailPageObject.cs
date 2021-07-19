using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task13.PageObjects
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
