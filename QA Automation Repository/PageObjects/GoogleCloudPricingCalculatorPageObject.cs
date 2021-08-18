using OpenQA.Selenium;
using TestProject.Model;
using TestProject.Utils;

namespace TestProject.PageObjects
{
    public class GoogleCloudPricingCalculatorPageObject : BasePageObject
    {
        private readonly By _outerFrame = By.XPath("//article[@id='cloud-site']/descendant::iframe");
        private readonly By _innerFrame = By.XPath("//iframe[@id='myFrame']");
        private readonly By _numberOfInstancesInput = By.XPath("//input[@id='input_67']");
        private readonly By _selectVMSeriesType = By.XPath("//md-select-value[@id='select_value_label_63']");
        private readonly By _selectMachineType = By.XPath("//md-select-value[@id='select_value_label_64']");
        private readonly By _selectNumberOfGPUs = By.XPath("//md-select-value[@id='select_value_label_429']");
        private readonly By _selectGPUType = By.XPath("//md-select-value[@id='select_value_label_430']");
        private readonly By _selectSSDVolume = By.XPath("//md-select-value[@id='select_value_label_391']");
        private readonly By _selectRegion = By.XPath("//md-select-value[@id='select_value_label_65']");
        private readonly By _selectCommitedUsage = By.XPath("//md-select-value[@id='select_value_label_66']");
        private readonly By _addGPUsCheckbox = By.XPath("//div[contains(text(), 'Add GPUs')]/preceding-sibling::div");
        private readonly By _addToEstimateButton = By.XPath("//button[contains(text(), 'Add to Estimate')]");
        private readonly By _emailEstimateButton = By.XPath("//button[contains(text(), 'Email Estimate')]");
        private readonly By _totalEstimatedCostLabel = By.XPath("//b[contains(text(), 'Total Estimated Cost')]");
        private By _chooseVMSeriesType;
        private By _chooseMachineType;
        private By _chooseNumberOfGPUs;
        private By _chooseGPUType;
        private By _chooseSSDVolume;
        private By _chooseRegion;
        private By _chooseCommitedUsage;

        public GoogleCloudPricingCalculatorPageObject(IWebDriver webDriver) : base(webDriver)
        {
            LoggerWrapper.LogInfo("Google Cloud pricing calculator page was successfully opened!");
        }

        public EmailYourEstimateLoginPageObject SetParametersOfVM(VirtualMachine virtualMachine)
        {
            _chooseVMSeriesType = By.XPath($"//div[contains(text(), '{virtualMachine.VMSerial}')]");
            _chooseMachineType = By.XPath($"//div[contains(text(), '{virtualMachine.VMType}')]");
            _chooseNumberOfGPUs = By.XPath($"//div[@id='select_container_432']/descendant::div[contains(text(), '{virtualMachine.NumberOfGPUs}')]");
            _chooseGPUType = By.XPath($"//div[contains(text(), '{virtualMachine.GPUType}')]");
            _chooseSSDVolume = By.XPath($"//div[contains(text(), '{virtualMachine.VMVolume}')]/parent::md-option[@ng-repeat='item in listingCtrl.dynamicSsd.computeServer']"); 
            _chooseRegion = By.XPath($"//div[@id='select_container_97']/descendant::div[contains(text(), '{virtualMachine.Region}')]");
            _chooseCommitedUsage = By.XPath($"//div[@id='select_container_104']/descendant::div[contains(text(), '{virtualMachine.CommitedUsage}')]");
            try
            {
                WaitersWrapper.WaitElementInteractable(_outerFrame);
                IWebElement outerFrame = _webDriver.FindElement(_outerFrame);
                _webDriver.SwitchTo().Frame(outerFrame);
                IWebElement innerFrame = _webDriver.FindElement(_innerFrame);
                _webDriver.SwitchTo().Frame(innerFrame);
            }
            catch
            {
                LoggerWrapper.LogError("Frame wasn't found or XPath (or CSSSelector) is incorrect.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_numberOfInstancesInput);
                _webDriver.FindElement(_numberOfInstancesInput).Click();
                _webDriver.FindElement(_numberOfInstancesInput).SendKeys(virtualMachine.NumberOfInstances.ToString());
                LoggerWrapper.LogInfo("Number of instances field was filled!");
            }
            catch
            {
                LoggerWrapper.LogError("Number of instances field: unable to fill.");
                throw;
            }
            SelectAndChooseOneFromTable(_selectVMSeriesType, _chooseVMSeriesType, "VMSeries");
            SelectAndChooseOneFromTable(_selectMachineType, _chooseMachineType, "Machine type");
            try
            {
                WaitersWrapper.WaitElementInteractable(_addGPUsCheckbox);
                _webDriver.FindElement(_addGPUsCheckbox).Click();
                LoggerWrapper.LogInfo("Add GPU checkbox was checked!");
            }
            catch
            {
                LoggerWrapper.LogError("Add GPU checkbox: unable to check.");
                throw;
            }
            SelectAndChooseOneFromTable(_selectNumberOfGPUs, _chooseNumberOfGPUs, "Number of GPUs");
            SelectAndChooseOneFromTable(_selectGPUType, _chooseGPUType, "GPU Type");
            SelectAndChooseOneFromTable(_selectSSDVolume, _chooseSSDVolume, "SSD Volume");
            SelectAndChooseOneFromTable(_selectRegion, _chooseRegion, "Region");
            SelectAndChooseOneFromTable(_selectCommitedUsage, _chooseCommitedUsage, "Commited usage");
            try
            {
                WaitersWrapper.WaitElementInteractable(_addToEstimateButton);
                _webDriver.FindElement(_addToEstimateButton).Click();
                LoggerWrapper.LogInfo("Add to estimate button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Add to estimate button: unable to push.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(_emailEstimateButton);
                _webDriver.FindElement(_emailEstimateButton).Click();
                LoggerWrapper.LogInfo("Email estimate button was pushed!");
            }
            catch
            {
                LoggerWrapper.LogError("Email estimate button: unable to push.");
                throw;
            }
            return new EmailYourEstimateLoginPageObject(_webDriver);
        }

        public string GetPrice()
        {
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
                LoggerWrapper.LogError("Pricing label wasn't parsed.");
                throw;
            }
            
        }

        private void SelectAndChooseOneFromTable(By selectPath, By choosePath, string name)
        {
            try
            {
                WaitersWrapper.WaitElementInteractable(selectPath);
                _webDriver.FindElement(selectPath).Click();
                LoggerWrapper.LogInfo($"{name} field was found!");
            }
            catch
            {
                LoggerWrapper.LogError($"{name} field wasn't found or XPath (or CSSSelector) is incorrect.");
                throw;
            }
            try
            {
                WaitersWrapper.WaitElementInteractable(choosePath);
                _webDriver.FindElement(choosePath).Click();
                LoggerWrapper.LogInfo($"{name} field was filled!");
            }
            catch
            {
                LoggerWrapper.LogError($"{name} field: unable to fill.");
                throw;
            }
        }
    }
}
