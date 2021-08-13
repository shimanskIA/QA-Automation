using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
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
            WaitersWrapper.WaitElementInteractable(_webDriver, _outerFrame, _waitingTime);
            IWebElement outerFrame = _webDriver.FindElement(_outerFrame);
            _webDriver.SwitchTo().Frame(outerFrame);
            IWebElement innerFrame = _webDriver.FindElement(_innerFrame);
            _webDriver.SwitchTo().Frame(innerFrame);
            WaitersWrapper.WaitElementInteractable(_webDriver, _numberOfInstancesInput, _waitingTime);
            _webDriver.FindElement(_numberOfInstancesInput).Click();
            _webDriver.FindElement(_numberOfInstancesInput).SendKeys(virtualMachine.NumberOfInstances.ToString());
            SelectAndChooseOneFromTable(_selectVMSeriesType, _chooseVMSeriesType);
            SelectAndChooseOneFromTable(_selectMachineType, _chooseMachineType);
            WaitersWrapper.WaitElementInteractable(_webDriver, _addGPUsCheckbox, _waitingTime);
            _webDriver.FindElement(_addGPUsCheckbox).Click();
            SelectAndChooseOneFromTable(_selectNumberOfGPUs, _chooseNumberOfGPUs);
            SelectAndChooseOneFromTable(_selectGPUType, _chooseGPUType);
            SelectAndChooseOneFromTable(_selectSSDVolume, _chooseSSDVolume);
            SelectAndChooseOneFromTable(_selectRegion, _chooseRegion);
            SelectAndChooseOneFromTable(_selectCommitedUsage, _chooseCommitedUsage);
            WaitersWrapper.WaitElementInteractable(_webDriver, _addToEstimateButton, _waitingTime);
            _webDriver.FindElement(_addToEstimateButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _emailEstimateButton, _waitingTime);
            _webDriver.FindElement(_emailEstimateButton).Click();
            return new EmailYourEstimateLoginPageObject(_webDriver);
        }

        public string GetPrice()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _totalEstimatedCostLabel, _waitingTime);
            string totalEstimatedCostLabel = _webDriver.FindElement(_totalEstimatedCostLabel).Text;
            var labelParts = totalEstimatedCostLabel.Split(' ');
            return labelParts[4];
        }

        private void SelectAndChooseOneFromTable(By selectPath, By choosePath)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, selectPath, _waitingTime);
            _webDriver.FindElement(selectPath).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, choosePath, _waitingTime);
            _webDriver.FindElement(choosePath).Click();
        }
    }
}
