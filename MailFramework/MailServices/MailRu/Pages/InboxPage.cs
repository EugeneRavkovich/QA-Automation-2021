using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.MailRu.Pages
{
    /// <summary>
    /// A class that defines the inbox page entity
    /// </summary>
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


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The inbox page is opened");
        }


        /// <summary>
        /// Method that checks whether the last incomming message has been read
        /// </summary>
        /// <returns>Message read or not</returns>
        public bool IsMessageNotRead()
        {
            return MessageAddressee.GetCssValue("font-weight") == _boldFontWeight;
        }


        /// <summary>
        /// Method that vefifies that the email came from the correct addressee
        /// </summary>
        /// <param name="addressee">Addressee alias</param>
        /// <returns>Is correct addressee or not</returns>
        public bool IsCorrectAddressee(string addressee)
        {
            var messageTitle = MessageAddressee.GetAttribute("title");
            var messageAddressee = messageTitle.Substring(
                messageTitle.IndexOf("<") + 1, messageTitle.Length -
                messageTitle.IndexOf("<") - 2);
            return messageAddressee == addressee;
        }


        /// <summary>
        /// Method for opening the last incomming message
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenLastIncommingMessage()
        {
            LastIncommingMessage.Click();
            return this;
        }


        /// <summary>
        /// Method for getting the last incomming message content
        /// </summary>
        /// <returns>The content of a message</returns>
        public string GetMessageContent()
        {
            return MessageContent.Text;
        }


        /// <summary>
        /// Method for opening the reply window by pressing the reply button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenReplyWindow()
        {
            ReplyButton.Click();
            return this;
        }


        /// <summary>
        /// Method for opening the reply window by pressing the reply button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage EnterReplyMessage(string message)
        {
            InputMessageField.SendKeys(message);
            return this;
        }


        /// <summary>
        /// Method for sendig the reply message by pressing the send reply button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage SendReply()
        {
            SendReplyButton.Click();
            return this;
        }
    }
}
