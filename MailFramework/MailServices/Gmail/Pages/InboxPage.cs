using OpenQA.Selenium;
using MailFramework.Models;
using MailFramework.Wrappers;
using NLog;

namespace MailFramework.MailServices.Gmail.Pages
{
    /// <summary>
    /// A class that defines the inbox page entity
    /// </summary>
    public class InboxPage: BasePage
    {
        private readonly string _driverTitle = "Входящие";

        private const string _lastMessageXpath = "//table[@role='grid']//tr[1]";

        private IWebElement WriteLetterButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@class='T-I T-I-KE L3']")));

        private IWebElement RecipientField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//textarea[@name='to']")));

        private IWebElement MessageField =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[@aria-label='Тело письма']")));

        private IWebElement SendMessageButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//div[text()='Отправить']")));

        private IWebElement LastIncommingMessage =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath(_lastMessageXpath)));

        private IWebElement MessageAddressee =>
            Driver.FindElement(By.XPath(_lastMessageXpath + "//span[@name!='я']"));

        private IWebElement AvailableAccountsTab =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//a[contains(@aria-label, 'Аккаунт Google:')]")));

        private IWebElement ManageAccountButton =>
            Wait.Until(ExpectedConditionsWrapper.ElementIsVisible(
                By.XPath("//a[contains(text(), 'Управление')]")));

        private readonly string _boldFontWeight = "700";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Constructor for initializing the class fields
        /// </summary>
        /// <param name="driver">The current state of the Selenium driver</param>
        public InboxPage(IWebDriver driver) : base(driver)
        {
            Wait.Until(ExpectedConditionsWrapper.TitleContains(_driverTitle));
            _logger.Info("The inbox page is loaded");
        }


        /// <summary>
        /// Method for opening a new message tab
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenNewMessageTab()
        {
            WriteLetterButton.Click();
            return this;
        }


        /// <summary>
        /// Method for entering a message recipient
        /// </summary>
        /// <param name="recipient">The recipient email</param>
        /// <returns>Current page</returns>
        public InboxPage EnterRecipient(string recipient)
        {
            RecipientField.SendKeys(recipient);
            return this;
        }


        /// <summary>
        /// Method for entering a message into message field
        /// </summary>
        /// <param name="message">Message content</param>
        /// <returns>Current page</returns>
        public InboxPage EnterMessage(string message)
        {
            MessageField.SendKeys(message);
            return this;
        }


        /// <summary>
        /// Method for sending a message by pressing the confirmation button
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage SendMessage()
        {
            SendMessageButton.Click();
            return this;
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
            return MessageAddressee.GetAttribute("email") == addressee;
        }


        /// <summary>
        /// Method for opening the last incomming message
        /// </summary>
        /// <returns>Current page</returns>
        public MessageTab OpenLastIncommingMessage()
        {
            LastIncommingMessage.Click();
            return new MessageTab(Driver);
        }


        /// <summary>
        /// Method for opening the tab with all available accounts
        /// </summary>
        /// <returns>Current page</returns>
        public InboxPage OpenAvailableAccountsTab()
        {
            AvailableAccountsTab.Click();
            return this;
        }


        /// <summary>
        /// Method for openning the account settings tab
        /// by pressing the account settings button 
        /// </summary>
        /// <returns>The page to which it transfers after pressing the manage account button</returns>
        public AccountPage OpenAccountSettings()
        {
            ManageAccountButton.Click();
            return new AccountPage(Driver);
        }
    }
}
