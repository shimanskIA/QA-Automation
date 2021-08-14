using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Model;
using TestProject.PageObjects;
using TestProject.Utils;

namespace TestProject.Tests
{
    [TestFixture]
    public class GoogleCloudTest : BaseTest
    {
        [Test]

        public void GoogleCloudTestMethod()
        {
            TestWrapper(() =>
            {
                GoogleCloudMainPageObject googleCloudTestPage = new GoogleCloudMainPageObject(_webDriver);
                string estimateCostSent = googleCloudTestPage
                    .Search(_searchKeyWord)
                    .ClickTheSearchedLink(_searchKeyWord)
                    .SetParametersOfVM(VirtualMachineCreator.CreateVM())
                    .SendEmail(_mailLogin + _mailPostfix)
                    .GetPrice();
                try
                {
                    _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
                    LoggerWrapper.LogInfo("Browser tab was switched!");
                }
                catch
                {
                    LoggerWrapper.LogError("Browser tab wasn't switched.");
                }
                YopMailMainPageObject yopMailMainPageObject = new YopMailMainPageObject(_webDriver);
                string estimateCostRecieved = yopMailMainPageObject
                    .LoginToMail(_mailLogin)
                    .OpenLatestMessage()
                    .GetPrice();
                Assert.AreEqual(estimateCostSent, estimateCostRecieved);
            });
        }
    }
}
