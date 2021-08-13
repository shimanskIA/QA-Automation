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

        }

        public GoogleCloudPricingCalculatorPageObject ClickTheSearchedLink(string keyWord)
        {
            _searchedLink = By.XPath($"//a[contains(text(), '{keyWord}')]");
            WaitersWrapper.WaitElementInteractable(_webDriver, _searchedLink, _waitingTime);
            _webDriver.FindElement(_searchedLink).Click();
            return new GoogleCloudPricingCalculatorPageObject(_webDriver);
        }
    }
}
