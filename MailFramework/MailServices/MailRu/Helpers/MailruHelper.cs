using OpenQA.Selenium;
using MailFramework.MailServices.MailRu.Pages;
using MailFramework.Models;

namespace MailFramework.MailServices.MailRu.Helpers
{
    /// <summary>
    /// A class that contains auxiliary methods based on MailRu pages
    /// </summary>
    public class MailruHelper
    {
        private IWebDriver _driver;

        private readonly string _baseurl = "https://account.mail.ru/login";


        /// <summary>
        /// Inits the browser
        /// </summary>
        public void InitBrowser()
        {
            _driver = MailServiceBrowser.GetInstance("MailruBrowser");
            _driver.Navigate().GoToUrl(_baseurl);
        }


        /// <summary>
        /// Closes the browser
        /// </summary>
        public void CloseBrowser()
        {
            MailServiceBrowser.CloseBrowser("MailruBrowser");
        }


        /// <summary>
        /// Method for logging into the account
        /// </summary>
        /// <param name="user">User to login</param>
        /// <returns>The page to which it transfers after login</returns>
        public BasePage DoLogin(User user)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.
                EnterUsername(user.Username).
                ConfirmUsername().
                EnterPassword(user.Password);
            return loginPage.ConfirmPassword();
        }


        /// <summary>
        /// Method for waiting for a valid message
        /// </summary>
        /// <param name="addressee">The user from whom the message is expected</param>
        /// <param name="content">The content of expected message</param>
        /// <returns>True if such message has came, else false</returns>
        public bool IsMessageCame(User addressee, string content)
        {
            int waitingTime = 0;
            while (!IsCorrectMessage(addressee))
            {
                System.Threading.Thread.Sleep(5000);
                waitingTime += 5000;
                _driver.Navigate().Refresh();
                if (waitingTime >= 60000)
                {
                    return false;
                }
            }
            if (!IsCorrectContent(content))
            {
                _driver.Navigate().Back();
                IsMessageCame(addressee, content);
            }
            _driver.Navigate().Back();
            return true;
        }


        /// <summary>
        /// Method that checks whether the message has not been read and has the correct addressee
        /// </summary>
        /// <param name="addressee">Addressee user</param>
        /// <returns>True if message hasn't been read and has the correct addressee, otherwise false</returns>
        private bool IsCorrectMessage(User addressee)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            return inboxPage.IsMessageNotRead() &&
                   inboxPage.IsCorrectAddressee(addressee.Username);
        }


        /// <summary>
        /// Method that verify the message content
        /// </summary>
        /// <param name="content">The expected content of a message</param>
        /// <returns>True if content is valid, else false</returns>
        private bool IsCorrectContent(string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.OpenLastIncommingMessage();
            return inboxPage.GetMessageContent() == content;
        }


        /// <summary>
        /// Method for sending the reply for the last incomming valid message
        /// </summary>
        /// <param name="content">Reply message content</param>
        public void SendReplyToTheLastIncommingLetter(string content)
        {
            InboxPage inboxPage = new InboxPage(_driver);
            inboxPage.
                OpenLastIncommingMessage().
                OpenReplyWindow().
                EnterReplyMessage(content).
                SendReply();
        }
    }
}
