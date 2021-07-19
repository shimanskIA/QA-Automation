using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task13.PageObjects
{
    public class GoogleAccountNamePageObject : GoogleAccountPageObject
    {
        private readonly By _nameInputButton = By.XPath("//div[@class='aJvDTb lY6Rwe'][position()=1]/descendant::input");
        private readonly By _surnameInputButton = By.XPath("//div[@class='aJvDTb lY6Rwe'][position()=2]/descendant::input");
        private readonly By _saveButton = By.XPath("//button[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc']");
        private readonly By _confirmationMessage = By.XPath("//div[@class='aGJE1b']");

        public GoogleAccountNamePageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void ChangeName(string newName, string newSurname)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _nameInputButton, 10);
            _webDriver.FindElement(_nameInputButton).SendKeys(Keys.Control + "a" + Keys.Backspace);
            _webDriver.FindElement(_nameInputButton).SendKeys(newName);
            _webDriver.FindElement(_surnameInputButton).SendKeys(Keys.Control + "a" + Keys.Backspace);
            _webDriver.FindElement(_surnameInputButton).SendKeys(newSurname);
            _webDriver.FindElement(_saveButton).Click();
            WaitersWrapper.WaitElementAppearDisappear(_webDriver, _confirmationMessage, 10);
        }
    }
}
