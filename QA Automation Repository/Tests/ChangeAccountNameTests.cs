using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Task13.PageObjects;

namespace Task13.Tests
{
    class ChangeAccountNameTests
    {
        private IWebDriver _webDriver;

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            var googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .WaitUntilMessageRecieved();
            _webDriver.Quit();
        }
        
        [SetUp]

        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
        }

        [Test]
        
        public void ChangeAccountNameTest()
        {
            var authorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            var messagePage = authorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .OpenMessage();
            string recievedName = messagePage.GetMessageText();
            var newName = recievedName.Split(' ');
            messagePage
                .GoToAccountSettings()
                .GoToPersonalInfo()
                .GoToGoogleMailNameInfo()
                .ChangeName(newName[0], newName[1]);
            var mainPage = messagePage.ReturnToMainPage();
            Assert.AreEqual(mainPage.GetLoggedUserName(), recievedName);
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            var mainPage = new GoogleMessagePageObject(_webDriver);
            mainPage
                .GoToAccountSettings()
                .GoToPersonalInfo()
                .GoToGoogleMailNameInfo()
                .ChangeName(UserDataForTests.OldName, UserDataForTests.OldSurname);
            _webDriver.Quit();
        }
    }
}
