using MailRu.Pages;
using OpenQA.Selenium;
using MailRu.DriverInstance;

namespace MailRu.Helpers
{
    /// <summary>
    /// A class that contains auxiliary methods based on MailRu pages
    /// </summary>
    public class MailRuHelper
    {
        private static readonly string _baseUrl = "https://account.mail.ru/login";

        private static IWebDriver _driver;


        /// <summary>
        /// Inits the browser
        /// </summary>
        public static void InitBrowser()
        {
            _driver = Driver.GetInstance();
            _driver.Navigate().GoToUrl(_baseUrl);
        }


        /// <summary>
        /// Closes the browser
        /// </summary>
        public static void CloseBrowser()
        {
            Driver.CloseBrowser();
        }


        /// <summary>
        /// Method for logging into the account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The page to which it transfers after the login</returns>
        public static InboxPage DoLogin(string username, string password)
        {
            LoginPage lp = new LoginPage(_driver);
            lp.EnterUsername(username);
            lp.ConfirmUsername();
            lp.EnterPassword(password);
            return lp.ConfirmPassword();
        }


        /// <summary>
        /// Method that checks whether the message has not been read and has the correct addressee
        /// </summary>
        /// <param name="addressee">The addressee username</param>
        /// <returns>True if message hasn't been read and has the correct addressee, otherwise false</returns>
        public static bool IsCorrectMessage(string addressee)
        {
            InboxPage ip = new InboxPage(_driver);
            return ip.IsMessageNotRead() && ip.IsCorrectAddressee(addressee);
        }


        /// <summary>
        /// Method that verify the message content
        /// </summary>
        /// <param name="content"></param>
        /// <returns>True if content is valid, else false</returns>
        public static bool IsCorrectContent(string content)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.OpenMessage();
            return ip.GetMessageContent() == content;
        }


        /// <summary>
        /// Method for waiting for a valid message
        /// </summary>
        /// <param name="addressee">The addressee username</param>
        /// <returns>True if such message has came, else false</returns>
        public static bool IsMessageCame(string addressee, string content)
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
        /// Method for sending the reply for the last incomming valid message
        /// </summary>
        /// <param name="message">Reply message content</param>
        public static void SendReply(string message)
        {
            InboxPage ip = new InboxPage(_driver);
            ip.
                OpenMessage().
                OpenReplyWindow().
                EnterReplyMessage(message).
                SendReply();
        }
    }
}