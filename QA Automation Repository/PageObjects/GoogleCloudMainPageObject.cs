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
            LoggerWrapper.LogInfo("Google Cloud main page was successfully opened!");
        }

        public SearchResultsPageObject Search(string serviceToSearch)
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(_searchButton);
                _webDriver.FindElement(_searchButton).Click();
                _webDriver.FindElement(_searchButton).SendKeys(serviceToSearch + Keys.Enter);
                LoggerWrapper.LogInfo("Search button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Search button: unable to push.");
                throw;
            }
            return new SearchResultsPageObject(_webDriver);
        }
    }
}
