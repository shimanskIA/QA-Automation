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

        [SetUp]

        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://gmail.com");
        }

        [Test]

        public void SendMailContentTest()
        {
            var googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .SendMessage(UserDataForTests.Destination, UserDataForTests.UserMessage);
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string recievedMessage = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetMessageText();
            Assert.AreEqual(UserDataForTests.UserMessage, recievedMessage);
        }

        [Test]

        public void SendMailSenderTest()
        {
            var googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .SendMessage(UserDataForTests.Destination, UserDataForTests.UserMessage);
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string senderName = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .OpenMessage()
                .GetSenderName();
            Assert.AreEqual(UserDataForTests.UserCorrectLogin, senderName);
        }

        /*public void SendMailMessageStateTest()
        {
            var googleAuthorizationPage = new GoogleAuthorizationPageObject(_webDriver);
            googleAuthorizationPage
                .Login(UserDataForTests.UserCorrectLogin, UserDataForTests.UserCorrectPassword)
                .SendMessage(UserDataForTests.Destination, UserDataForTests.UserMessage);
            _webDriver.Navigate().GoToUrl("https://mail.ru");
            var mailruAuthorizationPage = new MailRuAuthorizationPageObject(_webDriver);
            string messageState = mailruAuthorizationPage
                .Login(UserDataForTests.Destination, UserDataForTests.DestinationPassword)
                .GetMessageState();
            Assert.AreEqual("unread", messageState);
        }*/

        [TearDown]

        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
