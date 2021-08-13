using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class GoogleCloudMainPageObject : BasePageObject
    {
        private readonly By _searchButton = By.XPath("//input[@class='devsite-search-field devsite-search-query']");

        public GoogleCloudMainPageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public SearchResultsPageObject Search(string serviceToSearch)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _searchButton, _waitingTime);
            _webDriver.FindElement(_searchButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _searchButton, _waitingTime);
            _webDriver.FindElement(_searchButton).SendKeys(serviceToSearch + Keys.Enter);
            return new SearchResultsPageObject(_webDriver);
        }
    }
}
