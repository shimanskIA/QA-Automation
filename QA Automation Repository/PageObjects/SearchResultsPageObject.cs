using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class SearchResultsPageObject : BasePageObject
    {
        private By _searchedLink;

        public SearchResultsPageObject(IWebDriver webDriver) : base(webDriver)
        {
            LoggerWrapper.LogInfo("Search results page was successfully opened!");
        }

        public GoogleCloudPricingCalculatorPageObject ClickTheSearchedLink(string keyWord)
        {
            _searchedLink = By.XPath($"//a[contains(text(), '{keyWord}')]");
            try
            {
                WaitersWrapper.WaitElementInteractable(_searchedLink);
                _webDriver.FindElement(_searchedLink).Click();
                LoggerWrapper.LogInfo($"Searched element ({keyWord}) was found!");
            }
            catch
            {
                LoggerWrapper.LogError($"Searched element ({keyWord}) wasn't found or XPath (or CSSSelector) is incorrect.");
                throw;
            }
            return new GoogleCloudPricingCalculatorPageObject(_webDriver);
        }
    }
}
