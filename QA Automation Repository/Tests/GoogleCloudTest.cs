using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Model;
using TestProject.PageObjects;

namespace TestProject.Tests
{
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
                _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
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
