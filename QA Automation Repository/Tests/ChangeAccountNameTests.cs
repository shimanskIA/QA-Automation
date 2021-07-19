using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Task13.PageObjects;

namespace Task13.Tests
{
    [Order(3)]
    class ChangeAccountNameTests
    {
        private IWebDriver _webDriver;

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            GoogleAuthorizationPageObject googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
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

        [Test, Order(8)]
        
        public void ChangeAccountNameTest()
        {
            GoogleAuthorizationPageObject authorizationPage = new GoogleAuthorizationPageObject(_webDriver);
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
            Assert.AreEqual(messagePage.GetLoggedUserName(), recievedName);
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
