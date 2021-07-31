using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoogleMail.Pages
{
    /// <summary>
    /// A class that defines the inbox page entity
    /// </summary>
    public class InboxPage: BasePage
    {
        private const string _lastMessageXpath = "//table[@role='grid']//tr[1]";

        private readonly string _driverTitle = "Входящие";

        private readonly By _writeLetterButtonLocator = By.XPath("//div[@class='T-I T-I-KE L3']");

        private readonly By _recipientFieldLocator = By.XPath("//textarea[@name='to']");

        private readonly By _messageFieldLocator = By.XPath("//div[@aria-label='Тело письма']");

        private readonly By _sendMessageButtonLocator = By.XPath("//div[text()='Отправить']");

        private readonly By _lastIncommingMessageLocator = By.XPath(_lastMessageXpath);

        private readonly By _messageAddresseeLocator = By.XPath(_lastMessageXpath + "//span[@name!='я']");

        private readonly By _messageContent = By.XPath("//div[@class='a3s aiL ']/div[2]/div[1]");

        private readonly By _availableAccountsTabLocator = By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]");

        private readonly By _manageAccountButtonLocator = By.XPath("//a[contains(text(), 'Управление')]");

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
        /// Method for opening a new message tab
        /// </summary>
        /// <returns></returns>
        public InboxPage OpenNewMessageTab()
        {
            Wait.Until(ExpectedConditions.ElementExists(_writeLetterButtonLocator));
            Driver.FindElement(_writeLetterButtonLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for entering a message recipient
        /// </summary>
        /// <param name="recipient">The recipient email</param>
        /// <returns>Current page</returns>
        public InboxPage EnterRecipient(string recipient)
        {
            Wait.Until(ExpectedConditions.ElementExists(_recipientFieldLocator));
            Driver.FindElement(_recipientFieldLocator).SendKeys(recipient);
            return this;
        }


        /// <summary>
        /// Method for entering a message into message field
        /// </summary>
        /// <param name="message">Message content</param>
        /// <returns>Current page</returns>
        public InboxPage EnterMessage(string message)
        {
            Wait.Until(ExpectedConditions.ElementExists(_messageFieldLocator));
            Driver.FindElement(_messageFieldLocator).SendKeys(message);
            return this;
        }


        /// <summary>
        /// Method for sending a message by pressing the confirmation button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage SendMessage()
        {
            Wait.Until(ExpectedConditions.ElementExists(_sendMessageButtonLocator));
            Driver.FindElement(_sendMessageButtonLocator).Click();
            return this;
        }


        /// <summary>
        /// Method that checks whether the last incomming message has been read
        /// </summary>
        /// <returns>Message read or not</returns>
        public bool IsMessageNotRead()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_lastIncommingMessageLocator));
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
            Wait.Until(ExpectedConditions.ElementIsVisible(_lastIncommingMessageLocator));
            var messageAddressee = Driver.FindElement(_messageAddresseeLocator).GetAttribute("name");
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
        /// Method for opening the tab with all available accounts
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenAvailableAccountsTab()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_availableAccountsTabLocator));
            Driver.FindElement(_availableAccountsTabLocator).Click();
            return this;
        }


        /// <summary>
        /// Method for openning the account settings tab
        /// by pressing the account settings button 
        /// </summary>
        /// <returns>The page to which it transfers after pressing the manage account button</returns>
        public AccountPage OpenAccountSettings()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(_manageAccountButtonLocator));
            Driver.FindElement(_manageAccountButtonLocator).Click();
            return new AccountPage(Driver);
        }
    }
}