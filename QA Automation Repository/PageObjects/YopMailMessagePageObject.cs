using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class YopMailMessagePageObject : BasePageObject
    {
        private readonly By _frame = By.XPath("//iframe[@id='ifmail']");
        private readonly By _totalEstimatedCostLabel = By.XPath("//h2[contains(text(), 'Estimated Monthly Cost')]");
        public YopMailMessagePageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public string GetPrice()
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _frame, _waitingTime);
            IWebElement frame = _webDriver.FindElement(_frame);
            _webDriver.SwitchTo().Frame(frame);
            WaitersWrapper.WaitElementVisiable(_webDriver, _totalEstimatedCostLabel, _waitingTime);
            string totalEstimatedCostLabel = _webDriver.FindElement(_totalEstimatedCostLabel).Text;
            var labelParts = totalEstimatedCostLabel.Split(' ');
            return labelParts[4];
        }
    }
}
