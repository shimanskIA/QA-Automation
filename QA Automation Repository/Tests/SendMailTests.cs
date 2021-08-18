using GooglePageObjectsTask13.PageObjects;
using HelperTask13.Helpers;
using MailRuPageObjectsTask13.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task13.Tests
{
    [Order(2)]
    class SendMailTests
    {
        private IWebDriver _webDriver;
        
        [OneTimeSetUp]

        public void OneTimeSetup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            GoogleAuthorizationPageObject googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .SendMessage(UserDataForTests.Destination, UserDataForTests.UserMessage);
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .WaitUntilMessageRecieved();
        }

        [SetUp]

        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://mail.ru");
        }

        [Test, Order(2)]

        public void SendMailContentTest()
        {
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string recievedMessage = mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetMessageText();
            Assert.AreEqual(UserDataForTests.UserMessage, recievedMessage);
        }

        [Test, Order(4)]

        public void SendMailSenderTest()
        {
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string senderName = mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetSenderName();
            Assert.AreEqual(UserDataForTests.UserCorrectLogin, senderName);
        }

        [Test, Order(1)]

        public void SendMailUnreadMessageStateTest()
        {
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string messageState = mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .GetMessageState();
            Assert.AreEqual(ServiceNotificationsForTest.UnreadMessageTitle, messageState);
        }

        [Test, Order(3)]

        public void SendMailReadMessageStateTest()
        {
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string messageState = mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .GetMessageState();
            Assert.AreEqual(ServiceNotificationsForTest.ReadMessageTitle, messageState);
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Quit();
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            MailRuAuthorizationPageObject mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .Respond(UserDataForTests.NewName + " " + UserDataForTests.NewSurname);
            _webDriver.Quit();
        }
    }
}
