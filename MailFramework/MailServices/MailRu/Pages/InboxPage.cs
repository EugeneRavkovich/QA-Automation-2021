using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MailFramework.Models;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    public class InboxPage: BasePage
    {
        private const string _lastMessageXPath = "//a[contains(@class, 'letter-list-item')][1]";

        private readonly By _lastIncommingMessageLocator = By.XPath(_lastMessageXPath);

        private readonly By _messageAddresseeLocator = By.XPath(_lastMessageXPath + "/descendant::span[contains(@title, '@')]");

        private readonly By _messageContent = By.XPath("//div[@class='letter-body']/descendant::div[contains(text(), .)]");

        private readonly By _replyButtonLocator = By.XPath("//span[contains(@title, 'Ответить')]");

        private readonly By _inputMessageFieldLocator = By.XPath("//div[@role='textbox']//div[1]");

        private readonly By _sendReplyButtonLocator = By.XPath("//span[text()='Отправить']");

        private readonly string _driverTitle = "Входящие";

        private readonly string _boldFontWeight = "700";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
            _logger.Info("The inbox page is opened");
        }


        public bool IsMessageNotRead()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageAddresseeLocator));
            string actualFontWeight = Driver.FindElement(_messageAddresseeLocator).GetCssValue("font-weight");
            return actualFontWeight == _boldFontWeight;
        }


        public bool IsCorrectAddressee(string addressee)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageAddresseeLocator));
            var messageTitle = Driver.FindElement(_messageAddresseeLocator).GetAttribute("title");
            var messageAddressee = messageTitle.Substring(
                messageTitle.IndexOf("<") + 1, messageTitle.Length -
                messageTitle.IndexOf("<") - 2);
            return messageAddressee == addressee;
        }


        public InboxPage OpenLastIncommingMessage()
        {
            Driver.FindElement(_lastIncommingMessageLocator).Click();
            return this;
        }


        public string GetMessageContent()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageContent));
            return Driver.FindElement(_messageContent).Text;
        }


        public InboxPage OpenReplyWindow()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_replyButtonLocator));
            Driver.FindElement(_replyButtonLocator).Click();
            return this;
        }


        public InboxPage EnterReplyMessage(string message)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_inputMessageFieldLocator));
            Driver.FindElement(_inputMessageFieldLocator).SendKeys(message);
            return this;
        }


        public InboxPage SendReply()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_sendReplyButtonLocator));
            Driver.FindElement(_sendReplyButtonLocator).Click();
            return this;
        }
    }
}
