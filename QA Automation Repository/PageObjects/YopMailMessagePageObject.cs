using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class YopMailMessagePageObject : BasePageObject
    {
        private readonly By _frame = By.XPath("//iframe[@id='ifmail']");
        private readonly By _totalEstimatedCostLabel = By.XPath("//h2[contains(text(), 'Estimated Monthly Cost')]");
        public YopMailMessagePageObject(IWebDriver webDriver) : base(webDriver)
        {
            LoggerWrapper.LogInfo("YopMail message page was successfully opened!");
        }

        public string GetPrice()
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(_frame);
                IWebElement frame = _webDriver.FindElement(_frame);
                _webDriver.SwitchTo().Frame(frame);
            }
            catch
            {
                LoggerWrapper.LogError("Frame wasn't found or XPath (or CSSSelector) is incorrect.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementVisiable(_totalEstimatedCostLabel);
                string totalEstimatedCostLabel = _webDriver.FindElement(_totalEstimatedCostLabel).Text;
                var labelParts = totalEstimatedCostLabel.Split(' ');
                LoggerWrapper.LogInfo("Pricing label was successfully parsed!");
                return labelParts[4];
            }
            catch
            {
                LoggerWrapper.LogError("Pricing label wasn't parse.");
                throw;
            }
        }
    }
}
