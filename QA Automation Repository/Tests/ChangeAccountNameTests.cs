using GooglePageObjectsTask13.PageObjects;
using HelperTask13.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task13.Tests
{
    [Order(3)]
    class ChangeAccountNameTests
    {
        private IWebDriver _webDriver;

        [SetUp]

        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
        }

        [Test, Order(8)]
        
        public void ChangeAccountNameTest()
        {
            GoogleAuthorizationPageObject googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            var mainPage = googleAuthorizationPage.Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword);
            mainPage.WaitUntilMessageRecieved();
            var messagePage = mainPage.OpenMessage();
            string recievedName = messagePage.GetMessageText();
            var newName = recievedName.Split(' ');
            var namePage = messagePage
                .GoToAccountSettings()
                .GoToPersonalInfo()
                .GoToGoogleMailNameInfo();
            namePage.ChangeName(newName[0], newName[1]);
            Assert.AreEqual(namePage.ReturnToMainPage().GetLoggedUserName(), recievedName);
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            GoogleMailMainPageObject mainPage = new GoogleMailMainPageObject(_webDriver);
            mainPage
                .GoToAccountSettings()
                .GoToPersonalInfo()
                .GoToGoogleMailNameInfo()
                .ChangeName(UserDataForTests.OldName, UserDataForTests.OldSurname);
            _webDriver.Quit();
        }
    }
}
