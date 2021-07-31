using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailRu.Pages
{
    /// <summary>
    /// A class that defines the inbox page entity
    /// </summary>
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


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditions.TitleContains(_driverTitle));
        }


        /// <summary>
        /// Method that checks whether the last incomming message has been read
        /// </summary>
        /// <returns>Message read or not</returns>
        public bool IsMessageNotRead()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageAddresseeLocator));
            string actualFontWeight = Driver.FindElement(_messageAddresseeLocator).GetCssValue("font-weight");
            return actualFontWeight == _boldFontWeight;
        }


        /// <summary>
        /// Method that vefifies that the email came from the correct addressee
        /// </summary>
        /// <param name="addressee">Addressee alias</param>
        /// <returns>Is correct addressee or not</returns>
        public bool IsCorrectAddressee(string addressee)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageAddresseeLocator));
            var messageAddressee = Driver.FindElement(_messageAddresseeLocator).Text;
            return messageAddressee == addressee;
        }


        /// <summary>
        /// Method for opening the last incomming message
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenMessage()
        {
            Driver.FindElement(_lastIncommingMessageLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for getting the last incomming message content
        /// </summary>
        /// <returns>The content of a message</returns>
        public string GetMessageContent()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_messageContent));
            return Driver.FindElement(_messageContent).Text;
        }


        /// <summary>
        /// Method for opening the reply window by pressing the reply button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenReplyWindow()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_replyButtonLocator));
            Driver.FindElement(_replyButtonLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for entering the reply message into the message field
        /// </summary>
        /// <param name="message">Message content</param>
        /// <returns>Current page</returns>
        public InboxPage EnterReplyMessage(string message)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_inputMessageFieldLocator));
            Driver.FindElement(_inputMessageFieldLocator).SendKeys(message);
            return this;
        }


        /// <summary>
        /// Method for sendig the reply message by pressing the send reply button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage SendReply()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_sendReplyButtonLocator));
            Driver.FindElement(_sendReplyButtonLocator).Click();
            return this;
        }
    }
}