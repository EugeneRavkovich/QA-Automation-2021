using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    public class InboxPage: BasePage
    {
        private const string _lastMessageXPath = "//a[contains(@class, 'letter-list-item')][1]";

        private IWebElement LastIncommingMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath(_lastMessageXPath)));

        private IWebElement MessageAddressee =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath(_lastMessageXPath + "/descendant::span[contains(@title, '@')]")));

        private IWebElement MessageContent =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@class='letter-body']/descendant::div[contains(text(), .)]")));


        private IWebElement ReplyButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[contains(@title, 'Ответить')]")));

        private IWebElement InputMessageField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@role='textbox']//div[1]")));

        private IWebElement SendReplyButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//span[text()='Отправить']")));

        private readonly string _driverTitle = "Входящие";

        private readonly string _boldFontWeight = "700";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The inbox page is opened");
        }


        public bool IsMessageNotRead()
        {
            return MessageAddressee.GetCssValue("font-weight") == _boldFontWeight;
        }


        public bool IsCorrectAddressee(string addressee)
        {
            var messageTitle = MessageAddressee.GetAttribute("title");
            var messageAddressee = messageTitle.Substring(
                messageTitle.IndexOf("<") + 1, messageTitle.Length -
                messageTitle.IndexOf("<") - 2);
            return messageAddressee == addressee;
        }


        public InboxPage OpenLastIncommingMessage()
        {
            LastIncommingMessage.Click();
            return this;
        }


        public string GetMessageContent()
        {
            return MessageContent.Text;
        }


        public InboxPage OpenReplyWindow()
        {
            ReplyButton.Click();
            return this;
        }


        public InboxPage EnterReplyMessage(string message)
        {
            InputMessageField.SendKeys(message);
            return this;
        }


        public InboxPage SendReply()
        {
            SendReplyButton.Click();
            return this;
        }
    }
}
