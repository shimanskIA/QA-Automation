using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Task13.PageObjects;

namespace Task13.Tests
{
    class SendMailTests
    {
        private IWebDriver _webDriver;
        
        [OneTimeSetUp]

        public void OneTimeSetup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
            var googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .SendMessage(UserDataForTests.Destination, UserDataForTests.UserMessage);
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            var mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
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
            var mailRuAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string recievedMessage = mailRuAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetMessageText();
            Assert.AreEqual(UserDataForTests.UserMessage, recievedMessage);
        }

        [Test, Order(3)]

        public void SendMailSenderTest()
        {
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string senderName = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetSenderName();
            Assert.AreEqual(UserDataForTests.UserCorrectLogin, senderName);
        }

        [Test, Order(1)]

        public void SendMailUnreadMessageStateTest()
        {
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string messageState = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .GetMessageState();
            Assert.AreEqual(ServiceNotificationsForTest.UnreadMessageTitle, messageState);
        }

        [Test, Order(4)]

        public void SendMailReadMessageStateTest()
        {
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string messageState = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .GetMessageState();
            Assert.AreEqual(ServiceNotificationsForTest.ReadMessageTitle, messageState);
        }

        [TearDown]

        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
