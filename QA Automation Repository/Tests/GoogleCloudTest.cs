using NUnit.Framework;
using System.Linq;
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
                User user = UserCreator.CreateUser();
                string estimateCostSent = googleCloudTestPage
                    .Search(_searchKeyWord)
                    .ClickTheSearchedLink(_searchKeyWord)
                    .SetParametersOfVM(VirtualMachineCreator.CreateVM())
                    .SendEmail(user.Login + _mailPostfix)
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
                    .LoginToMail(user)
                    .OpenLatestMessage()
                    .GetPrice();
                Assert.AreEqual(estimateCostSent, estimateCostRecieved);
            });
        }
    }
}
