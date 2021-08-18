using HelperTask13.Helpers;
using OpenQA.Selenium;

namespace MailRuPageObjectsTask13.PageObjects
{
    public class MailRuMessagePageObject : MailRuMailPageObject
    {
        private readonly By _messageText = By.XPath("//div[@class='letter-body']");
        private readonly By _senderNameButton = By.XPath("//span[@class='letter-contact']");
        private readonly By _respondButton = By.XPath("//span[@class='button2 button2_has-ico button2_has-ico-s button2_reply button2_clean button2_hover-support js-shortcut']");
        private readonly By _respondInput = By.XPath("//div[@class='container--2Rl8H']/descendant::div[@role='textbox']");
        private readonly By _sendButton = By.XPath("//span[@class='button2 button2_base button2_primary button2_hover-support js-shortcut']/child::span");

        public MailRuMessagePageObject(IWebDriver webDriver) : base(webDriver)
        {

        }

        public string GetMessageText()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _messageText, 10);
            return _webDriver.FindElement(_messageText).Text;
        }

        public string GetSenderName()
        {
            WaitersWrapper.WaitElementVisiable(_webDriver, _senderNameButton, 10);
            return _webDriver.FindElement(_senderNameButton).GetAttribute("title");
        }

        public void Respond(string name)
        {
            WaitersWrapper.WaitElementInteractable(_webDriver, _respondButton, 10);
            _webDriver.FindElement(_respondButton).Click();
            WaitersWrapper.WaitElementInteractable(_webDriver, _respondInput, 10);
            _webDriver.FindElement(_respondInput).SendKeys(name);
            _webDriver.FindElement(_sendButton).Click();
        }
    }
}
