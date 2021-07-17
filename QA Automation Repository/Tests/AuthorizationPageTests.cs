using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task13.PageObjects;

namespace Task13.Tests
{
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

        [Test]

        public void SuccessfullLoginTest()
        {
            var authorizationPage = new AuthorizationPageObject(_webDriver);
            authorizationPage
                .Login(UserInputDataForTests.UserCorrectLogin, UserInputDataForTests.UserCorrectPassword)
                .GoToAccountInfo();
        }

        [Test]

        public void UnseccussfullLoginTest()
        {
            var authorizationPage = new AuthorizationPageObject(_webDriver);
            Assert.AreEqual(authorizationPage.UnsuccessfullLogin(UserInputDataForTests.UserIncorrectLogin), "Не удалось найти аккаунт Google.");
        }

        [Test]
        public void UnseccussfullPasswordTest()
        {
            var authorizationPage = new AuthorizationPageObject(_webDriver);
            Assert.AreEqual(authorizationPage.UnsuccessfullPassword(UserInputDataForTests.UserCorrectLogin, UserInputDataForTests.UserIncorrectPassword), "Неверный пароль. Повторите попытку или нажмите на ссылку \"Забыли пароль?\", чтобы сбросить его.");
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Quit();
        }


    }
}
