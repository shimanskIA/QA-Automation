using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task13.PageObjects;

namespace Task13.Tests
{
    [Order(1)]
    class AuthorizationPageTests
    {
        private IWebDriver _webDriver;

        [SetUp]

        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
        }

        [Test, Order(1)]

        public void SuccessfullLoginTest()
        {
            GoogleAuthorizationPageObject authorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            authorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .GoToAccountInfo();
        }

        [Test, Order(2)]

        public void UnseccussfullLoginTest()
        {
            GoogleAuthorizationPageObject authorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            Assert.AreEqual(authorizationPage.UnsuccessfullLogin(UserDataForTests.UserIncorrectLogin), ServiceNotificationsForTest.LoginFailureText);
        }

        [Test, Order(3)]
        public void UnseccussfullPasswordTest()
        {
            GoogleAuthorizationPageObject authorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            Assert.AreEqual(authorizationPage.UnsuccessfullPassword(UserDataForTests.UserCorrectLogin, UserDataForTests.UserIncorrectPassword), ServiceNotificationsForTest.PasswordFailureText);
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
